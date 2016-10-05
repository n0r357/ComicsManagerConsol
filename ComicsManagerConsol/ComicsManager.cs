using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ComicsManagerConsol
{
    class ComicsManager
    {
        #region Class Variables

        private static List<string> comicDataList;
        private static string[] comicDataArray;
        private static string publisher;
        private static string title;
        private static string issue;
        private static string artist;
        private static string year;

        #endregion

        #region Properties

        public static List<string> ComicDataList
        {
            get { return comicDataList; }
            set { comicDataList = value; }
        }
        public static string[] ComicDataArray
        {
            get { return comicDataArray; }
            set { comicDataArray = value; }
        }
        public static string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public static string Title
        {
            get { return title; }
            set { title = value; }
        }
        public static string Issue
        {
            get { return issue; }
            set { issue = value; }
        }
        public static string Artist
        {
            get { return artist; }
            set { artist = value; }
        }
        public static string Year
        {
            get { return year; }
            set { year = value; }
        }

        #endregion

        #region ComicsManager Methods

        public static void LoadFile()   //  Hämtar listan från fil
        {
            ComicDataArray = File.ReadAllLines("ComicDataArray.txt");
            ComicDataList = new List<string>(ComicDataArray);
        }
        public static void ShowList()   //  Visar listan på skärmen
        {
            int index;
            Console.WriteLine("   Publisher:\t\tTitle:\t\t\tIssue:\tArtist:\t\tYear:\n");
            foreach (var comic in ComicDataList)
            {
                index = ComicDataList.IndexOf(comic) + 1;
                Console.WriteLine(index + ". " + comic);
            }
            Console.WriteLine("");
        }
        public static string InputInformation() //  Frågeställningsmetod
        {
            string input;
            const string formatPublisher = "{0,-15}";
            const string formatTitle = "{0,-20}";
            const string formatArtist = "{0,-10}";
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\n\t\t\t      Enter information:\n");

            do
            {
                Console.Write("\t\t\t  Publisher:    ");
                Publisher = Console.ReadLine();
            } while (Publisher.Length < 1);

            if (Publisher.Length < 15)
            {
                Publisher = string.Format(formatPublisher, Publisher);
            }

            do
            {
                Console.Write("\t\t\t  Title: \t");
                Title = Console.ReadLine();
            } while (Title.Length < 1);

            if (Title.Length < 20)
            {
                Title = string.Format(formatTitle, Title);
            }

            do
            {
                Console.Write("\t\t\t  Issue: \t");
                Issue = Console.ReadLine();
            } while (Issue.Length < 1 || Issue.Length > 4);

            do
            {
                Console.Write("\t\t\t  Artist: \t");
                Artist = Console.ReadLine();
            } while (Artist.Length < 1);

            if (Artist.Length < 10)
            {
                Artist = string.Format(formatArtist, Artist);
            }

            do
            {
                Console.Write("\t\t\t  Year: \t");
                Year = Console.ReadLine();
            } while (Year.Length < 1 || Year.Length > 4);

            return input = Publisher + "\t" + Title + "\t" + Issue + "\t" + Artist + "\t" + Year;
        }
        public static void AddToList()  //  Lägger till information i listan
        {
            ComicDataList.Add(InputInformation());

            Console.WriteLine("\n-----------------------------------------------------------------------------");
            Console.WriteLine("\t\t    Comic added, press key to continue.");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ReadKey();
        }
        public static void EditItemInList() //  Redigerar ett val i listan
        {
            int index;
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.Write("\t\t\t   Select comic to edit: ");
            index = Int32.Parse(Console.ReadLine()) - 1;

            ComicDataList.RemoveAt(index);
            ComicDataList.Insert(index, InputInformation());

            Console.WriteLine("\n-----------------------------------------------------------------------------");
            Console.WriteLine("\t\t    Comic edited, press key to continue.");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ReadKey();
        }
        public static void RemoveFromList() //  Tar bort ett val från listan
        {
            int input;
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.Write("\t\t\t   Select comic to remove: ");
            input = Int32.Parse(Console.ReadLine());
            ComicDataList.RemoveAt(input - 1);
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\t\t    Comic removed, press key to continue.");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ReadKey();
        }
        public static void SaveFile()   //  Sparar listan till fil
        {
            File.WriteAllLines(@"ComicDataArray.txt", ComicDataArray = ComicDataList.ToArray());
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\t\t    Comics saved, press key to continue.");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ReadKey();
        }

        #endregion
    }
}
