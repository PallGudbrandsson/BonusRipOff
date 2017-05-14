using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreaterOfData
{
    class GeneranteREDB
    {


    } // Generation close
    class Program
    {
        static void Main() // all arguments will be taken in here
        {
            // there will be 200 products ID 0-199
            generateOther gen = new generateOther();
            dbconn conn = new dbconn();
            Random rand = new Random();
            main run = new main();
            

            int a = 0;
            int len = 0;
            string redb = null;
            string store = null; // to store the old redb data;
            List<string> receve = new List<string>();

            string ID = null;
            List<int> vorur = new List<int>();
            List<int> verd = new List<int>();
            List<double> magn = new List<double>();



            while (true)
            {
                Console.WriteLine(a);
                // for loop to create a purchase
                len = rand.Next(10, 100);
                ID = gen.ID(8);

                for (int i = 0; i < len; i++)
                {
                    vorur.Add(rand.Next(1, 201));
                    receve = conn.select("SELECT stk_verd FROM vorur WHERE ID = " + vorur[i]);
                    verd.Add(Convert.ToInt32(receve[0]));
                    magn.Add(rand.Next(1, 15));
                }

                redb += run.Main(ID, vorur, verd, magn, 1, 1, "2410982069");

                a++;

                StreamReader read = new StreamReader("insert.txt");
                store = read.ReadToEnd();
                store += redb;
                read.Close();

                StreamWriter rethinkDB = new StreamWriter("insert.txt");
                rethinkDB.Write(store);
                rethinkDB.Close();
            }
        }
    }
}
