using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IMario
    {

        void FlagLand();
        void Flag();
        void ChangeLevel(Vector2 startPos);
        bool ReachFlag { get; set; }
        void StopCrouching();
        IMario clone();
        IMarioState CurrentState { get; set; }
        Rectangle Position { get; set; }
        Physics Movement { get; set; }
        int GetCoin { get; set; }
        int JumpCounter { get; set; }
        void Update();
        void Land();
        void Draw(SpriteBatch spriteBatch);
        void Jump();
        void Crouch();
        void MoveLeft();
        void MoveRight();
        void ChangeToFire();
        void ChangeToLarge();
        void ChangeToSmall();
        void ChangeToInvincible();
        void StopWalking();
        void StopJumping();
        void Die();
        void PlusLife();
        void CoinCount();
        void Bounce();
        void BounceX(int width);
        void BounceY(int height);
        bool Invincible { get; set; }
        bool FacingRight { get; set; }
        void Shoot();
        void SmashEnemy();
        int GetScore();
        bool consecutiveCrash { get; set; }
        void BreakStreak();
        void ProjectileSmash();
        bool isInRange(Vector2 position);
        int LifeCount { get; set; }
    }
}
