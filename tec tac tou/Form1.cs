using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tec_tac_tou
{
    public partial class Form1 : Form
    {
        string player1 = null;
        string player2 = null;
        int t1 = 0;
        int t2 = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private string threebuttons(Button a,Button b,Button c)
        {
            if (a.Text == b.Text && b.Text == c.Text)
            {
                a.ForeColor = Color.DarkRed;
                b.ForeColor = Color.DarkRed;
                c.ForeColor = Color.DarkRed;
                return a.Text;
            }
            else
                return "";
        }
        private void checkwinner()
        {
            string result = threebuttons(button1, button2, button3);
            if (result == "")
                result = threebuttons(button4, button5, button6);
            if (result == "")
                result = threebuttons(button7, button8, button9);
            if (result == "")
                result = threebuttons(button1, button4, button7);
            if (result == "")
                result = threebuttons(button2, button5, button8);
            if (result == "")
                result = threebuttons(button3, button6, button9);
            if (result == "")
                result = threebuttons(button1, button5, button9);
            if (result == "")
                result = threebuttons(button3, button5, button7);
            if (result == "X")
            {
                timer1.Stop();
                timer2.Stop();
                lblp1.BackColor = Color.Green;
                lblp2.BackColor = Color.Gold;
                MessageBox.Show("Player 1 is winner","Game Result");
                return;
            }
            else if (result == "O")
            {
                timer1.Stop();
                timer2.Stop();
                lblp1.BackColor = Color.Green;
                lblp2.BackColor = Color.Gold;
                MessageBox.Show("Player 2 is winner","Game Result");
                return;
            }
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Button btn = control as Button;
                if (btn.Text == "X" || btn.Text == "O")
                {
                    result = "DRAW";
                    continue;
                }
                else
                {
                    result = "";
                    return;
                }
            }
            if (result == "DRAW")
            {
                timer1.Stop();
                timer2.Stop();
                lblp1.BackColor = Color.Green;
                lblp2.BackColor = Color.Gold;
                MessageBox.Show("DRAW ( No One won )", "Game Result");

            }
        }
        private void button_click(object sender, EventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Button btne = control as Button;
                if (btne.ForeColor == Color.DarkRed)
                    return;
            }
            Button btnclick = sender as Button;
            if (btnclick.Text == "X" || btnclick.Text == "O")
                return;
            if (player1 == null)
            {
                btnclick.Text = "X";
                player1 = "X";
                player2 = null;
                timer1.Stop();
                lblp1.BackColor = Color.Green;
                timer2.Start();
                checkwinner();
                return;
            }
            if (player2 == null)
            {
                btnclick.Text = "O";
                player2 = "O";
                player1 = null;
                timer2.Stop();
                lblp2.BackColor = Color.Gold;
                timer1.Start();
                checkwinner();
                return;
            }
        }
        private void btnnewgame_Click(object sender, EventArgs e)
        {
            int i = 9;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Button btng = control as Button;
                btng.Text = i--.ToString();
                if (btng.ForeColor == Color.DarkRed)
                    btng.ForeColor = Color.Black;
            }
            player1 = null;
            player2 = null;
            timer1.Start();
            timer2.Stop();
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t1 % 2 == 0)
                lblp1.BackColor = Color.LightGreen;
            else
                lblp1.BackColor = Color.Green;
            t1++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (t2 % 2 == 0)
                lblp2.BackColor = Color.Yellow;
            else
                lblp2.BackColor = Color.Gold;
            t2++;
        }
    }
}
