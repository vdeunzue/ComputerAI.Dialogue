using System.Runtime.InteropServices;
using ComputerAI;
using ComputerAI.Dialogue;
using Microsoft.CognitiveServices.Speech.Dialog;

class Program
{
    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(int vKey);

    static async Task Main()
    {
        Console.WriteLine("ComputerAI started.\n");

        int contador = 0;
        var persona1 = new Persona1();
        var persona2 = new Persona2();
        
        // Persona1 iniciará la conversación
        var msgPersona1 = await AI.AnswerHuman("te has liado con ahsoka?", persona1);
        var msgPersona2 = await AI.AnswerHuman(msgPersona1, persona2);

        while (contador < 6)
        {
            contador++;
            msgPersona1 = await AI.AnswerHuman(msgPersona2, persona1);
            msgPersona2 = await AI.AnswerHuman(msgPersona1, persona2);
        }
    }
}