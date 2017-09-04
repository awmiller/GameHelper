namespace GameHelper
{
    /// <summary>
    /// A consumable token that tracks the ability to order units to do something.
    /// Usually used as a way to manage actions in a turn.
    /// </summary>
    public abstract class Consumable : GamePiece
    {
        /// <summary>
        /// control the ability to reuse this consumable
        /// </summary>
        public readonly bool Refreshable;

        /// <summary>
        /// track the state of this consumable
        /// </summary>
        public bool Spent = false;

        /// <summary>
        /// public ctor, refreshable is final
        /// </summary>
        /// <param name="refreshable"></param>
        public Consumable(bool refreshable)
        {
            this.Refreshable = refreshable;
        }
    }
}