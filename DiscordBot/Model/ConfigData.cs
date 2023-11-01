using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstDiscordBot.Model
{
    internal class DiscordBotConfiguration
    {
        public string ApplicationToken { get; set; } = string.Empty;

        public string OpenAiToken { get; set; } = string.Empty;
    }
}
