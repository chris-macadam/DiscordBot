using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using OpenAI_API;

namespace MyFirstDiscordBot.SlashCommands
{
    internal class MyFirstCommandModule : ApplicationCommandModule
    {
        [SlashCommand("test", "A slash command made to test the DSharpPlusSlashCommands library!")]
        public async Task TestCommand(InteractionContext ctx) 
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, 
                new DiscordInteractionResponseBuilder()
                .WithContent("Success!"));
        }

        [SlashCommand("greet", "Greet a discord user!")]
        public async Task GreetUserCommand(InteractionContext ctx, 
            [Option("user", "What user do you want to greet.")] DiscordUser discordUser)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent($"Welcome to the server {discordUser.Mention}!"));
        }

        [SlashCommand("coinflip", "Flip a virtual coin!")]
        public async Task CoinFlipCommand(InteractionContext ctx)
        {
            Random rng = new Random();
            int randomNumber = rng.Next(0, 2);
            string[] results = new string[] { "Heads", "Tails" };

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent($"Flips a coin... {results[randomNumber]}!"));
        }

        [SlashCommand("random", "Generate a random number between a range.")]
        public async Task RandomCommand(InteractionContext ctx, 
            [Option("min", "Minimum number")] long min, 
            [Option("max", "Maximum number")] long max)
        {
            Random rng = new Random();
            int randomNumber = rng.Next((int)min, (int)max + 1);

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().WithContent($"Number between {min} and {max}: {randomNumber}"));
        }

        [ContextMenu(ApplicationCommandType.UserContextMenu, "Test")]
        public async Task TestUserMenu(ContextMenuContext ctx) 
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent("Success!"));
        }
    }
}
