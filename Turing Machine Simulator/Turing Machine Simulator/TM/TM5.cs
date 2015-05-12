using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine_Simulator
{
    public class TM5 : TM
    {
        public TM5(ref string Input):base(ref Input)
        {
        }

        public override State_Node_And_Input Step()
        {
            switch(CurrentNode)
            {
                case Node.q0:
                    if (Input[CurrentIndex] == '0' || Input[CurrentIndex] == '1')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q1;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q1:
                    if (Input[CurrentIndex] == '0')
                    {
                        Input[CurrentIndex] = '1';
                        CurrentIndex--;
                        CurrentNode = Node.q2;
                    }
                    else if (Input[CurrentIndex] == '1')
                    {
                        Input[CurrentIndex] = '0';
                        CurrentIndex--;
                        CurrentNode = Node.q3;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q2:
                    if (Input[CurrentIndex] == '0' || Input[CurrentIndex] == Blank)
                    {
                        Input[CurrentIndex] = '1';
                        CurrentIndex--;
                        CurrentNode = Node.q5;
                    }
                    else if (Input[CurrentIndex] == '1')
                    {
                        Input[CurrentIndex] = '0';
                        CurrentIndex--;
                        CurrentNode = Node.q4;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q3:
                    if (Input[CurrentIndex] == '0' || Input[CurrentIndex] == '1')
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q4;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
                        Input[CurrentIndex] = '0';
                        CurrentIndex--;
                        CurrentNode = Node.q4;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q4:
                    if (Input[CurrentIndex] == '1')
                    {
                        Input[CurrentIndex] = '0';
                        CurrentIndex--;
                    }
                    else if (Input[CurrentIndex] == '0' || Input[CurrentIndex] == Blank)
                    {
                        Input[CurrentIndex] = '1';
                        CurrentIndex--;
                        CurrentNode = Node.q5;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q5:
                    if (Input[CurrentIndex] == '0' || Input[CurrentIndex] == '1')
                    {
                        CurrentIndex--;
                    }
                    else if(Input[CurrentIndex] == Blank)
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
