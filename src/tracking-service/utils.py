import cv2
import sys
from shapely.geometry import LineString, MultiPolygon
from shapely.ops import polygonize, unary_union
from shapes import *
import numpy as np

def area(vertices):
    ls = LineString(vertices)
    lr = LineString(ls.coords[:] + ls.coords[0:1])
    lr.is_simple
    mls = unary_union(lr)
    mls.geom_type 
    resultArea = 0
    i = 0
    for poly in polygonize(mls):
        polygon = list(zip(*poly.exterior.coords.xy))
        n = len(polygon)
        area = 0.0
        for i in range(n):
            j = (i + 1) % n
            area += polygon[i][0] * polygon[j][1]
            area -= polygon[j][0] * polygon[i][1]
        resultArea += abs(area) / 2.0
        i += 1
    return resultArea

def trackVideo(videoName):
    tracker = cv2.TrackerCSRT_create()
    video = cv2.VideoCapture(videoName)

    if not video.isOpened():
        print("Could not open video")
        sys.exit()

    ok, frame = video.read()
    if not ok:
        print("Cannot read video file")
        sys.exit()

    bbox = cv2.selectROI("Tracking",frame, False)
    tracker.init(frame, bbox)

    return video, frame, tracker, ok

def getPerpendicularLine(start, end, horizontalLine, exerciseDirection):
    relEnd = abs(start - end)
    line = defaultLine.copy()
    i = -1
    for point in line:
        i += 1
        line[i] = (point[0] + horizontalLine, start + np.int32(point[1] * relEnd * exerciseDirection))

    return line

def connectVertices(firstVertices, secondVertices):
    return firstVertices.copy() + secondVertices.copy()

repStateToString = {
    0: 'standby', 
    1: 'maybe concentric fase', 
    2: 'concentric fase', 
    3: 'peak contraction phase', 
    4: 'maybe eccentric phase', 
    5: 'eccentric phase',
    6: 'finished',
    -1: 'undefined'
}

repStateToColor = {
    0: (50, 50, 50), 
    1: (255, 255, 0), 
    2: (60, 255, 0), 
    3: (0, 247, 255), 
    4: (255, 255, 0), 
    5: (60, 255, 0),
    6: (50, 50, 50),
    -1: (255, 24, 8)
}