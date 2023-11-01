using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using MyFirstDiscordBot.Model;
using MyFirstDiscordBot.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyFirstDiscordBot
{
    internal class DiscordBot
    {
        public string ApplicationToken { get; set; } = string.Empty;
        public string OpenAiToken { get; set; } = string.Empty;

        public DiscordBot() 
        {
            string filepath = "config.json";

            if (!File.Exists(filepath))
            {
                return;
            }

            string jsonConfigString = File.ReadAllText(filepath);
            DiscordBotConfiguration? config = JsonSerializer.Deserialize<DiscordBotConfiguration>(jsonConfigString);

            if (config != null)
            {
                ApplicationToken = config.ApplicationToken;
                OpenAiToken = config.OpenAiToken;
            }
        }

        public async Task Run()
        {
            ServiceProvider services = new ServiceCollection()
                .AddSingleton(this)
                .BuildServiceProvider();

            DiscordClient discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = ApplicationToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All
            });

            discordClient.GuildMemberAdded += OnGuildMemberAdded;

            SlashCommandsExtension slashCommands = discordClient.UseSlashCommands(new SlashCommandsConfiguration() 
            {
                Services = services
            });
            slashCommands.RegisterCommands<MyFirstCommandModule>();
            slashCommands.RegisterCommands<OpenAICommandModule>();
            
            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }

        private async Task OnGuildMemberAdded(DiscordClient sender, GuildMemberAddEventArgs args)
        {
            DiscordChannel defaultChannel = args.Guild.GetDefaultChannel();
            var welcomeEmbedMessage = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.DarkButNotBlack,
                Title = $"Hi {args.Member.Username}! Welcome to the server!",
                Description = "Enjoy your stay. :)"
            };

            await defaultChannel.SendMessageAsync(welcomeEmbedMessage);
        }
    }
}
