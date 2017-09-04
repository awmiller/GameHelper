using GameHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHelper.Storage;

/// <summary>
/// A specialized GameHelper.Consumable that has a GamePiece contributor to track which model contributes this (for clean up purposes)
/// and provides an enumeration of different order types specified in the Infinity Rules.
/// </summary>
namespace InfinityHelper
{
    public class InfinityOrder : Consumable
    {

        #region Static members

        /// <summary>
        /// Constructor to be used by infinity classes only, since models are the primary order generators
        /// </summary>
        /// <param name="contributor"></param>
        /// <param name="T"></param>
        protected InfinityOrder(InfinityModel contributor, Types T) : base(true)
        {
            this.Contributor = contributor;
            this.OrderType = T;
        }

        /// <summary>
        /// Description of each type of order available
        /// </summary>
        public enum Types
        {
            Regular,
            Irregular
        }

        #endregion

        /// <summary>
        /// Local storage of originator.
        /// </summary>
        public InfinityModel Contributor
        {
            private set;
            get;
        }

        /// <summary>
        /// Local storage of enum selected
        /// </summary>
        public Types OrderType;

        /// <summary>
        /// retrieves a subset of models that can use this order. Primarily for getting the owner of an
        /// irregular model, but provides entry point for more complex behavior
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        //public List<InfinityModel> GetOrderableModels(InfinityPlayer iPlayer)
        //{
        //    //handle irregular case first
        //    if(OrderType == Types.Irregular)
        //    {
        //        return new List<InfinityModel> { (InfinityModel)Contributor };
        //    }
        //    //otherwise select all player's models
        //    else
        //    {
        //        return iPlayer.ArmyList.Select<InfinityModel, InfinityModel>();
        //    }
        //}

        public override string GetState()
        {
            throw new NotImplementedException();
        }

        public override GamePiece InflateFromState(IInflationNode inode)
        {
            throw new NotImplementedException();
        }
    }
}
