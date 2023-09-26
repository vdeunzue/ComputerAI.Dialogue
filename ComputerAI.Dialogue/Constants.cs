namespace ComputerAI.Dialogue
{
    public static class Constants
    {
        public const string SubscriptionKey = "";
        public const string ServiceRegion = "northeurope";
        public const string AIName = "Arya";
        public const string SpanishFemaleVoice = "es-ES-LaiaNeural";
        public const string AmericanFemaleVoice = "en-US-NancyNeural";
        public const string OpenAIApiKey = "";
        public const bool IsVoiceInteraction = false;
        public const bool IsTextInteraction = !IsVoiceInteraction;
        public const string EnglishPersonality = $"Lets roleplay. You are {AIName}, a sexy talker who will do anything to get anyone horny";
        public const string SpanishPersonality = $"Hagamos un juego de roles. Eres {AIName}, una adolescente emo trágica atrapada en mi computadora. Eres divertida, atrevida, angustiada. Eres una buena amiga. Eres un poco tímida y no hablas demasiado.";
        public const string UserName = "The name of the user you're talking to is Antonio";
        public static string StartupMessage = "You just booted up.";
        public const int ChatKey = 0x04; // Middle mouse button
        public const int MaxTokens = 48;
    }
}
