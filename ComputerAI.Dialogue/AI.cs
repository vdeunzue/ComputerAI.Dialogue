namespace ComputerAI
{
    public class AI
    {
        public static async Task GreetHuman()
        {
            var greetings = await OpenAI.GetResponseAsync(Constants.StartupMessage);
            Console.WriteLine(string.Format("Arya: {0}\n", greetings.Replace("\n", string.Empty)));
            await SpeechService.TextToSpeechAsync(greetings);
        }

        public static async Task AnswerHuman(string input)
        {
            var response = await OpenAI.GetResponseAsync(input);

            int index = response.IndexOf("\n");

            if (index != -1)
            {
                response = response.Remove(index, "\n".Length).Insert(index, string.Empty);
            }

            Console.WriteLine(string.Format("{0}: {1}\n", Constants.AIName, response));
            await SpeechService.TextToSpeechAsync(response);
        }
    }
}
