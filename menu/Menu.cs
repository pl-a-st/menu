using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace menu {
    public static class Menu<InputEnum> where InputEnum : Enum {
        static private int SelectedPosition = 0;
        static private Dictionary<InputEnum, string> Dictionary;
        static private string MainTextMenu;
        public static Enum GetSelectedInMenu(Dictionary<InputEnum, string> dictionary, string mainTextMenu) {
            SelectedPosition = 0;
            Dictionary = dictionary;
            MainTextMenu = mainTextMenu;
            GetStartedWithMenu();
            return dictionary.ToList()[SelectedPosition].Key as System.Enum;
            //return Enum.GetValues(typeof(InputEnum)).GetValue(SelectedPosition) as System.Enum; // так вытягиевает из Enum, но Enum может не соответствовать по порядку Dictionary
        }
        private static void GetStartedWithMenu() {
            Console.CursorVisible = false;
            StartMenu();
            Console.CursorVisible = true;
            Console.Clear();
        }
        private static void StartMenu() {
            ConsoleKeyInfo key = default;
            while (key.Key != ConsoleKey.Enter) {
                Console.Clear();
                Console.WriteLine(MainTextMenu);
                RewriteMenuFromDictionary();
                do {
                    key = Console.ReadKey(true);
                }
                while (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.Enter);
                DefineSelectedPosition(key);
            }
        }
        private static void DefineSelectedPosition(ConsoleKeyInfo key) {
            if (key.Key == ConsoleKey.UpArrow && SelectedPosition > 0) {
                SelectedPosition--;
            }
            if (key.Key == ConsoleKey.DownArrow && SelectedPosition < (Dictionary.Count - 1)) {
                SelectedPosition++;
            }
        }
        private static void RewriteMenuFromDictionary() {
            int i = 0;
            foreach (var row in Dictionary) {
                if (i == SelectedPosition) {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(row.Value);
                Console.ResetColor();
                i++;
            }
        }
        public static Dictionary<InputEnum, string> GetTypicalDictionaryForMenu(string repeatingString) {
            Dictionary<InputEnum, string> dictionary = new Dictionary<InputEnum, string>();
            int i = 0;
            foreach (string str in Enum.GetNames(typeof(InputEnum))) {
                var inpuEnumExempl = (InputEnum)Enum.Parse(typeof(InputEnum), str, true);
                dictionary.Add(inpuEnumExempl, repeatingString + " " + (i + 1));
                i++;
            }
            return dictionary;
        }
    }
}
