import cv2
import sys
import numpy as np
import time
from shapely.geometry import LineString, MultiPolygon
from shapely.ops import polygonize, unary_union

def area(vertices):
    ls = LineString(vertices)
    # closed, non-simple
    lr = LineString(ls.coords[:] + ls.coords[0:1])
    lr.is_simple  # False
    mls = unary_union(lr)
    mls.geom_type  # MultiLineString'
    resultArea = 0
    i = 0
    for poly in polygonize(mls):
        polygon = list(zip(*poly.exterior.coords.xy))
        n = len(polygon) # of corners
        area = 0.0
        for i in range(n):
            j = (i + 1) % n
            area += polygon[i][0] * polygon[j][1]
            area -= polygon[j][0] * polygon[i][1]
        resultArea += abs(area) / 2.0
        i += 1
    return resultArea

if __name__ == "__main__":
    tracker = cv2.TrackerCSRT_create()
    exerciseDirection = 0 # 0 - down > up, 1 - up > down
    video = cv2.VideoCapture("videos/deadlift1.mp4")

    if not video.isOpened():
        print("Could not open video")
        sys.exit()

    ok, frame = video.read()
    if not ok:
        print("Cannot read video file")
        sys.exit()

    bbox = cv2.selectROI("Tracking",frame, False)
    tracker.init(frame, bbox)
    videoFrames = []
    frameHeight, frameLength = frame.shape[:2]

    color = (0, 255, 0)

    while ok:
        ok, frame = video.read()

        if ok:
            ok, bbox = tracker.update(frame)
            p = (int(bbox[0] + bbox[2]/2), int(bbox[1] + bbox[3]/2))
            videoFrames.append((frame.copy(), p))
            cv2.polylines(frame, np.int32([[frame[1] for frame in videoFrames]]), False, color, thickness=2, lineType=cv2.LINE_AA)
            cv2.imshow("Tracking", frame)
        k = cv2.waitKey(1) & 0xFF
        if k == 27:
            break
    
    #minHeight > startHeight
    #maxHeight > endHeight
    trackPoints = [frame[1] for frame in videoFrames]
    startHeight = min([point[1] for point in trackPoints]) if exerciseDirection == 1 else max([point[1] for point in trackPoints])
    endHeight = max([point[1] for point in trackPoints]) if exerciseDirection == 1 else min([point[1] for point in trackPoints])
    pathHeight = abs(startHeight - endHeight)
    probableRepHeight = startHeight + np.int32(pathHeight * 0.1 * (1 if exerciseDirection == 1 else -1))
    bottomOutHeight = endHeight - np.int32(pathHeight * 0.1 * (1 if exerciseDirection == 1 else -1))
    repDelta = np.int32(pathHeight * 0.5 * (1 if exerciseDirection == 1 else -1))
    repHeight = startHeight + repDelta
    
    repCount = 0
    isBottomedOut = False
    isProbableRep = False
    isRep = False
    started = False
    currentRepPoints = []
    reps = []
    pathArea = 0
    repFinishPoint = videoFrames[0][1][1]
    repState = 0 # 0 - not started, 1 - going down, 2 - bottomed out, 3 - going up
    firstHalfPoints = []
    secondHalfPoints = []
    repStateToString = {
        0: 'not started',
        1: 'down' if exerciseDirection == 1 else 'up',
        2: 'bottomed out',
        3: 'up' if exerciseDirection == 1 else 'down'
    }
    repQuality = 0
    for frame in videoFrames:
        framePoint = frame[1]
        pointHigherThenProbableRepHeight = framePoint[1] > probableRepHeight if exerciseDirection == 1 else framePoint[1] < probableRepHeight 
        pointHigherThenRepHeight = framePoint[1] > repHeight if exerciseDirection == 1 else framePoint[1] < repHeight
        pointHigherThenBottomOutHeight = framePoint[1] > bottomOutHeight if exerciseDirection == 1 else framePoint[1] < bottomOutHeight

        if not pointHigherThenProbableRepHeight and not started:
            started = True

        if started:
            if pointHigherThenProbableRepHeight:
                if not isProbableRep:
                    reps.append((currentRepPoints.copy(), isRep))
                    currentRepPoints.clear()
                    repState = 1
                if isProbableRep and not isRep and pointHigherThenRepHeight:
                    isRep = True
                    repState = 1
                    repCount += 1
                if isProbableRep and isRep and not isBottomedOut and pointHigherThenBottomOutHeight:
                    isBottomedOut = True
                    repState = 2
                if isProbableRep and isRep and isBottomedOut and not pointHigherThenBottomOutHeight:
                    isBottomedOut = False
                    repState = 3
                    resultArea = area(firstHalfPoints + [(currentRepPoints[0][0], firstHalfPoints[-1][1])])
                    repQuality = (1 - resultArea/(pathHeight*pathHeight/3))*100
                isProbableRep = True
            elif not pointHigherThenProbableRepHeight:
                isBottomedOut = False
                repState = 0
                if isProbableRep and isRep:
                    reps.append((currentRepPoints.copy(), isRep))
                    currentRepPoints.clear()
                    firstHalfPoints.clear()
                    secondHalfPoints.clear()
                    isRep = False
                if isProbableRep and not isRep:
                    currentRepPoints.clear()
                    isProbableRep = False

        currentRepPoints.append(framePoint)

        if repState == 1:
            firstHalfPoints.append(framePoint)
            #cv2.polylines(frame[0], np.int32([downHalfPoints + [(currentRepPoints[0][0], downHalfPoints[-1][1])]]), True, color, thickness=2, lineType=cv2.LINE_AA)
        elif repState == 3:
            secondHalfPoints.append(framePoint)
            #cv2.polylines(frame[0], np.int32([[(currentRepPoints[0][0], upHalfPoints[0][1])] + upHalfPoints + [(currentRepPoints[0][0], upHalfPoints[-1][1])]]), True, color, thickness=2, lineType=cv2.LINE_AA)

        if isProbableRep:
            trajectoryLine = [currentRepPoints[0], (currentRepPoints[0][0], endHeight)]
            #cv2.line(frame[0], frame[1], interseptPoint, (0, 255, 0), 2)
            cv2.line(frame[0], trajectoryLine[0], trajectoryLine[1], (255, 0, 0), 2)
                
        #rep state    
        cv2.putText(frame[0], repStateToString[repState], (100,120), cv2.FONT_HERSHEY_SIMPLEX, 0.75,(255,255,255),2)
        #rep count text
        cv2.putText(frame[0], str(repCount), (100,80), cv2.FONT_HERSHEY_SIMPLEX, 0.75,(255,255,255),2)
        #rep quality text
        cv2.putText(frame[0], str(repQuality), (100,100), cv2.FONT_HERSHEY_SIMPLEX, 0.75,(255,255,255),2)
        #barbell point
        cv2.circle(frame[0], frame[1], 3, (55*repCount, 0, 0), 2)
        #probable rep height line
        cv2.line(frame[0], (0, probableRepHeight), (frameLength, probableRepHeight), (0, 255, 0), 1)
        #rep height line
        cv2.line(frame[0], (0, repHeight), (frameLength, repHeight), (0, 0, 255), 1)
        #current rep path
        color = (110, 110, 110) if not isProbableRep else (0, 255, 0) if isRep else (0, 255, 255) 
        cv2.polylines(frame[0], np.int32([currentRepPoints]), False, color, thickness=2, lineType=cv2.LINE_AA)
        #previous rep paths
        #for rep in reps[-1:]:
            #color = (0, 255, 0) if rep[1] else (110, 110, 110) 
            #cv2.polylines(frame[0], np.int32([rep[0]]), False, color, thickness=2, lineType=cv2.LINE_AA)

        time.sleep(0.02)
        cv2.imshow("Tracking", frame[0])
        k = cv2.waitKey(1) & 0xFF
        if k == 27:
            break

