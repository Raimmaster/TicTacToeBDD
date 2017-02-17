using System.Collections.Specialized;

namespace ExamenUnoSoftware.Spec
{
    public class Player
    {
        public string name { get; set; }
        public char symbol { get; set; }

        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }
    }
}