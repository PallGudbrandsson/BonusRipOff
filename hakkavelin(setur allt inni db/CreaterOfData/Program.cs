using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreaterOfData
{
    class Program
    {
        static void Main() // all arguments will be taken in here
        {
            // there will be 200 products ID 0-199
            generateOther gen = new generateOther();
            dbconn conn = new dbconn();
            Random rand = new Random();
            main run = new main();

            string redb = null;
            string store = null; // to store the old redb data;




            while (true)
            {

                StreamReader read = new StreamReader("insert.txt");
                redb = read.ReadToEnd();
                store += redb;
                read.Close();

                StreamWriter rethinkDB = new StreamWriter("insert.txt");
                rethinkDB.Write(store);
                rethinkDB.Close();
            }
        }
    }
}
