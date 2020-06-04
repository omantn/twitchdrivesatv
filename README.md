# twitchdrivesatv
The source code for my Raspberry Pi twitch controlled robot

There are a couple of things here, first the code that runs on the Raspberry Pi 4.

api.py - this is the api that controls the motors on ATV it self. It is called from the C# application on the streaming desktop.
rpi_camera.py - this is a simple bit of code I found that converts the pi camera feed into an MPEG stream and a web page. 


Then the C# program is the rest of the files. This is the vote tally, twitch chat app that runs on my stream PC. Watches chat for votes, tally's the votes every 15 seconds and then calls the above API to tell the robot to move.
