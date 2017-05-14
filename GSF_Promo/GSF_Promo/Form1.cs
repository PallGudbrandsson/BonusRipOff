using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSF_Promo
{
    public partial class Form1 : Form
    {
        // class calling
        dbconn conn = new dbconn();
        Random rand = new Random();
        Programm pro = new Programm();

        // variables
        List<string> names = new List<string>(); // nofn a vorunni. Kemur lengst til vinstri
        List<int> voruID = new List<int>(); // heldur utanum oll IDina vorunum
        List<int> stk_verd = new List<int>(); // verd per stk. Kemur a eftir nafninu
        List<double> magn = new List<double>(); // magn a vorunni. Kemur a eftir stk_verd

        public Form1()
        {
            InitializeComponent();
            // for stillingar a userum. Gert er rad fyrir ad Palli er ad afgreida
            label_user.Text = "Bitch";
            label_kt.Text = "2410982069";
            label_verd.Text = "0";

        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            txt_strikamerki.Text = txt_strikamerki.Text + button.Text;
        }

        private void numpad_enter_Click(object sender, EventArgs e)
        {
            string mottaka = null; // tekur a moti gognunum ur gagnagrunn
            string[] work; // tekur vid gognunum a vinnuhafara formi
            mottaka = conn.select("SELECT vorunafn, stk_verd, ID FROM vorur WHERE strikamerki = " + txt_strikamerki.Text + ";")[0]; 
            txt_strikamerki.Clear();

            work = mottaka.Split(':');

            names.Add(work[0]);
            stk_verd.Add(Convert.ToInt32(work[1]));
            magn.Add(rand.Next(1,11));
            
              
        }

        private void btn_eyda_Click(object sender, EventArgs e)
        { // kann ekki a lisbox. Lattu tennan takka eyda sidustu linu ur listboxinu

        }

        private void btn_skila_Click(object sender, EventArgs e)
        { // setja magnid a sidustu innsetningu i listboxid i -1

        }

        private void btn_afskra_Click(object sender, EventArgs e)
        { // log out takki. Hofum ekki tima til ad klara login kerfi tannig ad tetta verdur ad duga
            Application.Exit();
        }

        private void btn_lokaSkyrslu_Click(object sender, EventArgs e)
        {
            /*
                List<string> names = new List<string>(); // nofn a vorunni. Kemur lengst til vinstri
                ID
                List<int> stk_verd = new List<int>(); // verd per stk. Kemur a eftir nafninu
                List<double> magn = new List<double>(); // magn a vorunni. Kemur a eftir stk_verd
             */
            // klarar tessa afgreidslu. ToDo fyrir tetta method:
            // senda alla lista til palla
            pro.Main(voruID, stk_verd,magn, 1, 1, label_kt.Text);
            // hreinsa alla lista
            // hreinsa allar verd breytur og annad slikt.
            MessageBox.Show("Heppnadist");
        }
    }
}
