using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHelper
{
    public abstract class Player : IInflatable
    {
        /// <summary>
        /// Public facing name for this player.
        /// </summary>
        public string Name;

        /// <summary>
        /// Faction, state, clan or otherwise cultural/geographic determination of army's origin
        /// </summary>
        public string Faction;

        /// <summary>
        /// Provide inflatable information about army list, order pool, orders remaining, name and faction.
        /// </summary>
        /// <returns></returns>
        public string GetState()
        {
            throw new NotImplementedException();
        }

        public abstract List<GamePiece> GetAllPieces();
    }
}
