using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SimPhy_Jun2022.GameObjects
{
    internal class Puck : SpriteGameObject
    {
        public  float frictionPuck = 0.99f;
        public Puck(Vector2 startpositionPuck) : base("spr_puck")
        {
            this.position = startpositionPuck;
            origin = Center;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            velocity *= frictionPuck;

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.IsKeyDown(Keys.A))
                velocity.X -= 10;
            if (inputHelper.IsKeyDown(Keys.D))
                velocity.X += 10;
            if (inputHelper.IsKeyDown(Keys.W))
                velocity.Y -= 10;
            if (inputHelper.IsKeyDown(Keys.S))
                velocity.Y += 10;

            /*if(!inputHelper.IsKeyDown(Keys.A) && !inputHelper.IsKeyDown(Keys.D) && !inputHelper.IsKeyDown(Keys.W) && !inputHelper.IsKeyDown(Keys.S))
                velocity = Vector2.Zero;*/
        }
    }
}
