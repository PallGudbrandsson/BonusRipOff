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

        public string kvittunn(List<int> vorur, List<double> magn)
        { // kvittun open
            string kvittun = null;
            double verd = 0;
            List<string> holder = new List<string>(); // stores all the important info
            string[] placeholder;
            for (int i = 0; i < vorur.Count; i++)
            {
                holder = conn.select("SELECT nafn,stk_verd FROM vorur WHERE ID = " + vorur[i]);

                placeholder = holder[0].Split(':'); // now [0] should be nafn and [1] should be verd_stk

                verd = Convert.ToDouble(holder[1]) * magn[i];

                kvittun += string.Format("{0} \t: {1} \t: {2}", holder[0], holder[1], verd);
            }
            return kvittun;
        } // kvittun close


        public void kaup(string afgID, List<int> vorurID, List<int> verd, List<double> magn, int kassi, int verslun, string staffID)
        { // kaup open
            string skil = null;
            summa = 0;

            for (int i = 0; i < vorurID.Count(); i++)
            { // for open
                summa += Convert.ToDouble(conn.select(string.Format("SELECT verd FROM vorur WHERE ID = {0};", vorurID[i].ToString()))[0]) * magn[i];
                skil += (string.Format("INSERT INTO kaup(afgID,kaupID,magn,afslattur)VALUES('{0}',{ 1},{ 2},{ 3}); \n", afgID,vorurID[i],(rand.Next(1, 6))));
            } // for close

            // 8 is for the length of the ID
            afgreidsla(afgID, kassi, verslun, staffID, kvittunn(vorurID, magn));
            conn.skipun(skil);

        } // kaup close

        private void afgreidsla(string ID, int kassi, int verslun, string staffID, string kvittun)
        { // afgreidsla open
            conn.skipun(string.Format("INSERT INTO afgreidsla(kassi,verslunID,dags,staff_kt,summa,afgreidslaTXT,adstod)VALUES({0},{1},NOW(),{2},{3},{4},{5},{6}",
                rand.Next(1,9),1,2410982069,summa,kvittun,0));
        } // afgreidsla close

        
    }
}
