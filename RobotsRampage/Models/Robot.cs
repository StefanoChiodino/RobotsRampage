namespace RobotsRampage.Models
{
    using System.Runtime.Serialization;
    using RobotsRampage.Game;

    [DataContract]
    public class Robot : GameMovable
    {
        [DataMember]
        public Client Client { get; private set; }

        public Robot(Client client)
        {
            this.Client = client;
        }
    }
}