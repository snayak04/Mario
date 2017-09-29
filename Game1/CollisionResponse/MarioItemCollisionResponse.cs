 using Microsoft.Xna.Framework;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MarioItemCollisionResponse
    {
        public MarioItemCollisionResponse(IMario m,  IItems i, CollisionSide c, List<IItems> items, List<IObject> objects, Game1 g) 
        { 
            if (!(i is FlagPoleItem))
            {

                Rectangle intersection = Rectangle.Intersect(m.Position, i.Position);

                switch (c)
                {
                    case CollisionSide.Top:  //relative to brick's top not mario's top
                        m.BreakStreak();
                        if (!(i is HiddenBlockItem))
                        {
                        
                            m.BounceY(-intersection.Height);
                            m.Land();
                          }
                        break;
                    case CollisionSide.Bottom:  //relative to brick's bottom not mario's top

                        Vector2 itemPos = new Vector2(i.Location.X, i.Location.Y - i.Position.Height);
                        
                        if(i is MysteryBlockGreenMushroomItem)
                        {
                            m.BounceY(intersection.Height);
                            items.Remove(i);
                            i = ItemFactory.Instance.CreateUsedBlock(i.Location);
                            items.Add(i);
                            objects.Add(ObjectFactory.Instance.CreateGreenMushroom(itemPos));
                            //g.nightmare.Add(ZombieFactory.Instance.CreateZombie(itemPos));
                            SoundEffectFactory.Instance.CreatePowerUpAppearanceSound().PlaySound();
                        }
                        else if (i is MysteryBlockRedMushroomItem)
                        {
                            m.BounceY(intersection.Height);
                            items.Remove(i);
                            i = ItemFactory.Instance.CreateUsedBlock(i.Location);
                            items.Add(i);
                            objects.Add(ObjectFactory.Instance.CreateRedMushroom(itemPos));
                            SoundEffectFactory.Instance.CreatePowerUpAppearanceSound().PlaySound();
                        }
                        else if (i is MysteryBlockStarItem)
                        {
                            m.BounceY(intersection.Height);
                            items.Remove(i);
                            i = ItemFactory.Instance.CreateUsedBlock(i.Location);
                            items.Add(i);
                            objects.Add(ObjectFactory.Instance.CreateStar(itemPos));
                            SoundEffectFactory.Instance.CreatePowerUpAppearanceSound().PlaySound();
                        }
                        else if (i is MysteryBlockCoinItem2)
                        {
                            m.BounceY(intersection.Height);
                            if (i.UsedOnce == 0)
                            {
                                m.CoinCount();     
                                i.UsedOnce = 1;
                            }     //This is just a brick block why is CoinCount being called here.
                            items.Remove(i);
                            i = ItemFactory.Instance.CreateUsedBlock(i.Location);
                            i.Bounce();
                            items.Add(i);
                            objects.Add(ObjectFactory.Instance.CreateDisappearingCoin(itemPos));
                            SoundEffectFactory.Instance.CreateCoinCollectSound().PlaySound(); 

                        }
                        else if (i is MysteryBlockFlowerItem)
                        {
                            m.BounceY(intersection.Height);
                            items.Remove(i);
                            i = ItemFactory.Instance.CreateUsedBlock(i.Location);
                            items.Add(i);
                            objects.Add(ObjectFactory.Instance.CreateFlower(itemPos));
                            SoundEffectFactory.Instance.CreatePowerUpAppearanceSound().PlaySound();
                        }
                        else if (i is CoinBlockItem)
                        {
                            i.Bounce();
                            i.timerStarted = true;
                            m.BounceY(intersection.Height+5);
                            if (!i.timerFinished)
                            {
                                objects.Add(ObjectFactory.Instance.CreateDisappearingCoin(itemPos));
                                SoundEffectFactory.Instance.CreateCoinCollectSound().PlaySound();
                                if (i.UsedOnce == 0)
                                {
                                    m.CoinCount();      //This is just a brick block why is CoinCount being called here.
                                    i.UsedOnce = 1;
                                }
                            }
                            else
                            {
                                items.Remove(i);
                                i = ItemFactory.Instance.CreateUsedBlock(i.Location);
                                i.Bounce();
                                items.Add(i);
                                objects.Add(ObjectFactory.Instance.CreateDisappearingCoin(itemPos));
                                SoundEffectFactory.Instance.CreateCoinCollectSound().PlaySound();
                                if (i.UsedOnce == 0)
                                {
                                    m.CoinCount();      //This is just a brick block why is CoinCount being called here.
                                    i.UsedOnce = 1;
                                }
                            }
                            i.UsedOnce = 0;
                        }
                        else if((i is BrickBlockItem) && m.CurrentState.IsBig )
                        {
                            m.BounceY(intersection.Height);
                            i.isBouncing = true;
                            if (i.UsedOnce == 0)
                            {
                                m.CoinCount();      //This is just a brick block why is CoinCount being called here.
                                i.UsedOnce = 1;
                            }

                            if (!i.HasEnemyOnIt)
                            {
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
                        
                        }
                        else if ((i is BrickBlockItem) && !m.CurrentState.IsBig)
                        {
                            m.BounceY(intersection.Height);

                            if (i.UsedOnce == 0)
                            {
                                m.CoinCount();
                                i.UsedOnce = 1;
                            }
                            else
                            {
                                i.Bounce();
                                SoundEffectFactory.Instance.CreateBlockBumpSound().PlaySound();
                            }
                        }
                        else if (i is HiddenBlockItem && !m.Movement.Falling)
                        {
                            m.BounceY(intersection.Height);
                                items.Remove(i);
                                i = ItemFactory.Instance.CreateUsedBlock(i.Location);
                                items.Add(i);
                        }
                        else if (i is RockBlockItem || i is ShadedBlockItem)
                        {
                            m.BounceY(intersection.Height);
                            i.Bounce();
                            SoundEffectFactory.Instance.CreateBlockBumpSound().PlaySound();
                        }

                        if (i is UsedBlockItem)
                        {
                            m.BounceY(intersection.Height);
                            i.Bounce();
                            SoundEffectFactory.Instance.CreateBlockBumpSound().PlaySound();
                        }

                        m.StopJumping();
                        break;
                    case CollisionSide.Right:
                        //Cannot go inside
                        if(i is TransitionPipeItem && g.CurrentState is HiddenLevelState)
                        {
                           ((HiddenLevelState)g.CurrentState).MoveBack();
                            SoundEffectFactory.Instance.CreatePipeDownSound().PlaySound();
                            
                        }
                        else if (!(i is HiddenBlockItem))
                        {
                            m.BounceX(-intersection.Width);
                            m.Movement.Velocity.X = 0;
                        }
                        break;
                    case CollisionSide.Left:
                        //Cannot go inside
                        if (!(i is HiddenBlockItem))
                        {
                            m.BounceX(intersection.Width);
                            m.Movement.Velocity.X = 0;
                        }
                        break;               
                }
            }
            else // item is flag
            {
                if (m.Position.X <= i.Position.X + 10 && m.Position.X >= i.Position.X +3)
                {
                    if (m.Position.Y + m.CurrentState.Height < i.Position.Y + i.Height)
                    {
                        if(i.SoundCounter == 0)
                        {
                            SoundEffectFactory.Instance.CreateFlagpoleSound().PlaySound();
                            i.SoundCounter++;
                        }
                        
                        m.Flag();
                        i.Flag();
                        if (m.CurrentState.IsBig && m.CurrentState.IsFire) // fire
                        {
                            m.CurrentState = MarioFactory.Instance.CreateFireLeftFlagState(m);
                            
                        }else if (m.CurrentState.IsBig) // big
                        {
                            m.CurrentState = MarioFactory.Instance.CreateBigLeftFlagState(m);
                            
                        }else // small
                        {
                            m.CurrentState = MarioFactory.Instance.CreateSmallLeftFlagState(m);
                        }
                    }
                    else
                    {
                        i.SoundCounter = 0;
                        m.FlagLand();
                        if(i.SoundCounter == 0)
                        {
                            SoundEffectFactory.Instance.CreateStageClearSound().PlaySound();
                            i.SoundCounter++;
                        }
                        if (m.CurrentState is SmallLeftFlagState)
                        {
                            m.CurrentState = MarioFactory.Instance.CreateSmallRightWalkingState(m);
                        }
                        else if (m.CurrentState is BigLeftFlagState)
                        {
                            m.CurrentState = MarioFactory.Instance.CreateBigRightWalkingState(m);
                        }
                        else if (m.CurrentState is FireLeftFlagState)
                        {
                            m.CurrentState = MarioFactory.Instance.CreateFireRightWalkingState(m);
                        }
                        
                    }
                }

                if (m.Position.X >= i.Position.X+30)
                {
                    i.Flag();
                    m.FlagLand();
                }

            }
        }
    }
}