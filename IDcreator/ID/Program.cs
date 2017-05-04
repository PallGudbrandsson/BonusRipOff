using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<string> taken = new List<string>();

            int length = 8; // represents the length of the string.
            string placeholder = null;
            char[] items = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                     'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                     '1','2','3','4','5','6','7','8','9','0','-','_','<','>','!','@','$','#','&','(',')','[',']','{','}','+','=','?'};

            while (true)
            {
                for (int i = 0; i < length; i++)
                {
                    placeholder += items[rand.Next(0, 80)];
                }
                if (taken.Contains(placeholder)) // if the selected string is already used will almost never happen
                {
                    //nothing can happed due to the fact that the string is already used
                }
                else
                {
                    taken.Add(placeholder);
                    Console.WriteLine(placeholder);
                }
                placeholder = null;
            }
        }
    }
}
