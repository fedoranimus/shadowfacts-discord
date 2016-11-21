using System;
using Discore;
using Microsoft.Extensions.Configuration;

namespace ShadowfactsDiscord
{
    public class Shadowfacts
    {
        private static string _token = "";
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile("config.json");

            var configuration = builder.Build();
            _token = configuration["token"];

            Console.WriteLine("Token: {0}", _token);

            Start();
        }

        private static void Start()
        {
            var client = new DiscordClient();

            client.OnConnected += (sender, e) => {
                Console.WriteLine($"Connected as {client.User}!");
            };

            client.OnMessageCreated += (sender, e) => {
                DiscordMessage message = e.Message;
                if(message.Author != client.User && message.Content.Contains("!ping"))
                {
                    message.Channel.SendMessage("pong!");
                }
            };

            if(!client.Connect(_token).Result)
            {
                Console.WriteLine("Failed to connect!");
            }
        }
    }
}
