# twitchdrivesatv
The source code for my Raspberry Pi twitch controlled robot

There are a couple of things here, first the code that runs on the Raspberry Pi 4.

api.py - this is the api that controls the motors on the ATV itself. It is called from the C# application on the streaming desktop.
rpi_camera.py - this is a simple bit of code I found that converts the pi camera feed into an MPEG stream and a web page. 

Both of those get run on pi startup. The web page for the camera I frame in a source in OBS for the camera.

Then the C# program is the rest of the files. This is the vote tally, twitch chat app that runs on my stream PC. Watches chat for votes, tally's the votes every 15 seconds and then calls the above API to tell the robot to move.

Please don't assume any of this is code I would run in a real production environment. It works, it's not sexy, it doesn't handle errors super gracefully. It was just a fun project. Feel free to send hate anyway though! Or better yet, any ideas for improving it.
