using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterOfData
{
    class generateOther
    {
        Random rand = new Random();

        public string ID(int length, List<string> taken)
        { // ID open
            string placeholder = null;
            char[] items = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                     'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                     '1','2','3','4','5','6','7','8','9','0','-','_','<','>','!','@','$','#','&','(',')','[',']','{','}','+','=','?'};

            while (true)
            { // while open
                for (int i = 0; i < length; i++)
                {
                    placeholder += items[rand.Next(0, 80)];
                }
                if (taken.Contains(placeholder)) // if the selected string is already used will almost never happen
                {
                    placeholder = null;
                }
                else
                {
                    taken.Add(placeholder);
                    return placeholder;
                }
            } // while close
        } // ID close
    }
}
