using System;

namespace ConsoleTestApp
{
    internal class Menu
    {
        public enum Choices
        {
            AddPlayer,
            EditArmyList,
            NewGame,
            Exit,
            Reprompt

        }

        internal static Choices GetChoice()
        {
            Console.WriteLine("Select an option by typing the number: ");

            string[] choicex = Enum.GetNames(typeof(Choices));
                        
            for(int i = 1; i< choicex.Length; i++)
            {
                Console.WriteLine("{0}) {1}", i, choicex[i]);
            }

            Choices choice;

            if(Enum.TryParse<Choices>(Console.ReadLine(),out choice))
            {
                return choice;
            }
            return Choices.Reprompt;
        }
    }
}