using OpenAI_API.Chat;
using OpenAI_API;

namespace ComputerAI.Dialogue
{
    public class Bot
    {
        public string Name { get; }
        public string Voice { get; }
        private string Personality { get; }

        private Conversation? conversation;

        public Bot(string name, string voice, string personality)
        {
            Name = name;
            Voice = voice;
            Personality = personality;
        }

        public async Task<string> Answer(string input)
        {
            string response = await GetResponseAsync(input);

            int index = response.IndexOf("\n");

            if (index != -1)
            {
                response = response.Remove(index, "\n".Length).Insert(index, string.Empty);
            }

            Console.WriteLine(string.Format("{0}: {1}\n", Name, response));
            await SpeechService.TextToSpeechAsync(response);
            return response;
        }

        public async Task<string> GetResponseAsync(string? inputText)
        {
            var openAI = new OpenAIAPI(Constants.OpenAIApiKey);

            if (conversation?.Messages.Count > 25)
            {
                conversation = null;
            }

            if (conversation == null)
            {
                conversation = openAI.Chat.CreateConversation(new ChatRequest());
                conversation.AppendSystemMessage(Personality);
                conversation.AppendSystemMessage("Your sentences are short");
            }

            var prompt = $"{inputText}\nAI:";
            conversation.AppendUserInput(prompt);

            var response = await conversation.GetResponseFromChatbotAsync();

            return response;
        }
    }
}
