using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace GSF_Promo
{
    class generateReDB
    {
        Random rand = new Random();
        dbconn conn = new dbconn();
        string items = null;
        
        int summa = 0;

        public string kaup(string afgID, List<int> vorurID, List<int> verd, List<double> magn, int kassi, int verslun, string staffID)
        { // kaup open
            items += "r.db('BonusRipOff').table('kaup').insert([";
            summa = 0;

            // ("{'afgID':'{0}','varaID':'{1}','magn':'{2},'afslattur':'{3}'",afgID,vorurID[i],magn[i],0)
            for (int i = 0; i < vorurID.Count; i++)
            { // for open
                if (magn[i] != 1)
                {
                    summa += Convert.ToInt32(magn[i] * verd[i]);
                }
                items += '{';
                items += string.Format("'afgID':'{0}','varaID':'{1}','magn':'{2}','afslattur':'0'", afgID, vorurID[i], magn[i]);
                items += "},";
            } // for close
            items = items.Remove(items.Length - 1);
            items += "]);";
            afgreidsla(afgID, kassi, verslun, staffID);
            
            return items;
        } // kaup close
        public void afgreidsla(string ID, int kassi, int verslun, string staffID)
        { // afgreidsla open
            items += "r.db('BonusRipOff').table('afgreidslur').insert([{";
            items += string.Format("'ID':'{0}','Kassi':'{1}','VerslunID':'{2}','Dags':'{3}','staffID':'{4}','summa':'{5}','adstod':'{6}'",ID,kassi,verslun, DateTime.Now,staffID,summa,0);
            items += "}]);";
        } // afgreidsla close
    }
}
