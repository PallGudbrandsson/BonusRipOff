using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreaterOfData
{
    class main
    {
        public string Main(string afgID, List<int> vorurID, List<int> verd, List<double> magn, int kassi, int verslun, string staffID)
        {
            // there will be 200 products ID 0-199
            generateReDB redb = new generateReDB();
            generateSQL sql = new generateSQL();
            string all = null;

            // here the rethink DB insertion comes
            all = (redb.kaup(afgID, vorurID, verd, magn, kassi, verslun, staffID));

            // generate the sql data
            sql.kaup(afgID, vorurID, verd, magn, kassi, verslun, staffID);

            return all;
        }
    }
}
