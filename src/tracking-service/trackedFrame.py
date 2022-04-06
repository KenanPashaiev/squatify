import json

class TrackedFrame(object):
    def __init__(self, frame, index, x, y, repNumber, state):
        self.frame = frame
        self.index = index
        self.x = x
        self.y = y
        self.repNumber = repNumber
        self.state = state

class TrackedFrameEncoder(json.JSONEncoder):
    def default(self, obj):
        obj.frame = None
        if isinstance(obj, TrackedFrame):
            return obj.__dict__
        return json.JSONEncoder.default(self, obj)
        
def setTrackedFramesState(trackedFrames, index, newState):
    oldState = trackedFrames[index-1].state
    if oldState == newState:
        return

    for trackedFrame in trackedFrames[index-1::-1]:
        if trackedFrame.state != oldState:
            break

        trackedFrame.state = newState

def setTrackedFramesRepNumber(trackedFrames, index, repNumber):
    for trackedFrame in trackedFrames[index-1::-1]:
        if trackedFrame.state == 0:
            break

        trackedFrame.repNumber = repNumber

def getPointsFromTrackedFrames(trackedFrames):
    return [(trackedFrame.x, trackedFrame.y) for trackedFrame in trackedFrames]

def getRepPoints(trackedFrames, repNumber):
    result = [(trackedFrame.x, trackedFrame.y) for trackedFrame in trackedFrames if trackedFrame.repNumber == repNumber]
    return result

def getRepStartPoints(trackedFrames, repNumber):
    result = [(trackedFrame.x, trackedFrame.y) for trackedFrame in trackedFrames if trackedFrame.repNumber == repNumber and trackedFrame.state == 2]
    return result

def getRepEndPoints(trackedFrames, repNumber):
    result = [(trackedFrame.x, trackedFrame.y) for trackedFrame in trackedFrames if trackedFrame.repNumber == repNumber and trackedFrame.state == 5]
    return result
