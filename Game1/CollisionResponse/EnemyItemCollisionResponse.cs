using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class EnemyItemCollisionResponse
    {
        public EnemyItemCollisionResponse(IEnemy e, IItems i, List<IItems> items, CollisionSide c, Game1 g)
        {
            Rectangle intersection = Rectangle.Intersect(e.Position, i.Position);
            switch (c)
            {
                case CollisionSide.Top:
                    e.BounceY(-intersection.Height);
                    if (!e.IsKilled)
                    {
                        e.Land();
                    }
 
                    if(!(i is FlagPoleItem || i is PipeItem || i is RockBlockItem || i is ShadedBlockItem || i is UsedBlockItem))
                    {
                        i.HasEnemyOnIt = true;
                    }
                    if (g.Character.CurrentState.IsBig && i.HasEnemyOnIt && i.isBouncing && i is BrickBlockItem)
                    {
                        e.KilledRight();
                        if (e.Collision == 1)
                        {
                            g.Character.ProjectileSmash();
                        }
                        Vector2 ExplodingPiece1Position = new Vector2(i.Location.X, i.Location.Y);
                        Vector2 ExplodingPiece2Position = new Vector2(i.Location.X + i.Texture.Width, i.Location.Y);
                        Vector2 ExplodingPiece3Position = new Vector2(i.Location.X, i.Location.Y + i.Texture.Height);
                        Vector2 ExplodingPiece4Position = new Vector2(i.Location.X + i.Position.Width, i.Location.Y + i.Texture.Height);
                        items.Remove(i);
                        i = ItemFactory.Instance.CreateBrickBlockPiecesExplodingHighLeft(ExplodingPiece1Position);
                        items.Add(i);
                        i = ItemFactory.Instance.CreateBrickBlockPiecesExplodingHighRight(ExplodingPiece2Position);
                        items.Add(i);
                        i = ItemFactory.Instance.CreateBrickBlockPiecesExplodingLowLeft(ExplodingPiece3Position);
                        items.Add(i);
                        i = ItemFactory.Instance.CreateBrickBlockPiecesExplodingLowRight(ExplodingPiece4Position);
                        items.Add(i);
                        SoundEffectFactory.Instance.CreateBrickBreakSound().PlaySound();
                    }
                    else if (i.isBouncing && i.HasEnemyOnIt)  //(i.isBouncing && !g.Character.CurrentState.IsBig)
                    {
                        e.KilledRight();
                        if (e.Collision == 1)
                        {
                            g.Character.ProjectileSmash();
                        }
                    }
                    break;

                case CollisionSide.Left:
                    e.BounceX(intersection.Width);
                    e.Turn();
                    break;
                case CollisionSide.Right:
                    e.BounceX(-intersection.Width);
                    e.Turn();
                    break;
                
                case CollisionSide.None:
                    e.Fall();
                    break;

            }
        }
    }
}
