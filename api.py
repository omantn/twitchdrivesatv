import flask
from flask import request, jsonify
from Raspi_MotorHAT import Raspi_MotorHAT, Raspi_DCMotor

import time
import atexit

###################################################################################################
##                                                                                               ##
## api.py                                                                                        ##
##                                                                                               ##
###################################################################################################
##                                                                                               ##
## Written during the great COVID plague of 2020 End of April by Michael Ochs                    ##
##                                                                                               ##
## This thing is ugly as far as code goes. I don't really handle any errors gracefully.          ##
## I tried making one of the repeating pieces of code a function, but the end result was         ##
## I actually increased the total lines of code, I explain it below but , that is                ##
## a total head scratcher.                                                                       ##
##                                                                                               ##
## All the MotorHAT initialization code is pretty much copy pasted from the samples              ##
## from the HAT manufacturer. The rest I figured out as simple as it is.                         ##
## It's super simple as far as api go. Api, Apis? Not sure on the plural there                   ##
##                                                                                               ##
##                                                                                               ##
###################################################################################################

#Address of the motor HAT, came straight from the HAT documentation
mh = Raspi_MotorHAT(addr=0x6f)

def turnOffMotors():
	mh.getMotor(1).run(Raspi_MotorHAT.RELEASE)
	mh.getMotor(2).run(Raspi_MotorHAT.RELEASE)
	mh.getMotor(3).run(Raspi_MotorHAT.RELEASE)
	mh.getMotor(4).run(Raspi_MotorHAT.RELEASE)

#register an event to turn off the motors when the app exits, this is a nifty feature in python
atexit.register(turnOffMotors)

# I shouldn't be hard coding magic numbers, don't do this at home kids
# It's just that on the board 2 and 3 are farthest apart and I don't know
# It just seems to satisfy my OCD when you look at it, but then on the 
# flip side, my developer code smell alarm is going off. Honestly, I can't win here.
LEFT_MOTOR = 3
RIGHT_MOTOR = 2

MotorLeft = mh.getMotor(LEFT_MOTOR)
MotorRight = mh.getMotor(RIGHT_MOTOR)

app = flask.Flask(__name__)
app.config["DEBUG"] = True

@app.route('/', methods=['GET'])
def home():
    return '''<h1>Your plastic pal who's fun to be with.</h1>
<p>Who knew that my first foray into REST-ish api's with Python would be a robot controlled by the internet.</p>'''

@app.route('/api/forward', methods=['GET'])
def api_forward():
    try:

        # Here is one thing I dislike about Python, you don't declare variables, there I said it.
        # untyped variables drive me nuts, yes I know these aren't totally untyped, but for readability
        # its just terrible. Also I tried moving the below 3 lines to a function because they repeat 
        # in every one of the movement calls. However the result is still 3 lines of code because i have
        # to set speed and duration to a value before I can pass it to the function because while you cant
        # declare variables you also cant use them for the first time in a fucntion call unless you first
        # set them to a value. So the outcome is still 3 lines of code anyway, then if you account for the 
        # 4 lines that made up the function I added, the non copy paste code chunks actually INCREASED the size of the code.
        # The below code may repeat, but at least you can tell what types my varaiables are
       
        query_parameters = request.args
        speed = int(query_parameters.get('speed'))
        duration = float(query_parameters.get('duration'))

        MotorLeft.run(Raspi_MotorHAT.FORWARD)
        MotorRight.run(Raspi_MotorHAT.FORWARD)

        MotorLeft.setSpeed(speed)
        MotorRight.setSpeed(speed)
        time.sleep(duration)
        MotorLeft.run(Raspi_MotorHAT.BRAKE)
        MotorRight.run(Raspi_MotorHAT.BRAKE)
        MotorLeft.setSpeed(0)
        MotorRight.setSpeed(0)

        return "Forward at speed " + str(speed) + " duration " + str(duration)
    except Exception as ex:
        return "forward failed: " + str(ex)

@app.route('/api/backward', methods=['GET'])
def api_backward():
    try:

        query_parameters = request.args
        speed = int(query_parameters.get('speed'))
        duration = float(query_parameters.get('duration'))

        MotorLeft.run(Raspi_MotorHAT.BACKWARD)
        MotorRight.run(Raspi_MotorHAT.BACKWARD)

        MotorLeft.setSpeed(speed)
        MotorRight.setSpeed(speed)
        time.sleep(duration)
        MotorLeft.run(Raspi_MotorHAT.BRAKE)
        MotorRight.run(Raspi_MotorHAT.BRAKE)
        MotorLeft.setSpeed(0)
        MotorRight.setSpeed(0)

        return "Backward at speed " + str(speed) + " duration " + str(duration)
    except Exception as ex:
        return "forward failed: " + str(ex)

@app.route('/api/left', methods=['GET'])
def api_left():
    try:
        query_parameters = request.args
        speed = int(query_parameters.get('speed'))
        duration = float(query_parameters.get('duration'))

        # to turn left we actually go backwards on the left tread
        # and forwards on the right tread
        MotorRight.run(Raspi_MotorHAT.FORWARD)
        MotorLeft.run(Raspi_MotorHAT.FORWARD)

        MotorLeft.setSpeed(int(speed)/2)
        MotorRight.setSpeed(speed)
        time.sleep(duration)
        MotorLeft.run(Raspi_MotorHAT.BRAKE)
        MotorRight.run(Raspi_MotorHAT.BRAKE)
        MotorLeft.setSpeed(0)
        MotorRight.setSpeed(0)

        return "Left at speed "+ str(speed) + " duration " + str(duration)
    except Exception as ex:
        return "forward failed: " + str(ex)

@app.route('/api/right', methods=['GET'])
def api_right():
    try:
        query_parameters = request.args
        speed = int(query_parameters.get('speed'))
        duration = float(query_parameters.get('duration'))

        # to turn right we actually go backwards on the right tread
        # and forwards on the left tread
        MotorRight.run(Raspi_MotorHAT.FORWARD)
        MotorLeft.run(Raspi_MotorHAT.FORWARD)

        MotorLeft.setSpeed(speed)
        MotorRight.setSpeed(int(speed)/2)
        time.sleep(duration)
        MotorLeft.run(Raspi_MotorHAT.BRAKE)
        MotorRight.run(Raspi_MotorHAT.BRAKE)
        MotorLeft.setSpeed(0)
        MotorRight.setSpeed(0)
        
        return "Right at speed " + str(speed) + " duration " + str(duration)
    except Exception as ex:
        return "forward failed: " + str(ex)

# it took me a moment to find the host= bit. This is pretty typical of models like this
# this being python flask or node.js and others to default to only listening for connections
# on localhost which is not super useful for an api unless of course the only callers 
# are on the same machine. By setting host=0.0.0.0 it will listen on all IPs that exist on this device,
# hard wired or wifi
app.run(host='0.0.0.0')