using System;

namespace TuringMakinesi.Classes
{
    public class Transition
    {
        public Tuple<Lazy<State>, char, Movements> transition;
        public Transition(Lazy<State> state,char exchangeChar,Movements move)
        {
            transition = new Tuple<Lazy<State>, char, Movements>(state, exchangeChar,move);
        }
        public State getNextState()
        {
            return transition.Item1.Value;
        }
        public char getExchangeChar()
        {
            return transition.Item2;
        }
        public Movements getMovement()
        {
            return transition.Item3;
        }
    }
}
