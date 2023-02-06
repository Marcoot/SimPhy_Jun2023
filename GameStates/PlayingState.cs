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
        EnemyPusher enemyPusher;
        Wall leftWall, rightWall, upperWall, bottomWall;
        Puck puck;

        /// <summary>
        /// PlayState constructor which adds the different gamdddeobjects and lists in the correct order of drawing.
        /// </summary>
        public PlayingState()
        {
            playerPusher = new Pusher(new Vector2(400, 300), "spr_pusher");
            Add(playerPusher);

            enemyPusher = new EnemyPusher(new Vector2(GameEnvironment.Screen.X - 150, GameEnvironment.Screen.Y / 2), new Vector2(0,-150));
            Add(enemyPusher);

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
            

            if (puck.CircleCircleCollidesWith(playerPusher))
            {
                //kijkt naar positie van pusher en de puck
                float distancePlayerBall = Vector2.Distance(playerPusher.Position, puck.Position);
                //kijkt naar de radius van de 2 (ook afstand)
                float dOverlap = playerPusher.Radius + puck.Radius - distancePlayerBall;
                //checkt of afstand langer is dan de overlap tussen de pusher en de puck
                Vector2 collisionNormal = playerPusher.Position - puck.Position;

                collisionNormal.Normalize();

                playerPusher.Position += collisionNormal * dOverlap / 2;
                puck.Position -= collisionNormal * dOverlap / 2;

                //float totalInverseMass = playerPusher.InverseMass + puck.InverseMass;
                //Vector2 velocityChange = (1 + bounceFactor) * Vector2.Dot(playerPusher.Velocity, collisionNormal) * collisionNormal;
                //velocityChange /= totalInverseMass;

                //playerPusher.Velocity -= velocityChange * playerPusher.InverseMass;
                //puck.Velocity += velocityChange * puck.InverseMass;
                puck.Velocity = -puck.Velocity;
                puck.bouncePusher();
            }

            if (puck.CircleCircleCollidesWith(enemyPusher))
            {
                //kijkt naar positie van pusher en de puck
                float distancePlayerBall = Vector2.Distance(enemyPusher.Position, puck.Position);
                //kijkt naar de radius van de 2 (ook afstand)
                float dOverlap = enemyPusher.Radius + puck.Radius - distancePlayerBall;
                //checkt of afstand langer is dan de overlap tussen de pusher en de puck
                Vector2 collisionNormal = enemyPusher.Position - puck.Position;

                collisionNormal.Normalize();

                enemyPusher.Position += collisionNormal * dOverlap / 2;
                puck.Position -= collisionNormal * dOverlap / 2;

                //float totalInverseMass = playerPusher.InverseMass + puck.InverseMass;
                //Vector2 velocityChange = (1 + bounceFactor) * Vector2.Dot(playerPusher.Velocity, collisionNormal) * collisionNormal;
                //velocityChange /= totalInverseMass;

                //playerPusher.Velocity -= velocityChange * playerPusher.InverseMass;
                //puck.Velocity += velocityChange * puck.InverseMass;
                puck.Velocity = -puck.Velocity;
                puck.bouncePusher();
            }



        }
    }

}
