using OpenAI_API.Chat;
using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;

namespace ComputerAI.Dialogue
{

    public class Persona2 : Persona
    {
        public const string SpanishPersonality = $"Vamos a hacer roleplay, en este caso tu te comportas como Obi-Wan Kenobi";
        public const string SpanishFemaleVoice = "es-ES-LaiaNeural";
        string Persona.Nombre { get => "Actor 2 Obiwan"; set => throw new NotImplementedException(); }
        private Conversation? conversation;

        public async Task<string> GetResponseAsync(string? inputText)
        {
            var openAI = new OpenAIAPI(Constants.OpenAIApiKey);

            if (conversation?.Messages.Count > 3)
            {
                conversation = null;
            }

            if (conversation == null)
            {
                conversation = openAI.Chat.CreateConversation(new ChatRequest());
                conversation.AppendSystemMessage(SpanishPersonality);
                conversation.AppendSystemMessage("Tus frases son cortas y hablas como yoda");
            }

            var prompt = $"{inputText}\nAI:";
            conversation.AppendUserInput(prompt);

            var response = await conversation.GetResponseFromChatbotAsync();

            return response;
        }
    }

}
