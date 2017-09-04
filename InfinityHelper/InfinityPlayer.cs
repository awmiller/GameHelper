using System.Collections.Generic;
using GameHelper;

namespace InfinityHelper
{
    public class InfinityPlayer : Player
    {

        /// <summary>
        /// subset of usable OrderPool;
        /// </summary>
        /// <returns></returns>
        public List<InfinityOrder> OrdersRemaining()
        {
            return OrderPool;
        }

        /// <summary>
        /// Total orders available as contributed by various factors
        /// </summary>
        public List<InfinityOrder> OrderPool;


        /// <summary>
        /// reset orders based on refreshable status
        /// </summary>
        public void RefreshOrderPool()
        {

        }
        
        /// <summary>
        /// Collection of GamePieces that are controlled by this player
        /// </summary>
        public List<InfinityModel> ArmyList;

        /// <summary>
        /// Subset of usable models
        /// </summary>
        /// <returns></returns>
        public virtual List<InfinityModel> PlayableUnits()
        {
            return ArmyList;
        }

        /// <summary>
        /// Implementation of library function
        /// </summary>
        /// <returns></returns>
        public override List<GamePiece> GetAllPieces()
        {
            List<GamePiece> inventory = new List<GamePiece>();

            inventory.AddRange(ArmyList);
            inventory.AddRange(OrderPool);

            return inventory;
        }
    }
}