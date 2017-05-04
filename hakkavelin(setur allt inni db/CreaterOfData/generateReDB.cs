using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterOfData
{
    class generateReDB
    {
        Random rand = new Random();
        public string kaup(string afgID, int varaID)
        { // kaup open
            return string.Format("\n{'AfgID':'{0},\n'VaraID':'{1},\n'magn':{2},\n'afslattur':0},", afgID, varaID, (rand.Next(1, 6)));
        } // kaup close

        public string afgreidsla(string ID, int kassi, int verslun, int staffID)
        { // afgreidsla open





            return null;
        } // afgreidsla close
    }
}
