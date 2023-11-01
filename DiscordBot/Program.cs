using DSharpPlus;
using DSharpPlus.EventArgs;
using MyFirstDiscordBot.Model;
using System.Text.Json;

namespace MyFirstDiscordBot
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            DiscordBot bot = new DiscordBot();
            await bot.Run();
        }
    }
}