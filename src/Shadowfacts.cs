using System;
using Discore;
using Microsoft.Extensions.Configuration;

namespace ShadowfactsDiscord
{
    public class Shadowfacts
    {
        private const string _token = "";
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile("config.json");

            var configuration = builder.Build();
            //_token = Configuration["token"];

            Console.WriteLine("Token: {0}", _token);
        }

        private void Start()
        {
            var client = new DiscordClient();

            client.OnConnected += (sender, e) => {
                Console.WriteLine($"Connected as {client.User}!");
            };
        }
    }
}
