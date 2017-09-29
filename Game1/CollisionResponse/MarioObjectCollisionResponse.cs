using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MarioObjectCollisionResponse
    {
        public MarioObjectCollisionResponse(Game1 g, IObject o)  //Game1 gIMario m
        {
            
            if (o is GreenMushroomObject)
            {
                if (!o.IsUsed)
                {
                    g.Character.PlusLife();
                    o.IsUsed = true;
                    SoundEffectFactory.Instance.CreatePlusLifeSound().PlaySound();
                }
            }
            else if(o is RedMushroomObject)
            {
                if (!o.IsUsed && isSmallMarioButNotDead(g.Character)) 
                {
                    g.Character.ChangeToLarge();
                    SoundEffectFactory.Instance.CreatePowerUpTransitionSound().PlaySound();
                    
                }
                o.IsUsed = true;
            }
            else if(o is StarObject)
            {
                if (!o.IsUsed)
                {
                    MediaPlayer.Pause();
                    g.Character.ChangeToInvincible();
                    o.IsUsed = true;
                    SoundEffectFactory.Instance.CreateInvicibleSound().PlaySound();  //gotta stop sound
                }
            }
            else if (o is FlowerObject)
            {
                if (!o.IsUsed && (isSmallMarioButNotDead(g.Character) || isBigMario(g.Character)))
                {
                    g.Character.ChangeToFire();
                    SoundEffectFactory.Instance.CreatePowerUpTransitionSound().PlaySound();
                }
                o.IsUsed = true;
            }
            else if (o is CoinObject)
            {
                if (!o.IsUsed)
                {
                    g.Character.CoinCount();
                    o.IsUsed = true;
                    SoundEffectFactory.Instance.CreateCoinCollectSound().PlaySound();
                }
            }

        }

        private Boolean isSmallMarioButNotDead(IMario m)
        {
            Boolean flag = false;
            if (m.CurrentState is SmallMarioLeftCrouchingState)
            {
                flag = true;
            } else if (m.CurrentState is SmallMarioLeftJumpingState)
            {
                flag = true;
            } else if (m.CurrentState is SmallMarioLeftStandingState)
            {
                flag = true;
            } else if (m.CurrentState is SmallMarioLeftWalkingState)
            {
                flag = true;
            } else if (m.CurrentState is SmallMarioRightCrouchingState)
            {
                flag = true;
            } else if (m.CurrentState is SmallMarioRightJumpingState)
            {
                flag = true;
            } else if (m.CurrentState is SmallMarioRightStandingState)
            {
                flag = true;
            }else if (m.CurrentState is SmallMarioRightWalkingState)
            {
                flag = true;
            }
            return flag;
        }

        private Boolean isBigMario(IMario m)
        {
            Boolean flag = false;
            if (m.CurrentState is BigLeftJumpingState)
            {
                flag = true;
            }
            else if (m.CurrentState is BigLeftCrouchState)
            {
                flag = true;
            }
            else if (m.CurrentState is BigLeftWalkingState)
            {
                flag = true;
            }
            else if (m.CurrentState is BigMarioLeftStandingState)
            {
                flag = true;
            }
            else if (m.CurrentState is BigMarioRightJumpingState)
            {
                flag = true;
            }
            else if (m.CurrentState is BigRightCrouchState)
            {
                flag = true;
            }
            else if (m.CurrentState is BigRightStandingState)
            {
                flag = true;
            }
            else if (m.CurrentState is BigRightWalkingState)
            {
                flag = true;
            }
            return flag;
        }
    }
}
