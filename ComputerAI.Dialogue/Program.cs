using ComputerAI.Dialogue;

class Program
{
    private const int MAX_INTERACTIONS = 5;

    /*
     * For a list of voices, check https://learn.microsoft.com/en-us/azure/ai-services/speech-service/language-support?tabs=tts
     * */
    static async Task Main()
    {
        Console.WriteLine("ComputerAI.Dialogue started.\n");

        var bot1 = new Bot("Anakin", "en-US-DavisNeural", "You are talking to Obi-wan Kenobi", "Let's roleplay, you will act as Anakin Skywalker");
        var bot2 = new Bot("Obi-wan", "en-US-SteffanNeural", "You are talking to Anakin Skywalker", "Let's roleplay, you will act as Obi-wan Kenobi");

        string msgBot2 = "You were the chosen one";
        var msgBot1 = await bot1.Answer(msgBot2);

        int counter = 0;
        while (counter < MAX_INTERACTIONS)
        {
            counter++;
            msgBot2 = await bot2.Answer(msgBot1);
            msgBot1 = await bot1.Answer(msgBot2);
        }
    }
}