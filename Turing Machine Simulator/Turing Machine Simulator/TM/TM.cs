using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine_Simulator
{
    public abstract class TM : State_Node_And_Input
    {
        protected StringBuilder Input;
        protected char Blank = '\u25A1';

        protected State_Node_And_Input Current;
        public TM(ref string Input)
        {
            Input = Input.Insert(0, Blank.ToString());
            Input = Input.Insert(Input.Length, Blank.ToString());
            this.Input = new StringBuilder(Input);
            Current = new State_Node_And_Input();
            CurrentIndex = 1;
            CurrentNode = State_Node_And_Input.Node.q0;
            CurrentState = State_Node_And_Input.State.OnGoing;
            CurrentInput = Input;
        }
        public abstract State_Node_And_Input Step();

        protected void Check()
        {
            if (CurrentIndex == 0)
            {
                Input = Input.Insert(0, Blank.ToString());
                CurrentIndex++;
            }
            if (CurrentIndex == Input.Length - 1)
            {
                Input = Input.Insert(Input.Length, Blank.ToString());
            }

            CurrentInput = Input.ToString();
            Current.CurrentIndex = CurrentIndex;
            Current.CurrentNode = CurrentNode;
            Current.CurrentState = CurrentState;
            Current.CurrentInput = CurrentInput;
            
        }
    }
}
