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

        public string kaup(string afgID, int varaID)
        { // kaup open
            return (string.Format("INSERT INTO kaup(afgID,kaupID,magn,afslattur) VALUES ('{0}',{1},{2},{3});", afgID,varaID,(rand.Next(1, 6))));
        } // kaup close

        public string afgreidsla(string ID, int kassi, int verslun, int staffID)
        { // afgreidsla open





            return null;
        } // afgreidsla close
    }
}
