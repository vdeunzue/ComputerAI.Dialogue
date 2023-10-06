using ComputerAI.Dialogue;

namespace ComputerAI
{
    public class AI
    {
        public static async Task<string> AnswerHuman(string input, Persona persona)
        {
            string response = "";

            if (persona is Persona1)
            {
                response = await (persona as Persona1).GetResponseAsync(input);
            }

            if (persona is Persona2)
            {
                response = await (persona as Persona2).GetResponseAsync(input);
            }

            int index = response.IndexOf("\n");

            if (index != -1)
            {
                response = response.Remove(index, "\n".Length).Insert(index, string.Empty);
            }

            Console.WriteLine(string.Format("{0}: {1}\n", persona.Nombre, response));
            await SpeechService.TextToSpeechAsync(response);
            return response;
        }
    }
}
