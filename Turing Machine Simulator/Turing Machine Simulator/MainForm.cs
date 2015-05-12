using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turing_Machine_Simulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            string MTB="";
            MTB += "1) L= {w | w is palindrome | w ∈ {0,1}*} \r\n";
            MTB += "2) L= {ww | w ∈ {a,b}^+} \r\n";
            MTB += "3) L= {a^i b^j c^k | i*j=k | i,j,k≥1} \r\n";
            MTB += "4) L= {0^2^n | n ≥ 0} \r\n";
            MTB += "5) Add 3 to a binary number.\r\n";
            MTB += "6) Convert from unary to binary.\r\n";
            MTB += "7) Convert from binary to unary.\r\n";
            MTB += "8) Unary multiplication.\r\n";
            MainTextBox.Text = MTB;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            SimulatorForm STM = new SimulatorForm(int.Parse(MainUpDown.Value.ToString()));
            this.Hide();
            STM.ShowDialog();
            this.Show();
        }
    }
}
