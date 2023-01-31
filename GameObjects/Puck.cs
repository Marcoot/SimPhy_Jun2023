using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SimPhy_Jun2022.GameObjects
{
    internal class Puck : SpriteGameObject
    {
        public Puck(Vector2 startpositionPuck) : base("spr_puck")
        {
            this.position = startpositionPuck;
            origin = Center;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            
        }
    }
}
