using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Chat;
using MyFirstDiscordBot.Model;

namespace MyFirstDiscordBot.SlashCommands
{
    internal class OpenAICommandModule : ApplicationCommandModule
    {
        public DiscordBot Bot { get; set; } = new DiscordBot();

        [SlashCommand("chatgpt", "Send a message to Open Ai, and receive a response!")]
        public async Task ChatGptCommand(InteractionContext ctx,
            [Option("message", "The message you want to send.")] string message)
        {
            await ctx.DeferAsync();

            OpenAIAPI openAIApi = new OpenAIAPI(Bot.OpenAiToken);
            Conversation conversation = openAIApi.Chat.CreateConversation();
            conversation.AppendUserInput(message);
            string response = await conversation.GetResponseFromChatbotAsync();

            var outputMessage = new DiscordEmbedBuilder()
            {
                Title = message,
                Description = response,
                Color = DiscordColor.DarkButNotBlack
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder()
                .AddEmbed(outputMessage));
        }
    }
}
