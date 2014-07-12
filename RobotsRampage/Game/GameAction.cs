namespace RobotsRampage.Game
{
    #region Using
    using RobotsRampage.Models;

    #endregion

    public abstract class GameAction
    {
        #region Fields
        public Client Client;
        public int Priority;
        #endregion

        #region Constructors and Destructors
        protected GameAction(int priority, Client client)
        {
            this.Priority = priority;
            this.Client = client;
        }
        #endregion

        public abstract void Execute(int elapsed);

        public abstract bool IsCompleted();
    }
}