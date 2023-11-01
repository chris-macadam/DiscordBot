# DiscordBot
A Discord bot made for me to learn.

## Requirements
The config.json file needed to run this bot is not uploaded with the source code here.
In order to download and run this project you must follow these steps:

#### 1. Create an discord application 
You must have scopes set as bot, and application.commands
Bot permissions have to be set as Administrator
Save the token
https://discord.com/developers/applications

#### 2. Create an Open AI API key
https://platform.openai.com/account/api-keys

#### 3. Create a file called config.json
The file should be at the root of the solution and formatted as the following.
Make sure the file is copied over to the build

{
    "ApplicationToken": "put_application_token_here",
    "OpenAiToken": "put_open_ai_key_here"
}