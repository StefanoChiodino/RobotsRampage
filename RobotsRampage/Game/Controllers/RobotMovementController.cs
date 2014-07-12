using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotsRampage.Game.Controllers
{
    using RobotsRampage.Game.Utility;

    public class RobotMovementController : MovementController
    {
        public const double MAX_SPEED = 10;

        public RobotMovementController(Vector2 position)
            : base(MAX_SPEED, position)
        {
        }
    }
}