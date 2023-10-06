using OpenAI_API.Chat;
using OpenAI_API;

namespace ComputerAI.Dialogue
{
    public class Persona1 : Persona
    {
        public const string SpanishPersonality = $"Vamos a hacer roleplay, en este caso tu comportas como Anakin Skywalker";
        public const string SpanishFemaleVoice = "es-ES-LaiaNeural";
        private Conversation? conversation;

        string Persona.Nombre { get => "Actor1 Anakin"; set => throw new NotImplementedException(); }

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
                conversation.AppendSystemMessage(SpanishPersonality);
                conversation.AppendSystemMessage("Tus frases son cortas");
            }

            var prompt = $"{inputText}\nAI:";
            conversation.AppendUserInput(prompt);

            var response = await conversation.GetResponseFromChatbotAsync();

            return response;
        }
    }
}
