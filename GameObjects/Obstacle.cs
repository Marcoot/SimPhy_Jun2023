using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SimPhy_Jun2022.GameObjects
{
    internal class Obstacle : SpriteGameObject
    {
        public Obstacle(Vector2 positionObstacle) : base("spr_obstacle")
        {
            this.position = positionObstacle;
        }
    }
}
