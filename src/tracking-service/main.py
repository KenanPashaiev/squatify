from os import stat
import cv2
import numpy as np
import time
import json
from utils import * 
from trackedFrame import * 

if __name__ == "__main__":
    exerciseDirection = 1 # -1 - downUp, 1 - upDown
    trackedFrames = []

    video, frame, tracker, ok = trackVideo("videos/squat1.mp4")
    frameHeight, frameLength = frame.shape[:2]

    index = -1
    while ok:
        index += 1
        ok, frame = video.read()

        if ok:
            ok, bbox = tracker.update(frame)
            p = (int(bbox[0] + bbox[2]/2), int(bbox[1] + bbox[3]/2))
            currentTrackedFrame = TrackedFrame(frame.copy(), index, p[0], p[1], 0, 0)
            trackedFrames.append(currentTrackedFrame)

            cv2.polylines(frame, np.int32([[(trackedFrame.x, trackedFrame.y) for trackedFrame in trackedFrames]]), False, (0, 255, 0), thickness=2, lineType=cv2.LINE_AA)
            cv2.imshow("Tracking", frame)
        k = cv2.waitKey(1) & 0xFF
        if k == 27:
            break
    
    trackPoints = getPointsFromTrackedFrames(trackedFrames)
    pathStart = min([point[1] for point in trackPoints]) if exerciseDirection == 1 else max([point[1] for point in trackPoints])
    pathEnd = max([point[1] for point in trackPoints]) if exerciseDirection == 1 else min([point[1] for point in trackPoints])
    pathHeight = abs(pathStart - pathEnd)

    relPathStart = 0
    relPathEnd = abs(pathStart - pathEnd)
    relProbableRepStart = np.int32(pathHeight * 0.1)
    relProbableRepEnd = relPathEnd - np.int32(pathHeight * 0.1)
    relRepVerified = np.int32(relPathEnd / 2)

    state = 0
    repQuality = 0
    repCount = 0
    started = False
    optimalPath = [(0,0)]
    measurableRepStartPoints = [(0,0)]
    measurableRepEndPoints = [(0,0)]
    for trackedFrame in trackedFrames:
        repProgress = abs(trackedFrame.y - pathStart)
        pointHigherThanProbableRepStart = repProgress > relProbableRepStart
        pointHigherThenProbableRepEnd = repProgress > relProbableRepStart
        pointHigherThenRepHeight = repProgress > relRepVerified

        if repProgress < relProbableRepStart and not started: # check if user started the rep
            started = True

        if started:
            if repProgress > relProbableRepStart:
                if repProgress > relRepVerified:
                    if repProgress > relProbableRepEnd:
                        state = 3
                    elif state == 3:
                        state = 4
                    elif state == 1:
                        state = 2
                        setTrackedFramesState(trackedFrames, trackedFrame.index, state)
                elif state == 4:
                    state = 5
                    setTrackedFramesState(trackedFrames, trackedFrame.index, state)
                elif state == 0:
                    state = 1
            elif state == 2:
                state = 0
                setTrackedFramesState(trackedFrames, trackedFrame.index, state)
            elif state == 5:
                repCount += 1
                setTrackedFramesRepNumber(trackedFrames, trackedFrame.index, repCount)

                repStartPoints = getRepStartPoints(trackedFrames, repCount)
                repEndPoints = getRepEndPoints(trackedFrames, repCount)

                probableRepStart = pathStart+exerciseDirection*relProbableRepStart
                probableRepEnd = pathStart+exerciseDirection*relProbableRepEnd
                optimalPath = getPerpendicularLine(probableRepStart, probableRepEnd, repStartPoints[0][0], exerciseDirection)

                measurableRepStartPoints = connectVertices(repStartPoints, optimalPath[::-1])
                measurableRepEndPoints = connectVertices(repEndPoints, optimalPath)
                
                repStartPathArea = area(measurableRepStartPoints)
                repEndPathArea = area(measurableRepEndPoints)

                repQuality = np.int32((1 - ((repStartPathArea+repEndPathArea) / (pathHeight*pathHeight))) * 100 )
                state = 0
            
        trackedFrame.state = state

        #rep state    
        cv2.putText(trackedFrame.frame, repStateToString[trackedFrame.state], (100,120), cv2.FONT_HERSHEY_SIMPLEX, 0.75,(255,255,255),2)
        #rep count text
        cv2.putText(trackedFrame.frame, str(repCount), (100,80), cv2.FONT_HERSHEY_SIMPLEX, 0.75,(255,255,255),2)
        #rep quality text
        cv2.putText(trackedFrame.frame, str(repQuality), (100,100), cv2.FONT_HERSHEY_SIMPLEX, 0.75,(255,255,255),2)
        #barbell point
        cv2.circle(trackedFrame.frame, (trackedFrame.x, trackedFrame.y), 3, (55*repCount, 255, 255), 2)
        #probable rep start 
        cv2.line(trackedFrame.frame, (0, pathStart+exerciseDirection*relProbableRepStart), (frameLength, pathStart+exerciseDirection*relProbableRepStart), (0, 255, 0), 1)
        #probable rep end
        cv2.line(trackedFrame.frame, (0, pathStart+exerciseDirection*relProbableRepEnd), (frameLength, pathStart+exerciseDirection*relProbableRepEnd), (0, 255, 0), 1)
        #rep center
        cv2.line(trackedFrame.frame, (0, pathStart+exerciseDirection*relRepVerified), (frameLength, pathStart+exerciseDirection*relRepVerified), (0, 0, 255), 1)
        
        cv2.polylines(trackedFrame.frame, np.int32([optimalPath]), False, (255, 0, 0), thickness=1, lineType=cv2.LINE_AA)

        for frameToDisplay in trackedFrames[trackedFrame.index-min(20, trackedFrame.index):trackedFrame.index]:
            cv2.circle(trackedFrame.frame, (frameToDisplay.x, frameToDisplay.y), 1, repStateToColor[frameToDisplay.state], 2)


        time.sleep(0.02)
        cv2.imshow("Tracking", trackedFrame.frame)
        k = cv2.waitKey(1) & 0xFF
        if k == 27:
            break

    with open('data.json', 'w') as f:
        json.dump(trackedFrames.copy(), f, cls=TrackedFrameEncoder)
