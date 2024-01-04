using System;

namespace CatUp
{
    public abstract class State : IFormattable
    {
        public bool[] exitCondition { get; protected set; }

        public MachineData data;

        public State(MachineData data)
        {
            this.data = data;

            exitCondition = new bool[2];
        }

        public abstract void OnStateEnter();

        public abstract void OnStateExit();

        public abstract void Perform();

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return GetType().Name;
        }

        public static implicit operator string(State state)
        {
            return state.ToString() + state.GetHashCode();
        }
    }

}