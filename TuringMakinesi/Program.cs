using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuringMakinesi.Classes;

namespace TuringMakinesi
{
    class Program
    {
        static char symbol = '@';
        static void Main(string[] args)
        {
            Console.Write("Stringi Girin: ");
            List<char> word = Console.ReadLine().ToList();

            word.Insert(0, symbol);
            word.Add(symbol);

            State state1 = null, state2 = null, state3 = null;

            state1 = new State(new char[] { '1', '0', symbol },
                new Transition[] {
                    new Transition(new Lazy<State>(() => state1), '1', Movements.R) ,
                    new Transition(new Lazy<State>(() => state1), '0', Movements.R),
                    new Transition(new Lazy<State>(() => state2), symbol, Movements.L) }, false);

            state2 = new State(new char[] { '1', '0', symbol },
                new Transition[] {
                    new Transition(new Lazy<State>(() => state2), '0', Movements.L) ,
                    new Transition(new Lazy<State>(() => state3), '1', Movements.L),
                    new Transition(new Lazy<State>(() => state3), '1', Movements.L) }, false);

            state3 = new State(new char[] { '1', '0', symbol },
                new Transition[] {
                    new Transition(new Lazy<State>(() => state3), '1', Movements.L) ,
                    new Transition(new Lazy<State>(() => state3), '0', Movements.L),
                    new Transition(new Lazy<State>(() => state3), symbol, Movements.H) }, true);

            TuringMachine turingMachine = new TuringMachine(new List<State> { state1, state2, state3 }, word, symbol);
            turingMachine.Start();
            Console.ReadLine();
        }
    }
}
