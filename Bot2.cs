using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

public class Bot2
{
    public static int TimeRemaining = 15;

    private static System.Threading.Timer VoteEndTimer;

    public delegate void UpdateLabelDelegate(string timeremaining);
    public static UpdateLabelDelegate UpdateTimer;
    public static UpdateLabelDelegate UpdateLeft;
    public static UpdateLabelDelegate UpdateRight;
    public static UpdateLabelDelegate UpdateForward;
    public static UpdateLabelDelegate UpdateBack;
    public static UpdateLabelDelegate UpdateList;

    private static List<string> initialUserList = new List<string>();
    private static List<string> HasVoted = new List<string>();
    private static int VotedLeft = 0;
    private static int VotedRight = 0;
    private static int VotedForward = 0;
    private static int VotedBackward = 0;

    private const string SPEED = "255";
    public static int DURATION = 1;
    public static float TURN_DURATION = 0.5f;
    private static string VEHICLE_API_URL;
    private static string TWITCH_API_KEY;
    TwitchClient client;

    // pretty simple stuff here, all the movement API's are simple gets
    // with querystring parameters. use of constants for speed and duration
    // and base URL, just make the call, E.Z. P.Z.
    public static void SendVehicleCommand(string command)
    {
        string URL = VEHICLE_API_URL;

        if (command.ToLower() == "forward")
            URL += command.ToLower() + "?speed=" + SPEED + "&duration=" + DURATION.ToString();
        else if (command.ToLower() == "left" || command.ToLower() == "right")
            URL += command.ToLower() + "?speed=" + SPEED + "&duration=" + TURN_DURATION.ToString();
        else
            URL += command.ToLower() + "?speed=" + SPEED + "&duration=" + DURATION.ToString();

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "GET";

        try
        {
            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            string response = responseReader.ReadToEnd();
            Console.Out.WriteLine(response);
            responseReader.Close();
        }
        catch (Exception e)
        {
            Console.Out.WriteLine("-----------------");
            Console.Out.WriteLine(e.Message);
        }
    }

    // a vote has ended when this timer strikes
    private void OnTimer(object state)
    {
        string Winner = "no votes";
        int WinningCount = 0;
        Random rnd = new Random();

        TimeRemaining -= 1;
        if (TimeRemaining == 0)
        {
            TimeRemaining = 15;
            //the vote has ended clear out the list of
            //people who already voted in preparation for
            //the next vote
            HasVoted.Clear();

            if (VotedLeft > 0)
            {
                Winner = "Left";
                WinningCount = VotedLeft;
            }
            if (VotedRight > 0 && VotedRight >= WinningCount)
            {
                // **tie breaker (this is true for every remaining vote as well, no copy paste comment)
                // this looks a little bit confusing and I don't love the readability of it
                // basically if the "VotedRight" is a greater count than the current winner we use it
                // OR if its the SAME as the current winnter, we essentially flip a coin (Random.Next is 
                // exclusive so Next(0,2) will always return 0 or 1 and I hate that, it should be 0,1 and inclusive).
                // If the result of the coin flip is a 1 we use Right as the winner, otherwise we keep the previous winner
                if (VotedRight > WinningCount || (VotedRight == WinningCount && rnd.Next(0, 2) == 1))
                {
                    Winner = "Right";
                    WinningCount = VotedRight;
                }
            }
            if (VotedForward > 0 && VotedForward >= WinningCount)
            {
                if (VotedForward > WinningCount || (VotedForward == WinningCount && rnd.Next(0, 2) == 1))
                {
                    Winner = "Forward";
                    WinningCount = VotedForward;
                }
            }
            if (VotedBackward > 0 && VotedBackward >= WinningCount)
            {
                if (VotedBackward > WinningCount || (VotedBackward == WinningCount && rnd.Next(0, 2) == 1))
                {
                    Winner = "Backward";
                    WinningCount = VotedBackward;
                }
            }

            //update previous winners list
            UpdateList(Winner);

            //reset all the vote counts on the form
            VotedLeft = 0;
            UpdateLeft("0");

            VotedRight = 0;
            UpdateRight("0");

            VotedForward = 0;
            UpdateForward("0");

            VotedBackward = 0;
            UpdateBack("0");

            client.SendMessage(client.JoinedChannels[0], "Vote ended, winner: " + Winner + ". New vote started.");

            //tell the vehicle to move to do the move
            SendVehicleCommand(Winner);

        }
        UpdateTimer.Invoke(TimeRemaining.ToString());
    }

    public Bot2(UpdateLabelDelegate TimeCallback, UpdateLabelDelegate LeftCallback, UpdateLabelDelegate RightCallback, UpdateLabelDelegate ForwardCallback, UpdateLabelDelegate BackCallback, UpdateLabelDelegate ListCallback)
    {
        // all the "Update" delegates are callbacks
        // on the UI thread to update the UI
        UpdateTimer = TimeCallback;
        UpdateLeft = LeftCallback;
        UpdateRight = RightCallback;
        UpdateForward = ForwardCallback;
        UpdateBack = BackCallback;
        UpdateList = ListCallback;

        //don't do this at home kids, this is an embarassingly bad way to make config files
        string[] lines = System.IO.File.ReadAllLines(@"d:\dev\TwitchDrivesATV\config.txt");
        VEHICLE_API_URL = lines[0];
        TWITCH_API_KEY = lines[1];

        VoteEndTimer = new System.Threading.Timer(OnTimer, null, 1000, 1000);

        ConnectionCredentials credentials = new ConnectionCredentials("twitchDrivesATV", TWITCH_API_KEY);

        var clientOptions = new ClientOptions
        {
            MessagesAllowedInPeriod = 750,
            ThrottlingPeriod = TimeSpan.FromSeconds(30)
        };
        WebSocketClient customClient = new WebSocketClient(clientOptions);
        client = new TwitchClient(customClient);
        client.Initialize(credentials, "twitchDrivesATV");

        client.OnLog += Client_OnLog;
        client.OnJoinedChannel += Client_OnJoinedChannel;
        client.OnMessageReceived += Client_OnMessageReceived;
        client.OnWhisperReceived += Client_OnWhisperReceived;
        client.OnNewSubscriber += Client_OnNewSubscriber;
        client.OnConnected += Client_OnConnected;

        client.Connect();
    }

    private void Client_OnLog(object sender, OnLogArgs e)
    {
        Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
    }

    private void Client_OnConnected(object sender, OnConnectedArgs e)
    {
        client.SendMessage(client.JoinedChannels[0], "Let the Games Begin! New vote started.");
    }

    private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
    {

    }

    private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
        // ok pretty simple stuff, there is no interval BETWEEN votes, so voting messages are always tallied
        // twitch has a "copy paste" protection that even as the owner of the channel you can't remove
        // that is you can't type EXACTLY the same message within a 30 second period.
        // the problem this creates is that on a 15 second vote interval, you couldn't vote "right" twice
        // for example. Since I cannot remove that restriction, the hack is to tell users
        // to type right and Right or RIGHT or RiGhT. Since there is a change in case twitch lets it through
        // I always convert the chat to lowercase so that I can just make one check for a vote type

        // this first if, checks to see if the message comes from someone who
        // has already voted this round. If they have voted, ignore them.
        // this means that a person can only vote once, and once they have
        // voted there is no way to change their vote, democracy at it's finest
        if (!HasVoted.Contains(e.ChatMessage.Username.ToLower()))
        {
            if (e.ChatMessage.Message.ToLower() == "left" || e.ChatMessage.Message.ToLower() == "l")
            {
                VotedLeft += 1;
                // add this person to the list of people who have voted
                HasVoted.Add(e.ChatMessage.Username.ToLower());
                UpdateLeft(VotedLeft.ToString());
            }
            else if (e.ChatMessage.Message.ToLower() == "right" || e.ChatMessage.Message.ToLower() == "r")
            {
                VotedRight += 1;
                HasVoted.Add(e.ChatMessage.Username.ToLower());
                UpdateRight(VotedRight.ToString());
            }
            else if (e.ChatMessage.Message.ToLower() == "forward" || e.ChatMessage.Message.ToLower() == "f")
            {
                VotedForward += 1;
                HasVoted.Add(e.ChatMessage.Username.ToLower());
                UpdateForward(VotedForward.ToString());
            }
            else if (e.ChatMessage.Message.ToLower() == "back" || e.ChatMessage.Message.ToLower() == "backward" || e.ChatMessage.Message.ToLower() == "")
            {
                VotedBackward += 1;
                HasVoted.Add(e.ChatMessage.Username.ToLower());
                UpdateBack(VotedBackward.ToString());
            }
        }
    }

    private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
    {
    }

    private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
    {
    }

}
