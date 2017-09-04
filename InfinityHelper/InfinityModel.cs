using System;
using GameHelper;
using GameHelper.Storage;
using System.Collections.Generic;
using System.Text;

namespace InfinityHelper
{
    public class InfinityModel : GamePiece
    {
        /// <summary>
        /// Public enumeration of possible troop types
        /// </summary>
        public enum TroopTypes
        {
            Regular,
            Irregular
        }

        public enum FactionTypes
        {
            Haqqislam,
            HassasinBahram
        }

        public enum ModelStates
        {
            Normal,
            Incapacitated,
            Impetuous,
            Dead
        }

        public ModelStates ModelState { protected set; get; }

        /// <summary>
        /// This instance's troop type selected from TroopTypes enum
        /// </summary>
        public TroopTypes TroopType { protected set; get; }

        /// <summary>
        /// List of factions this model can be used with
        /// </summary>
        public List<FactionTypes> UsableFactions;

        /// <summary>
        /// Basic CTOR establishes trooptype at least.
        /// </summary>
        /// <param name="troopT"></param>
        public InfinityModel(TroopTypes troopT)
        {
            TroopType = troopT;
        }

        /// <summary>
        /// Types of orders contributed to this model's player
        /// </summary>
        protected List<InfinityOrder.Types> OrderContribution;

        public List<InfinityOrder> ContributeOrders()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Definition of inflation string mechanic
        /// </summary>
        /// <returns></returns>
        public override string GetState()
        {
            return PackXmlNode(this).ToString();
        }

        public override GamePiece InflateFromState(IInflationNode inode)
        {
            if (inode is XmlNode)
            {
                throw new System.NotImplementedException();
            }
            else
            {
                throw new ArgumentException("Invalid node type to inflate InfinityModel from", nameof(inode));
            }
        }

        /// <summary>
        /// use information about the provided class to create an XML node for this object
        /// </summary>
        /// <param name="iModel"></param>
        /// <returns></returns>
        public static XmlNode PackXmlNode(InfinityModel iModel)
        {
            // create an xml node for this object
            XmlNode xnode = new XmlNode(iModel.GetType().ToString());

            //attach TroopType description
            xnode.Attach(new XmlNode(nameof(iModel.TroopType), iModel.TroopType.ToString()));

            //attach all contributions
            foreach (InfinityOrder.Types t in iModel.OrderContribution)
            {
                xnode.Attach(new XmlNode(nameof(iModel.OrderContribution), t.ToString()));
            }

            //attach all factions
            foreach (FactionTypes f in iModel.UsableFactions)
            {
                xnode.Attach(new XmlNode(nameof(iModel.UsableFactions), f.ToString()));
            }

            return xnode;
        }
    }
}