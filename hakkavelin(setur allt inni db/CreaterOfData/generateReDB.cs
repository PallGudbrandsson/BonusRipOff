using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace CreaterOfData
{
    class generateReDB
    {
        Random rand = new Random();
        dbconn conn = new dbconn();
        StreamWriter rethinkDB = new StreamWriter("insert.txt");
        int summa = 0;


        public string kaup(string afgID, int varaID)
        { // kaup open
            return string.Format("\n{'AfgID':'{0},\n'VaraID':'{1},\n'magn':{2},\n'afslattur':0},", afgID, varaID, (rand.Next(1, 6)));
        } // kaup close

        public void kaup(string afgID, List<int> vorurID, List<int> verd, List<double> magn, int kassi, int verslun, string staffID)
        { // kaup open
            rethinkDB.WriteLine("r.db('BonusRipOff').table('kaup').insert([");

            summa = 0;

            // ("{'afgID':'{0}','varaID':'{1}','magn':'{2},'afslattur':'{3}'",afgID,vorurID[i],magn[i],0)
            for (int i = 0; i < vorurID.Count; i++)
            { // for open
                if (magn[i] != 1)
                {
                    summa += Convert.ToInt32(magn[i] * verd[i]);
                }
                rethinkDB.WriteLine(string.Format("{'afgID':'{0}','varaID':'{1}','magn':'{2},'afslattur':'{3}'}", afgID, vorurID[i], magn[i], 0));
            } // for close

            rethinkDB.WriteLine("]);");
            afgreidsla(afgID, kassi, verslun, staffID);
        } // kaup close
        public void afgreidsla(string ID, int kassi, int verslun, string staffID)
        { // afgreidsla open
            rethinkDB.WriteLine("r.db('BonusRipOff').table('afgreidslur').insert([");
            // {'ID':'{0}','Kassi':'{1}','VerslunID':'{2}','Dags':'{3}','staffID':'{4}','summa':'{5}','adstod':'{6}'}
            rethinkDB.WriteLine(string.Format("{'ID':'{0}','Kassi':'{1}','VerslunID':'{2}','Dags':'{3}','staffID':'{4}','summa':'{5}','adstod':'{6}'}",ID,kassi,verslun, DateTime.Now,staffID,summa,0));
            rethinkDB.WriteLine("]);");
        } // afgreidsla close
    }
}
