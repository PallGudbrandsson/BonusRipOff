using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GSF_Promo
{
    class Programm
    {
        public void Main(List<int> voruID, List<int> verd, List<double> magn, int kassi, int verslun, string userkt) // all arguments will be taken in here
        {
            // there will be 200 products ID 0-199
            generateOther gen = new generateOther();
            dbconn conn = new dbconn();
            Random rand = new Random();
            main main = new main();
            
            string redb = null;
            string store = null; // to store the old redb data;

            //tarf ad generatea ID fyrst
            string id = gen.ID(8);
            MessageBox.Show(id);
            redb = main.Main(id, voruID, verd, magn, kassi, verslun, userkt);

            try
            {
                StreamReader read = new StreamReader("insert.txt");
                store = read.ReadToEnd();
                store += redb;
                read.Close();
            }
            catch (Exception)
            {
                
            }

            StreamWriter rethinkDB = new StreamWriter("insert.txt");
            rethinkDB.Write(store);
            rethinkDB.Close();
        }
    }
}