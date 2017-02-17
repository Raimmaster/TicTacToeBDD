using System.Collections.Generic;
using NUnit.Framework;

namespace ExamenUnoSoftware.Spec
{
    public interface IGameManager
    {
        void AddPlayer(string isAny);
        List<Player> GetPlayers();
    }
}