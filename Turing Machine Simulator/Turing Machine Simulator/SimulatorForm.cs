using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turing_Machine_Simulator.Properties;

namespace Turing_Machine_Simulator
{
    public partial class SimulatorForm : Form
    {
        TM TuringMachine;
        char Blank = '\u25A1';
        int RightCol = 15, LeftCol = 10, TM_Number;
        public SimulatorForm(int TM_Number)
        {
            InitializeComponent();
            TuringPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + TM_Number.ToString() + "Null");
            this.TM_Number = TM_Number;
            RightOutputGridView.RowCount = 1;
            LeftOutputGridView.RowCount = 1;
            FillTape(0, "");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            TuringPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + TM_Number.ToString() + "q0");
            string Input = InputTextBox.Text;
            switch(TM_Number)
            {
                case 1:
                    TuringMachine = new TM1(ref Input);
                    break;
                case 2:
                    TuringMachine = new TM2(ref Input);
                    break;
                case 3:
                    TuringMachine = new TM3(ref Input);
                    break;
                case 4:
                    TuringMachine = new TM4(ref Input);
                    break;
                case 5:
                    TuringMachine = new TM5(ref Input);
                    break;
                case 6:
                    TuringMachine = new TM6(ref Input);
                    break;
                case 7:
                    TuringMachine = new TM7(ref Input);
                    break;
                case 8:
                    TuringMachine = new TM8(ref Input);
                    break;
            }
            
            FillTape(1, Input);
            StartButton.Enabled = false;
            TimerUpDown.Enabled = InputTextBox.ReadOnly = StopButton.Enabled = StepButton.Enabled = FastRunButton.Enabled = FinishButton.Enabled = true;
            
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = true;
            TimerUpDown.Enabled = InputTextBox.ReadOnly = StopButton.Enabled = StepButton.Enabled = FastRunButton.Enabled = FinishButton.Enabled = false;
            timer1.Interval = int.Parse(TimerUpDown.Value.ToString());
            timer1.Stop();
        }
        private void FillTape(int index, string Input)
        {
            int j = 0;
            //Fill Right
            for (int i = index; i < Input.Length && j < RightCol; i++)
            {
                RightOutputGridView[j++, 0].Value = Input[i];
            }
            while (j < RightCol)
            {
                RightOutputGridView[j++, 0].Value = Blank;
            }
            //Fill Left
            j = LeftCol - 1;
            for (int i = index - 1; i >= 0 && j >= 0; i--)
            {
                LeftOutputGridView[j--, 0].Value = Input[i];
            }
            while (j >= 0)
            {
                LeftOutputGridView[j--, 0].Value = Blank;
            }
        }

        private void StepAction()
        {
            State_Node_And_Input S = TuringMachine.Step();
            if (timer1.Interval != 1)
            {
                TuringPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + TM_Number.ToString() + S.CurrentNode.ToString());
                FillTape(S.CurrentIndex, S.CurrentInput);
            }
            if (S.CurrentState == State_Node_And_Input.State.Accepted || S.CurrentState == State_Node_And_Input.State.Rejected)
            {
                if (timer1.Interval == 1)
                {
                    TuringPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + TM_Number.ToString() + S.CurrentNode.ToString());
                    FillTape(S.CurrentIndex, S.CurrentInput);
                }
                timer1.Interval = int.Parse(TimerUpDown.Value.ToString());
                timer1.Stop();
                TimerUpDown.Enabled = InputTextBox.ReadOnly = StopButton.Enabled = StepButton.Enabled = FastRunButton.Enabled = FinishButton.Enabled = false;

                MessageBox.Show(S.CurrentState.ToString());

                TuringPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + TM_Number.ToString() + "Null");

                FillTape(0, "");

                StartButton.Enabled = true;

            }
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            StepAction();
        }

        private void FastRunButton_Click(object sender, EventArgs e)
        {
            TimerUpDown.Enabled = StartButton.Enabled = StepButton.Enabled = FastRunButton.Enabled = FinishButton.Enabled = false;
            timer1.Interval = int.Parse(TimerUpDown.Value.ToString());
            timer1.Start();
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            StopButton.Enabled = true;
            TimerUpDown.Enabled = StartButton.Enabled = StepButton.Enabled = FastRunButton.Enabled = FinishButton.Enabled = false;
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StepAction();
        }


    }
}
