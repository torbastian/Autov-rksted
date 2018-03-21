using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoværksted
{
    class Menu
    {
        public byte MenuSelector(MenuItem[] MenuArray, string CurrentMenu)
        {   //opret variable
            bool accept = false;
            byte selected = 0;

            //Skriv navnet på menuen, og nuværende menu
            Console.WriteLine(CurrentMenu);
            WriteMenu(MenuArray, selected);

            //Så længe accept er false
            while (!accept)
            {
                //Læs tastetryk
                ConsoleKey kchar = Console.ReadKey().Key;

                //Hvis tastetryket er UpArrow selected - 1, hvis der er DownArrow Selected + 1, hvis det er enter Accept = true
                if (kchar == ConsoleKey.UpArrow && selected > 0)
                    selected--;
                else if (kchar == ConsoleKey.DownArrow && selected < MenuArray.Length - 1)
                    selected++;
                else if (kchar == ConsoleKey.Enter)
                    accept = true;

                //Rengør consolen, skriv den nuværende menu, og navnet
                Console.Clear();
                Console.WriteLine(CurrentMenu);
                WriteMenu(MenuArray, selected);
            }

            //Rengør consolen, retuner valgte menuItem
            Console.Clear();
            return selected;
        }

        static void WriteMenu(MenuItem[] mlist, byte selected)
        {
            //Gå igennem menuen, hvis den nuværende index er == selected, set selected = true, ellers false, skriv menuItem på index
            for (int i = 0; i < mlist.Length; i++)
            {
                if (i == selected)
                    mlist[i].selected = true;
                else
                    mlist[i].selected = false;

                Console.WriteLine(mlist[i].ToString());
            }
        }
    }
    class MenuItem
    {
        public string item;
        public bool selected;

        public MenuItem() { }
        public MenuItem(string i)
        {
            item = i;
            selected = false;
        }

        public override string ToString()
        {   //Override ToString() så den viser om menuItem er selected
            if (selected)
                return " > " + item;
            else
                return item;
        }
    }
}
