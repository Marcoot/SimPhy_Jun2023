using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SimPhy_Jun2022.GameObjects
{
    internal class Wall : SpriteGameObject
    {
        public Wall(Vector2 positionWall, string assetName) : base(assetName)
        {
            this.position = positionWall;
        }
    }
}
