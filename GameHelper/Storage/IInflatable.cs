namespace GameHelper.Storage
{
    public interface IInflatable
    {
        /// <summary>
        /// Required for printing and storing game state
        /// </summary>
        /// <returns>string representing state information</returns>
        string GetState();

        /// <summary>
        /// Inflate an instance of the implementing interface
        /// </summary>
        /// <param name="inode"></param>
        /// <returns></returns>
        GamePiece InflateFromState(IInflationNode inode);
    }
}