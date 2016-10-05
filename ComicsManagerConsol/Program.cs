using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsManagerConsol
{
    class Program
    {
        static void Main(string[] args)
        {
            ComicsManager.LoadFile();
            do
            {
                Menu.MainMenu();
            } while (!Menu.IsProgramOver);
        }
    }
}
