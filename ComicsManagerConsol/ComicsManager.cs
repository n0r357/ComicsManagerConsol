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
            string publisher;
            string title;
            string issue;
            string artist;
            string year;
            string input;
            const string formatPublisher = "{0,-15}";
            const string formatTitle = "{0,-20}";
            const string formatArtist = "{0,-10}";

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\n\t\t\t      Enter information:\n");

            do
            {
                Console.Write("\t\t\t  Publisher:    ");
                publisher = Console.ReadLine();
            } while (publisher.Length < 1);

            if (publisher.Length < 15)
            {
                publisher = string.Format(formatPublisher, publisher);
            }

            do
            {
                Console.Write("\t\t\t  Title: \t");
                title = Console.ReadLine();
            } while (title.Length < 1);

            if (title.Length < 20)
            {
                title = string.Format(formatTitle, title);
            }

            do
            {
                Console.Write("\t\t\t  Issue: \t");
                issue = Console.ReadLine();
            } while (issue.Length < 1 || issue.Length > 4);

            do
            {
                Console.Write("\t\t\t  Artist: \t");
                artist = Console.ReadLine();
            } while (artist.Length < 1);

            if (artist.Length < 10)
            {
                artist = string.Format(formatArtist, artist);
            }

            do
            {
                Console.Write("\t\t\t  Year: \t");
                year = Console.ReadLine();
            } while (year.Length < 1 || year.Length > 4);

            return input = publisher + "\t" + title + "\t" + issue + "\t" + artist + "\t" + year;
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
