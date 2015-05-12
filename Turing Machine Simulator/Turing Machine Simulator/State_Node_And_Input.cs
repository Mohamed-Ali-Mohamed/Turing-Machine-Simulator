using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine_Simulator
{
    public class State_Node_And_Input
    {
        public enum Node { q0, q1, q2, q3, q4, q5, q6, q7, q8, q9, qf };
        public enum State { Accepted, Rejected, OnGoing };
        public Node CurrentNode;
        public State CurrentState;
        public string CurrentInput;
        public int CurrentIndex;
    }
}
