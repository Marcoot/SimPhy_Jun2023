using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SimPhy_Jun2022.GameObjects
{
    class EnemyPusher : SpriteGameObject
    {
        public EnemyPusher(Vector2 startPositionEnemy, Vector2 startVelocityEnemy) : base("spr_pusher")
        {
            this.position = startPositionEnemy;
            this.velocity = startVelocityEnemy;
            origin = Center;
        }
        public float Radius
        {
            get
            {
                return Width / 2;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(position.Y <= 100 || position.Y >= GameEnvironment.Screen.Y - 100)
            {
                velocity.Y = -velocity.Y;
            }
        }
    }
}
