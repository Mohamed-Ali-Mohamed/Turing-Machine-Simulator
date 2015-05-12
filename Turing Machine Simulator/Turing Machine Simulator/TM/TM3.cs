using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine_Simulator
{
    public class TM3 : TM
    {
        public TM3(ref string Input):base(ref Input)
        {
        }

        public override State_Node_And_Input Step()
        {
            switch(CurrentNode)
            {
                case Node.q0:
                    if (Input[CurrentIndex] == 'a')
                    {
                        Input[CurrentIndex] = Blank;
                        CurrentIndex++;
                        CurrentNode = Node.q1;
                    }
                    else if (Input[CurrentIndex] == 'b')
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q8;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q1:
                    if (Input[CurrentIndex] == 'a')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == 'b')
                    {
                        Input[CurrentIndex] = 'B';
                        CurrentIndex++;
                        CurrentNode = Node.q2;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q2:
                    if (Input[CurrentIndex] == 'b')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == 'c')
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q3;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q3:
                    if (Input[CurrentIndex] == 'c')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q4;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q4:
                    if (Input[CurrentIndex] == 'c')
                    {
                        Input[CurrentIndex] = Blank;
                        CurrentIndex--;
                        CurrentNode = Node.q5;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q5:
                    if (Input[CurrentIndex] == 'c' || Input[CurrentIndex] == 'b')
                    {
                        CurrentIndex--;
                    }
                    else if(Input[CurrentIndex] == 'B')
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q6;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q6:
                    if (Input[CurrentIndex] == 'b')
                    {
                        Input[CurrentIndex] = 'B';
                        CurrentIndex++;
                        CurrentNode = Node.q2;
                    }
                    else if (Input[CurrentIndex] == 'c' || Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q7;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q7:
                    if (Input[CurrentIndex] == 'a')
                    {
                        CurrentIndex--;
                    }
                    else if (Input[CurrentIndex] == 'B')
                    {
                        Input[CurrentIndex] = 'b';
                        CurrentIndex--;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q0;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q8:
                    if (Input[CurrentIndex] == 'b')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
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
