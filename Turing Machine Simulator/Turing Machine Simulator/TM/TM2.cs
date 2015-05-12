using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine_Simulator
{
    public class TM2 : TM
    {
        public TM2(ref string Input):base(ref Input)
        {

        }

        public override State_Node_And_Input Step()
        {
            switch(CurrentNode)
            {
                case Node.q0:
                    if (Input[CurrentIndex] == 'a')
                    {
                        Input[CurrentIndex] = 'A';
                        CurrentIndex++;
                        CurrentNode = Node.q1;
                    }
                    else if (Input[CurrentIndex] == 'b')
                    {
                        Input[CurrentIndex] = 'B';
                        CurrentIndex++;
                        CurrentNode = Node.q1;
                    }
                    else if (Input[CurrentIndex] == 'A' || Input[CurrentIndex] == 'B')
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q4;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q1:
                    if (Input[CurrentIndex] == 'a' || Input[CurrentIndex] == 'b')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == 'A' || Input[CurrentIndex] == 'B' || Input[CurrentIndex] == Blank)
                    {
                        CurrentIndex--;
                        CurrentNode = Node.q2;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q2:
                    if (Input[CurrentIndex] == 'a')
                    {
                        Input[CurrentIndex] = 'A';
                        CurrentIndex--;
                        CurrentNode = Node.q3;
                    }
                    else if (Input[CurrentIndex] == 'b')
                    {
                        Input[CurrentIndex] = 'B';
                        CurrentIndex--;
                        CurrentNode = Node.q3;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q3:
                    if (Input[CurrentIndex] == 'a' || Input[CurrentIndex] == 'b')
                    {
                        CurrentIndex--;
                    }
                    else if (Input[CurrentIndex] == 'A' || Input[CurrentIndex] == 'B')
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q0;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q4:
                    if (Input[CurrentIndex] == 'A')
                    {
                        Input[CurrentIndex] = 'a';
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
                        CurrentNode = Node.q5;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q5:
                    if (Input[CurrentIndex] == 'a')
                    {
                        Input[CurrentIndex] = 'x';
                        CurrentIndex++;
                        CurrentNode = Node.q7;
                    }
                    else if (Input[CurrentIndex] == 'b')
                    {
                        Input[CurrentIndex] = 'x';
                        CurrentIndex++;
                        CurrentNode = Node.q6;
                    }
                    else if (Input[CurrentIndex] == 'y')
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q9;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q6:
                    if (Input[CurrentIndex] == 'a' || Input[CurrentIndex] == 'b' || Input[CurrentIndex] == 'y')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == 'B')
                    {
                        Input[CurrentIndex] = 'y';
                        CurrentIndex--;
                        CurrentNode = Node.q8;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q7:
                    if (Input[CurrentIndex] == 'a' || Input[CurrentIndex] == 'b' || Input[CurrentIndex] == 'y')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == 'A')
                    {
                        Input[CurrentIndex] = 'y';
                        CurrentIndex--;
                        CurrentNode = Node.q8;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q8:
                    if (Input[CurrentIndex] == 'a' || Input[CurrentIndex] == 'b' || Input[CurrentIndex] == 'y')
                    {
                        CurrentIndex--;
                    }
                    else if (Input[CurrentIndex] == 'x')
                    {
                        CurrentIndex++;
                        CurrentNode = Node.q5;
                    }
                    else
                    {
                        CurrentState = State.Rejected;
                    }
                    break;
                case Node.q9:
                    if (Input[CurrentIndex] == 'y')
                    {
                        CurrentIndex++;
                    }
                    else if (Input[CurrentIndex] == Blank)
                    {
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
