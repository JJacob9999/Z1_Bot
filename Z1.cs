using Discord;
using Discord.Commands;

using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace z1
{
    class z1
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] randomRolls;
        string[] randomTexts;


        public z1()
        {
            rand = new Random();

            randomRolls = new string[]
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10"
            };

            randomTexts = new string[]
            {
                "One"
                "Two"
                "Three"
            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '-';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterPurgeCommand();
            RegisterRollCommand();
            RegisterTextCommand();
            

 //           commands.CreateCommand("hello")
   //             .Do(async (e) =>
     //           {
       //             await e.Channel.SendMessage("Fuck off!");
         //       });


            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjQwMTgwNTg2MTgwOTAyOTIz.CvCYXw.FeHAPCysf61QcQTqrV1rqM0Dm84", TokenType.Bot);
            });
        }

            
        }

        private void RegisterPurgeCommand()
        {
            commands.CreateCommand("purge")
            .Do(async (e) =>
            {
                Message[] messagesToDelete;
                messagesToDelete = await e.Channel.DownloadMessages(100);

                await e.Channel.DeleteMessages(messagesToDelete);
            });
        }



        private void RegisterTextCommand()
        {
            commands.CreateCommand("text")
            .Do(async (e) =>
            {
                int randomTextIndex = rand.Next(randomTexts.Length);
                string textToPost = randomTexts[randomTextIndex];
                await e.Channel.SendMessage(textToPost);
            });
        }


        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
  }
}
