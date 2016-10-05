using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsManagerConsol
{
    class Menu
    {

        #region Class Variables

        private static bool isProgramOver;

        #endregion

        #region Properties

        public static bool IsProgramOver
        {
            get { return isProgramOver; }
            set { isProgramOver = value; }
        }

        #endregion

        #region Menu Methods

        public static void MainMenu()   //  Huvudmeny
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("\n\t\t\t   Welcome to ComicsManager\n");
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("\t\t\t   Your current collection:");
                Console.WriteLine("-----------------------------------------------------------------------------");
                ComicsManager.ShowList();
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("\n\t\t\t  {          Menu:         }\n");
                Console.WriteLine("\t\t\t       1 - Add Comic");
                Console.WriteLine("\t\t\t       2 - Edit Comic");
                Console.WriteLine("\t\t\t       3 - Remove Comic");
                Console.WriteLine("\t\t\t       4 - Save To File");
                Console.WriteLine("\t\t\t       5 - Quit\n");
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.Write("\t\t\t       Choice: ");

                switch (choice = Console.ReadLine())
                {
                    case "1":
                        ComicsManager.AddToList();
                        IsProgramOver = false;
                        break;
                    case "2":
                        ComicsManager.EditItemInList();
                        IsProgramOver = false;
                        break;
                    case "3":
                        ComicsManager.RemoveFromList();
                        IsProgramOver = false;
                        break;
                    case "4":
                        ComicsManager.SaveFile();
                        IsProgramOver = false;
                        break;
                    case "5":
                        IsProgramOver = true;
                        break;
                    default:
                        break;
                }
            } while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5");
        }

        #endregion
    }
}
