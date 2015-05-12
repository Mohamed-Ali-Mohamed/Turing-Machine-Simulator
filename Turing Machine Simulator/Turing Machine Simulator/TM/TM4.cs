using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine_Simulator
{
    public class TM4 : TM
    {
        public TM4(ref string Input):base(ref Input)
        {
        }

        public override State_Node_And_Input Step()
        {
            switch(CurrentNode)
            {
                case Node.q0:
                    if (Input[CurrentIndex] == '0')
                    {
                        Input[CurrentIndex] = 'x';
                        CurrentIndex++;
                        CurrentNode = Node.q2;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q1:
                    if (Input[CurrentIndex] == '0')
                    {
                        Input[CurrentIndex] = 'x';
                        CurrentIndex++;
                        CurrentNode = Node.q2;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q5;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q2:
                    if (Input[CurrentIndex] == '0')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q3;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q3:
                    if (Input[CurrentIndex] == '0')
                    {
                        Input[CurrentIndex] = Blank;
                        CurrentIndex--;
                        CurrentNode = Node.q4;
                    }
                    else if (Input[CurrentIndex] == 'x')
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q6;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q4:
                    if (Input[CurrentIndex] == '0')
                    {
                        CurrentIndex--;
                    }
                    else if (Input[CurrentIndex] == 'x')
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q1;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q5:
                    if (Input[CurrentIndex] == 'x')
                    {
                        Input[CurrentIndex] = '0';
                        CurrentIndex--;
                    }
                    else if(Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q1;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q6:
                    if (Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex++;
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
