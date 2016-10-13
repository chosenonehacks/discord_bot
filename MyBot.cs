using System;
using Discord;
using Discord.Commands;

namespace PoziomekBot
{
    public class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        public MyBot()
        {
            discord = new DiscordClient(x =>
           {
               x.LogLevel = LogSeverity.Debug;
               x.LogHandler = Log;
           });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
                x.HelpMode = HelpMode.Public;
            });

            commands = discord.GetService<CommandService>();

            RegisterCommands();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjM1NjczNTU3MjA2Njk1OTM2.Ct-Ecg.dUnS-9Iu09xFCbIwyPoos4G6a8Y", TokenType.Bot);
            });

            
        }

        private void RegisterCommands()
        {
            commands.CreateCommand("hi")
                .Alias("h")
                .Do(async (e) => 
                {
                    await e.Channel.SendMessage("Hi");
                });

            commands.CreateCommand("ali")
                .Alias("Alinsar")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Ali Konia wali");
                });

            commands.CreateCommand("keld")
                .Alias("Keldereth")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Grześiu sresiu...");
                });

            commands.CreateCommand("blaha")
                .Alias("Hestos")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("blacha.jpg");
                });

            commands.CreateCommand("say")                                // The command text `!say <text>`
                    .Description("Make the bot say something")          // The command's description
                    .Alias("s")                                         // An alternate trigger for this command `!s <text>`
                    //.MinPermissions((int)AccessLevel.User)       // Limit this command to people who have administrator rights
                    .Parameter("text", ParameterType.Unparsed)          // The parameter for this command
                    .Do(async (e) =>                                    // The code to be run when the command is executed
                    {
                        string text = e.Args[0];
                        string checkText = text.ToLower().Trim();
                        if (checkText != "tomek sromek" && checkText != "tomeksromek" && !checkText.Contains("tomeksromek") && !checkText.Contains("tomek sromek"))
                        {
                            await e.Channel.SendMessage(text);
                        }
                        else
                        {
                            await e.Channel.SendMessage("Syntax Error 235: You can not offend the creator.");
                        }
                    });

            //commands.CreateCommand("botstatus")                    
            //        .Parameter("text", ParameterType.Unparsed)
            //        .AddCheck((cm, u, ch) => u.Id == 235682149506875392)
            //        .Description("Set bot status in Discord")                              
            //        .Do( (e) => 
            //        {
            //            string text = e.Args[0];
            //            commands.Client.SetGame(text);
            //        });

            ////Since we have setup our CommandChar to be '~', we will run this command by typing ~greet
            //commands.CreateCommand("greet") //create command greet
            //        .Alias(new string[] { "gr", "hi" }) //add 2 aliases, so it can be run with ~gr and ~hi
            //        .Description("Greets a person.") //add description, it will be shown when ~help is used
            //        .Parameter("GreetedPerson", ParameterType.Required) //as an argument, we have a person we want to greet
            //        .Do(async e =>
            //        {
            //            await e.Channel.SendMessage($"{e.User.Name} greets {e.GetArg("GreetedPerson")}");
            //            //sends a message to channel with the given text
            //        });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        //private AccessLevel GetPermission(User user, Channel channel)
        //{
        //    if (user.IsBot)                                     // Prevent other bots from executing commands
        //        return AccessLevel.Blocked;

        //    if (_config.Owners.Contains(user.Id))               // Create a specific permission for bot owners
        //        return AccessLevel.BotOwner;

        //    if (!channel.IsPrivate)                             // Make sure the command isn't executed in a PM.
        //    {
        //        if (user == channel.Server.Owner)               // Server owner permission for the server owner.
        //            return AccessLevel.ServerOwner;

        //        if (user.ServerPermissions.Administrator)       // Server admin permission for server admins.
        //            return AccessLevel.ServerAdmin;

        //        if (user.GetPermissions(channel).ManageChannel) // Channel admin permission for channel admins.
        //            return AccessLevel.ChannelAdmin;
        //    }

        //    return AccessLevel.User;                            // If nothing else fits return a default permission.
        //}
    }
}