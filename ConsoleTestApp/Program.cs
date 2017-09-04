using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHelper;
using InfinityHelper;

namespace ConsoleTestApp
{
    class Program
    {
        #region App informaiton that needs to go into DLL
        Player Player1 = new InfinityPlayer();
        #endregion

        #region App information that stays in this program

        #endregion

        #region Entry Point
        /// <summary>
        /// Main applicaiton
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //possibly read in configuration information
            Program app = new Program();

            //retrieve data into local storage
            app.GetSetupData();

            while(Menu.GetChoice() != Menu.Choices.Exit)
            //Print game state -- possible redirect flow at later stages
            Console.WriteLine(app.GetStateString());

            // say goodbye
            Console.WriteLine(Messages.ExitMessage);

            //console UI shenanegins
            app.WaitBeforeContinue();
        }

        #endregion

        #region Program methods

        /// <summary>
        /// Aggregate all the game state information from the game classes as strings.
        /// </summary>
        /// <remarks>
        /// All game classes will have a defined way to stringify thier state information for re-inflation, printing, or serving of game data. At this time,
        /// I plan on doing this with strings, using loose XML.
        /// </remarks>
        /// <returns>String state of everything required to recreate this game.</returns>
        private String GetStateString()
        {
            StringBuilder StateStringBuilder = new StringBuilder();

            #region Player Info
            StateStringBuilder.AppendLine(Player1.GetState()); //TODO: get from player object
            #endregion
            #region Game Setup Info
            #endregion
            #region Game State Info
            #endregion

            return StateStringBuilder.ToString();
        }

        /// <summary>
        /// Automate the process of filling out specific library classes. This will possible be long and involve a lot of user interactions.
        /// </summary>
        private void GetSetupData()
        {
            //Play opener and get player name
            Console.WriteLine(Messages.OpeningMessage);
            Console.WriteLine("Please enter your Name in the console (Use \"Enter\" keys to submit):");
            Player1.Name = Console.ReadLine();

            //populate a static armylist so I dont need another menu:
            
        }

        /// <summary>
        /// Pause program excecution by waiting for a keystroke.
        /// </summary>
        /// <param name="message"></param>
        private ConsoleKeyInfo WaitBeforeContinue(string message = "Press any key to continue:")
        {
            Console.WriteLine(message);
            return Console.ReadKey();
        }
        #endregion

    }
}
