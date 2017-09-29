using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IMarioState
    {
        IMarioState clone(IMario destination);
        bool IsBig { get;  }
        bool IsFire { get; }
        int Width { get; }
        int Height { get; }
        void StopWalking();
        void StopJumpingFalling();
        void Draw(SpriteBatch spriteBatch, Vector2 pos);
        void Update();
        void Jump();
        void Crouch();
        void MoveLeft();
        void MoveRight();
        void ChangeToFire();
        void ChangeToBig();
        void ChangeToSmall();
        void ChangeToInvincible();
        void Die();
        
    }
}
