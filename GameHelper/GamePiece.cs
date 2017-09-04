using GameHelper.Storage;

namespace GameHelper
{
    /// <summary>
    /// Represents a game piece that is inflatable from an XML/Text state and defines its own method for doing so
    /// T must be the type of the implementing class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GamePiece : IInflatable
    {
        public abstract string GetState();
        public abstract GamePiece InflateFromState(IInflationNode inode);

        /// <summary>
        /// Flag that signals whether this piece may be used in anyway. This should be true anytime a player
        /// can interact with the piece, i.e. not in a graveyard or removed from the game.
        /// </summary>
        /// <returns></returns>
        public virtual bool Playable()
        {
            //default behavior is to assume peices are deleted when not playable -> always true until object destroyed.
            return true;
        }
    }
}