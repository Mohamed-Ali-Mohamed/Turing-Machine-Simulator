using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine_Simulator
{
    public class TM6 : TM
    {
        public TM6(ref string Input):base(ref Input)
        {
        }

        public override State_Node_And_Input Step()
        {
            switch(CurrentNode)
            {
                case Node.q0:
                    if (Input[CurrentIndex] == '1')
                    {
                        Input[CurrentIndex] = 'y';
                        CurrentIndex--;
                        CurrentNode = Node.q1;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
                        Input[CurrentIndex] = '0';
                        CurrentState = State.Accepted;
                        CurrentNode = Node.qf;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q1:
                    if (Input[CurrentIndex] == Blank)
                    {
                        Input[CurrentIndex] = '#';
                        CurrentIndex--;
                        CurrentNode = Node.q2;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q2:
                    if (Input[CurrentIndex] == Blank)
                    {
                        Input[CurrentIndex] = '1';
                        CurrentIndex++;
                        CurrentNode = Node.q3;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q3:
                    if (Input[CurrentIndex] == '0' || Input[CurrentIndex] == '1')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == '#')
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q4;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q4:
                    if (Input[CurrentIndex] == 'y')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == '1')
                    {
                        Input[CurrentIndex] = 'y';
                        CurrentIndex--;
                        CurrentNode = Node.q5;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q7;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q5:
                    if (Input[CurrentIndex] == 'y')
                    {
                        CurrentIndex--;
                    }
                    else if(Input[CurrentIndex] == '#')
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q6;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q6:
                    if (Input[CurrentIndex] == Blank || Input[CurrentIndex] == '0')
                    {
                        Input[CurrentIndex] = '1';
                        CurrentIndex++;
                        CurrentNode = Node.q3;
                    }
                    else if (Input[CurrentIndex] == '1')
                    {
                        Input[CurrentIndex] = '0';
                        CurrentIndex--;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q7:
                    if (Input[CurrentIndex] == 'y')
                    {
                        Input[CurrentIndex] = Blank;
                        CurrentIndex--;
                    }
                    else if (Input[CurrentIndex] == '#')
                    {
                        Input[CurrentIndex] = Blank;
                        CurrentIndex--;
                        CurrentNode = Node.qf;
                        CurrentState = State.Accepted;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
            }
            
            Check();

            return Current;
        }
    }
}
