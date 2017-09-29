using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class GoombaEnemy : IEnemy
    {
        public Vector2 Location { get; set; }       
        public Rectangle Position {get; set;}
        public Texture2D Texture { get; set; }
        public bool IsStomped { get; set; }
        public bool IsKilled { get; set; }
        public bool IsKilledRight { get; set; }
        public bool IsKilledLeft { get; set; }
        public bool IsDead { get; set; }
        public int Collision { get; set; }
        //private Camera cam;
        private int Rows = 1;       
        private int Columns = 3;
        private int currentFrame = 1; 
        private int totalFrame = 3;
        private int delay = 0;
        private int disappearDelay = 0;
        private Vector2 posChange;
        private Vector2 move;
        private int upCount = 0;
        private int downCount = 0;
        private int upMaxCount = 10;
        private int downMaxCount = 100;
        private Boolean brickMarioCollision;
        public GoombaEnemy(Texture2D txt, Vector2 pos)
        {
            Collision = 0;
            Texture = txt;
            Location = pos;
            posChange = new Vector2(0, 0);
            move = new Vector2(-1, 0);
            IsStomped = false;
            IsKilled = false;
            IsKilledRight = false;
            IsKilledLeft = false;
            IsDead = false;
        }
        public void Update()
        {
                Location += posChange;
                posChange.X = 0;
                posChange.Y = 0;

                Location += move;

                Position = new Rectangle((int)Location.X, (int)Location.Y, Texture.Width / Columns, Texture.Height / Rows);
                delay++;
                if (delay == 10)
                {
                    if (IsKilledRight)
                    {
                        if ((upCount < upMaxCount) && (downCount < downMaxCount))
                        {
                            move = new Vector2(1, -1);
                            upCount++;
                        }
                        else if ((downCount < downMaxCount) && (upCount >= upMaxCount))
                        {
                            move = new Vector2(1, 4);
                            downCount++;
                        }
                        else
                        {
                            IsDead = true;
                        }
                    }
                    if (IsKilledLeft)
                    {
                        if ((upCount < upMaxCount) && (downCount < downMaxCount))
                            {
                                move = new Vector2(-1, -1);
                                upCount++;
                            }
                            else if ((downCount < downMaxCount) && (upCount >= upMaxCount))
                            {
                                move = new Vector2(-1, 4);
                                downCount++;
                            }
                            else
                            {
                                IsDead = true;
                            }
                    }
                    if (!IsDead)
                    {
                        currentFrame++;
                        if (currentFrame == totalFrame)
                            currentFrame = 1;
                    }
                    else
                    {
                        currentFrame = 0;
                        move = new Vector2(0, 0);
                        disappearDelay++;
                        if (disappearDelay == 3)
                        {
                            IsStomped = false;
                        }
                    }
                    delay = 0;
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                int width = Texture.Width / Columns;
                int height = Texture.Height / Rows;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;
                Position = new Rectangle((int)Location.X, (int)Location.Y, width, height);

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                if (IsKilledRight)
                {
                    spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipVertically, 0f);
                }
                else if (IsKilledLeft)
                {
                    spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipVertically, 0f);
                }
                else if (brickMarioCollision)
                {
                    spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipVertically, 0f);
                }
                else
                {
                    spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
        }

        public void Stomped()
        {
            IsStomped = true;   
        }

        public void BounceX(int width)
        {
            posChange.X = width;
        }
        public void bounceDead()
        {
            brickMarioCollision = true;
        }
        public void BounceY(int height)
        {
            posChange.Y = height;
        }

        public void Turn()
        {
            move.X = move.X * (-1);
        }

        public void Dead()
        {
            IsDead = true;
        }
        public void Fall()
        {
            move.Y = 3;
        }

        public void Land()
        {
            move.Y = 0;
        }
        public void KilledRight()
        {
            IsKilledRight = true;
            IsKilled = true;
            Collision++;
        }

        public void KilledLeft()
        {
            IsKilledLeft = true;
            IsKilled = true;
            Collision++;
        }

        public void Shell(Game1 g)
        {
            // do nothing
        }

       
    }
}
