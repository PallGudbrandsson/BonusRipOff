using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterOfData
{
    class generateSQL
    {
        Random rand = new Random();
        dbconn conn = new dbconn();
        double summa = 0;

        public string kvittunn(List<int> vorur,List<int> verd, List<double> magn)
        { // kvittun open
            string kvittun = null;
            List<string> holder = new List<string>(); // stores all the important info
            string[] placeholder;
            for (int i = 0; i < vorur.Count; i++)
            {
                holder = conn.select("SELECT vorunafn FROM vorur WHERE ID = " + vorur[i]);

                placeholder = holder[0].Split(':'); // now [0] should be nafn and [1] should be verd_stk
                
                kvittun += string.Format("{0} \t: {1} \t: {2}\n", holder[0], verd[i], (verd[i] * magn[i]));
            }
            return kvittun;
        } // kvittun close


        public void kaup(string afgID, List<int> vorurID, List<int> verd, List<double> magn, int kassi, int verslun, string staffID)
        { // kaup open
            summa = 0;
            for (int i = 0; i < vorurID.Count(); i++)
            { // for open
                summa += Convert.ToDouble(conn.select(string.Format("SELECT stk_verd FROM vorur WHERE ID = {0};", vorurID[i].ToString()))[0]) * magn[i];
                conn.skipun(string.Format("INSERT INTO kaup(afgID,varaID,magn,afslattur)VALUES('{0}',{1},{2},0);", afgID,vorurID[i],(rand.Next(1, 6))));
            } // for close

            string kvittun = kvittunn(vorurID,verd, magn);
            afgreidsla(afgID, kassi, verslun, staffID, kvittun);

        } // kaup close

        private void afgreidsla(string ID, int kassi, int verslun, string staffID, string kvittun)
        { // afgreidsla open
            conn.skipun("INSERT INTO kvittanir(afgID, kvittun) VALUES('" + ID + "','" + kvittun + "');");
            conn.skipun(string.Format("INSERT INTO afgreidsla(ID,kassi,verslun_ID,dags,staff_kt,summa)VALUES('{0}',{1},{2},NOW(),'{3}',{4});", ID, kassi, verslun, staffID, summa));
        } // afgreidsla close        
    }
}
