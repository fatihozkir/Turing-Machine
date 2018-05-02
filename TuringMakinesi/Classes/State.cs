using System.Collections.Generic;

namespace TuringMakinesi.Classes
{
    public class State
    {
        private Dictionary<char, Transition> dict = new Dictionary<char, Transition>();
        private bool isEndState;
        public State(char[] letters,Transition[] transitions,bool isEndState)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                dict.Add(letters[i], transitions[i]);
            }
            this.isEndState = isEndState;
        }

        public Transition apply(char currentChar)
        {
            Transition transition = null;
            dict.TryGetValue(currentChar, out transition);
            return transition;
        }
        public bool isEnd()
        {
            return isEndState;
        }
    }
}
