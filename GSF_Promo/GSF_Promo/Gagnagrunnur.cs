using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSF_Promo
{
    class Gagnagrunnur
    {
        //Server: segir til um hvar serverinn er hýstur, hjá okkur er það localhost.
        private string server;
        //database: nafnið á gagnagrunninum sem verið er að nota.
        private string database;
        // uid:er MySQL notendanafnið
        private string uid;
        // password: er MySQL lykilorðið
        private string password;
        //tengistrengur: contains the connection string to connect to the database
        //and will be assigned to the connection variable.
        string tengistrengur = null;
        //fyrirspurn: innheldur viðeigandi fyrirspurn hverju sinni
        string fyrirspurn = null;

        MySqlConnection sqltenging; //Þetta er notað til þess að opna tengingu við gangagrunn.
        MySqlCommand nySQLskipun; //Þetta er notað til .ess að frmkvæma SQÆ fyrirspurnina.
        MySqlDataReader sqllesari = null;

        //Þessi aðferð tengir notanda við gangagrunninn,
        //þannig að þið breytið viðeigandi upplýingum sem a við.
        public void TengingVidGagnagrunn()
        {
            server = "tsuts.tskoli.is";
            database = "2410982069_kassakerfi";//þarf dbname
            uid = "2410982069";
            password = "pass.123";

            tengistrengur = "server= " + server + ";userid= " + uid + ";password= " + password + ";database= " + database;

            sqltenging = new MySqlConnection(tengistrengur);
        }

        //Open connection
        private bool OpenConnection()
        {
            try
            {
                sqltenging.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }


        //Þessi aðferð setur inn í töfluna í gagagrunninum.
        /* public void SettInnSqlToflu(string kt, string nafn, string netfang, string simi)
         {
             if (OpenConnection() == true)
             {
                 //query-in sem á að keyrast (má líka vera fyrir ofan if setninguna)
                 fyrirspurn = "INSERT INTO medlimur (id_medlimur, nafn, netfang, simanumer) VALUES ('" + kt + "','" + nafn + "','" + netfang + "','" + simi + "')";
                 //create command and assaign query(fyrirspurn) and connection (tenginguna) from the constructor
                 nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                 //ExevuteNonQuery: Used to execute a command that will not return any data.
                 nySQLskipun.ExecuteNonQuery();
                 CloseConnection();
             }
         }*/

        //Þessi aðferð finnur ákveðinn einstakling
        public string FinnaVoru(string id)
        {
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT ID,vorunafn,stk_verd,strikamerki FROM medlimur where id_medlimur ='" + id + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ":";
                    }
                }
                sqltenging.Close();
            }
            return lina;
        }

        //Þessi aðferð les úr SQL gagnagrunni allar færslu og birtir í viðeigandi töflu.
        public List<string> LesautSQLToflu()
        {
            List<string> Faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT id_medlimur, nafn, netfang, simanumer FROM medlimur";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                //ExecuteReader: USED to execute a command that will terurn 0 or more recorsds
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ":";
                    }
                    Faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return Faerslur;
            }
            return Faerslur;
        }

        //Herna er fundinn ákveðin einstaklingur og gögnin hans koma til baka
        /* public string[] FinnaAkvedinOgSkilaTilBaka(string id)
         {
             string[] gogn = new string[4];
             if (OpenConnection() == true)
             {
                 fyrirspurn = "SELECT id_medlimur, nafn, netfang, simanumer FROM medlimur where id_medlimur='" + id + "'";
                 nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                 sqllesari = nySQLskipun.ExecuteReader();
                 while (sqllesari.Read())
                 {
                     gogn[0] = sqllesari.GetValue(0).ToString();
                     gogn[1] = sqllesari.GetValue(1).ToString();
                     gogn[2] = sqllesari.GetValue(2).ToString();
                     gogn[3] = sqllesari.GetValue(3).ToString();
                 }
                 sqllesari.Close();
                 CloseConnection();
                 return gogn;

             }
             return gogn;
         }                                        */

        //Þessi aðferð lokar tengingu
        private bool CloseConnection()
        {
            try
            {
                sqltenging.Close();
                return true;
            }
            catch (MySqlException ex)
            {

                throw ex;
            }



        }
    }
}
