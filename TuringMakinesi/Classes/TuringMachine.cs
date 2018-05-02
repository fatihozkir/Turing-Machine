using System;
using System.Collections.Generic;

namespace TuringMakinesi.Classes
{
    public class TuringMachine
    {
        private List<State> states = new List<State>();
        private State currentState;
        private List<char> word = new List<char>();
        private int position = 1;
        private Movements lastMovement = Movements.R;
        private char symbol;
        public TuringMachine(List<State> states,List<char> word,char symbol)
        {
            this.states = states;
            this.word = word;
            currentState = states[0];
            this.symbol = symbol;
        }
        public void Start()
        {
            if (currentState!=null)
            {
                if (!currentState.isEnd() || lastMovement!=Movements.H)
                {
                    Write();
                    Transition trans = currentState.apply(getCurrentChar());
                    if (trans!=null)
                    {
                        modifyCharAtPosition(trans.getExchangeChar());
                        modifyPosition(trans.getMovement());
                        currentState = trans.getNextState();
                        lastMovement = trans.getMovement();
                    }
                    else
                    {
                        currentState = null;
                        Console.WriteLine("Doesn't recognize : " + getCurrentChar());
                    }
                    Start();
                }
                
            }
        }

        private void Write()
        {
             
            for (int i = 0; i < word.Count; i++)
            {
                string s = word[i].ToString();
                if (i==position)
                {
                    s = $"[{s}]";
                }
                
                Console.Write(s);
            }
            Console.WriteLine();
            string ayrac = "";
            for (int i = 0; i < word.Count+2; i++)
            {
                ayrac += '-';
            }
            Console.WriteLine(ayrac);
        }

        private char getCurrentChar()
        {
            if (position<0)
            {
                word.Insert(0, symbol);
                position = 0;
            }
            else if (position>=word.Count)
            {
                word.Add(symbol);
            }
            return word[position];
        }

        public void modifyCharAtPosition(char c)
        {
            word[position] = c;
        }
        private void modifyPosition(Movements movement)
        {
            position += (int)movement;
        }
    }
}
