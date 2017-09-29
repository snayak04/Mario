using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class TurtleEnemy : IEnemy
    {
        public Vector2 Location { get; set; }
        public bool IsKilled { get; set; }
        public bool IsStomped { get; set; }
        public bool IsKilledRight { get; set; }
        public bool IsKilledLeft { get; set; }
        public bool IsDead { get; set; }
        public Rectangle Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Collision { get; set; }

        //Constants for 4x4 texture atlas
        private const int FacingLeft = 0;
        private const int FacingRight = 1;

        private int currentDirection;
        private Vector2 posChange;
        private Vector2 move;
        private int Rows = 2;
        private int Columns = 2;
        private int currentFrame = 0;


        private int delay = 0;
        private int direction;
        private int upCount = 0;
        private int downCount = 0;
        private int upMaxCount = 2;
        private int downMaxCount = 100;
        private Boolean brickMarioCollision = false;
        public TurtleEnemy(Texture2D txt, Vector2 pos)
        {
            IsDead = false;
            IsKilled = false;
            IsKilledLeft = false;
            IsKilledRight = false;
            IsStomped = false;
            Texture = txt;
            Location = pos;
            Position = new Rectangle((int)Location.X, (int)Location.Y, Texture.Width / Columns, Texture.Height / Rows);
            posChange = new Vector2(0, 0);      //posChange used to bounce  enemy in x/y direction
            move = new Vector2(-1, 0);
            Collision = 0;
            currentDirection = FacingLeft;
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
                        if (currentFrame == 2)
                        {
                            currentFrame = 0;
                        }
                    }
                    else
                    {
                        // turtle disappear
                        Location = new Vector2(-100, -100);
                    }
                    delay = 0;
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
                int width = Texture.Width / Columns;
                int height = Texture.Height / Rows;
                int row = currentDirection;
                int column = currentFrame % Columns;

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
                    spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
                }
                else
                {
                    spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
            
        }

        public void Dead()
        {
            IsDead = true;
        }
        public void bounceDead()
        {
            brickMarioCollision = true;
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

        public void Stomped()
        {
            // do nothing
        }

        public void BounceX(int width)
        {
            posChange.X += width;
        }

        public void BounceY(int height)
        {
            posChange.Y += height;
        }

        public void Turn()
        {
            move.X = move.X * (-1);
            
            if(currentDirection == FacingLeft)
            {
                currentDirection = FacingRight;
            }
            else
            {
                currentDirection = FacingLeft;
            }
        }

        public void Fall()
        {
            move.Y = 3;
        }

        public void Land()
        {
            move.Y = 0;
        }

        public void Shell(Game1 g)
        {
            //Vector2 pos = new Vector2((int)Location.X, (int)Location.Y + Texture.Height / Rows);
           // shell = ProjectileFactory.Instance.CreateShell(pos);
           // g.projectiles.Add(shell);
        }
    }
}


