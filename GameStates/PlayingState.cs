using Microsoft.Xna.Framework;
using SimPhy_Jun2021.GameObjects;
using SimPhy_Jun2022.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject.GameStates
{
    class PlayingState : GameObjectList
    {
        private Pusher playerPusher;
        Wall leftWall, rightWall, upperWall, bottomWall;
        Puck puck;

        /// <summary>
        /// PlayState constructor which adds the different gamdddeobjects and lists in the correct order of drawing.
        /// </summary>
        public PlayingState()
        {
            playerPusher = new Pusher(new Vector2(400, 300), "spr_pusher");
            Add(playerPusher);

            leftWall = new Wall(Vector2.Zero, "spr_goal_wall");
            Add(leftWall);

            rightWall = new Wall(new Vector2(GameEnvironment.Screen.X - 50, 0), "spr_goal_wall");
            Add(rightWall);

            upperWall = new Wall(Vector2.Zero, "spr_horizontal_wall");
            Add(upperWall);

            bottomWall = new Wall(new Vector2(0, GameEnvironment.Screen.Y - 50), "spr_horizontal_wall");
            Add(bottomWall);

            puck = new Puck(new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 2));
            Add(puck);




            // Add initialization logic here
        }

        /// <summary>
        /// Updates the PlayState.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Add update logic here
            if (puck.Position.X <= 0 - puck.Width/2 || puck.Position.X >= GameEnvironment.Screen.X + puck.Width/2)
                puck.respawnPuck();

            if (puck.CollidesWith(leftWall) || puck.CollidesWith(rightWall))
                puck.BounceX();
            if (puck.CollidesWith(upperWall) || puck.CollidesWith(bottomWall))
                puck.BounceY();

        }
    }

}
