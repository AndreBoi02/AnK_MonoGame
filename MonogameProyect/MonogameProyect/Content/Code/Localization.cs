using System;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    public enum Languages
    {
        ENG = 0,
        ESP = 1
    }

    internal class Localization
    {
        static Languages languages;
        static Dictionary<string, string[]> texts = new Dictionary<string, string[]>();
        static public event Action? UpdateTexts;

        public static void InitializeText()
        {
            languages = Languages.ENG;

            texts.Add("Title", new string[] {"ANK", "AYK"});
            texts.Add("Start", new string[] {"Start", "Comenzar"});
            texts.Add("Settings", new string[] {"Settings", "Configuracion"});
            texts.Add("Score", new string[] {"Score", "Puntaciones"});
        }

        public static void ChangeLanguage(Languages language)
        {
            languages = language;
            UpdateTexts?.Invoke();
        }

        public static String GetText(string textTitle)
        {
            return texts[textTitle][(int)languages];
        }
    }
}
