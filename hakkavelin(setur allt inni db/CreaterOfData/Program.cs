using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreaterOfData
{
    class GeneranteREDB {
        

    } // Generation close
    class Program
    {
        static void Main(string[] args)
        {
            // there will be 200 products ID 0-199
            generateReDB redb = new generateReDB();
            generateSQL sql = new generateSQL();
            generateOther gen = new generateOther();

            StreamWriter rethinkDB = new StreamWriter("insert.txt");
            StreamWriter SQL = new StreamWriter("insert.sql");
            StreamReader read = new StreamReader("afrit.txt");
                        
            Random rand = new Random();
            List<string> taken = new List<string>();
            string[] placeholder;
            int vara = 0;
            string id = null;
            

            rethinkDB.WriteLine("r.db('BonusRipOff').table('afgreidslur').insert([");


            while (read.ReadLine() != null)
            {
                placeholder = read.ReadLine().Split(',');
            }


            while (true) // there are still products
            {
                id = gen.ID(8, taken);
                // vara = placeholder[x];
                rethinkDB.WriteLine(redb.kaup(id,vara));
                SQL.WriteLine(sql.kaup(id, vara));
            }

            rethinkDB.WriteLine("]);");


            // Generate an ID for the purchase
            // Add on the neccesari syntax to insert into the rethink db for products
            // Add all the purchased prcoducts. Expect a text file, format to be determined
            // Close the insert for the products
            // Open the insert for inserting the purchase information.
            // Add the info for inserting the purchase
            // Close the insert for the purchase
            // Start the next purchase

            rethinkDB.Close();
        }
    }
}
