using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using SimPhy_Jun2021.GameObjects;
using SimPhy_Jun2022.GameObjects;

namespace SimPhy_Jun2022.GameObjects
{
    internal class Puck : SpriteGameObject
    {
        public  float frictionPuck = 0.99f;
        public int MaxVelocity = 250;
        public Puck(Vector2 startpositionPuck) : base("spr_puck")
        {
            this.position = startpositionPuck;
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

        public void BounceX()
        {
            velocity *= 0.9f;
            velocity.X = -velocity.X;
        }

        public void BounceY()
        {
            velocity *= 0.9f;
            velocity.Y = -velocity.Y;
        }

        public void bouncePusher()
        {
            //velocity *= 0.85f;
        }

        public void respawnPuck()
        {
            position = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2);

            velocity = new Vector2(GameEnvironment.Random.Next(-MaxVelocity, MaxVelocity), GameEnvironment.Random.Next(-MaxVelocity, MaxVelocity));  
        }

        public bool CircleCircleCollidesWith(Puck other)
        {
            return Vector2.Distance(this.position, other.position) < (this.Radius + other.Radius);
        }
    }
}
