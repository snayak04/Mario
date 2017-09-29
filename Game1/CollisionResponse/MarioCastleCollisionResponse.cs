using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MarioCastleCollisionResponse
    {
        public MarioCastleCollisionResponse(IMario m, Castle c, Game1 g)
        {
            bool collision = false;
            if ((m.Position.X > c.Position.X + 78) && (m.Position.X < c.Position.X + 82)){
                collision = true;
            }
            if (collision)
            {
                m.Movement.FlagLand(); // set the y speed to 0
                if (m.CurrentState is SmallMarioRightWalkingState)
                {
                    m.CurrentState = MarioFactory.Instance.CreateSmallRightStandingState(m);
                }else if (m.CurrentState is BigRightWalkingState)
                {
                    m.CurrentState = MarioFactory.Instance.CreateBigRightStandingState(m);
                }else if (m.CurrentState is FireMarioRightWalkingState)
                {
                    m.CurrentState = MarioFactory.Instance.CreateFireRightStandingState(m);

                }
                
            }
            else
            {
                if (m.ReachFlag&&(m.CurrentState is SmallMarioRightWalkingState|| m.CurrentState is BigRightWalkingState || m.CurrentState is FireMarioRightWalkingState))
                m.Movement.MoveRight();
            }
            if(collision && (m.Position.X >= c.Position.X + c.Texture.Width/3))
            {
                g.IncrementLevel();
                g.LevelClear();
            }


        }
    }
}
