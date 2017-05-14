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
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            txt_strikamerki.Text = txt_strikamerki.Text + button.Text;
        }

        private void numpad_enter_Click(object sender, EventArgs e)
        {
            lst_vorur.Items.Add(txt_strikamerki.Text);
            txt_strikamerki.Clear();
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
    }
}
