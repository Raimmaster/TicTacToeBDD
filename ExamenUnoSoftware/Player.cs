using System.Collections.Specialized;

namespace ExamenUnoSoftware.Spec
{
    public class Player
    {
        public string name { get; set; }
        public string symbol { get; set; }

        public void SetSymbol(string symbol)
        {
            this.symbol = symbol;
        }
    }
}