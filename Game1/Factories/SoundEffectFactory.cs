
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Game1
{
    public class SoundEffectFactory
    {
        //public List<SoundEffect> soundEffects;
        private SoundEffect powerUpAppearance;
        private SoundEffect fireballShot;
        private SoundEffect powerUpTransition;
        private SoundEffect brickBreak;
        private SoundEffect marioDie;
        private SoundEffect projectileHit;
        private SoundEffect enemyStomp;
        private SoundEffect blockBump;
        private SoundEffect coinCollect;
        private SoundEffect plusLife;
        private SoundEffect jumpSmall;
        private SoundEffect jumpSuper;
        private SoundEffect pipeDown;
        private SoundEffect pause;
        private SoundEffect gameOver;
        private SoundEffect flagpole;
        private SoundEffect stageClear;
        private SoundEffect invincible;
        private SoundEffect nightmareMarioScream;
        private SoundEffect nightmareZombieSpawn;

        private static SoundEffectFactory instance = new SoundEffectFactory();

        public static SoundEffectFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundEffectFactory() { }

        public void LoadAllSoundEffects(ContentManager content)
        {
            powerUpAppearance = content.Load<SoundEffect>("powerUpAppearance");        
            //fireballShot = content.Load<SoundEffect>("ak47Fireball");                 
            powerUpTransition = content.Load<SoundEffect>("smbPowerUp");
            fireballShot = content.Load<SoundEffect>("smbFireball");
            brickBreak = content.Load<SoundEffect>("smbBreakBlock");
            marioDie = content.Load<SoundEffect>("smbMarioDie");
            projectileHit = content.Load<SoundEffect>("smbKick");
            enemyStomp = content.Load<SoundEffect>("smbStomp");
            blockBump = content.Load<SoundEffect>("smbBump");
            coinCollect = content.Load<SoundEffect>("smbCoin");
            plusLife = content.Load<SoundEffect>("smb1Up");
            jumpSmall = content.Load<SoundEffect>("smbJumpSmall");
            jumpSuper = content.Load<SoundEffect>("smbJumpSuper");
            pipeDown = content.Load<SoundEffect>("smbPipeDown");
            pause = content.Load<SoundEffect>("smbPause");
            gameOver = content.Load<SoundEffect>("smbGameOver");
            flagpole = content.Load<SoundEffect>("smbFlagpole");
            stageClear = content.Load<SoundEffect>("smbStageClear");
            invincible = content.Load<SoundEffect>("invincible");
            nightmareMarioScream = content.Load<SoundEffect>("nightmareMarioDying1");
            nightmareZombieSpawn = content.Load<SoundEffect>("nightmareZombieGrowl");
            //many more sounds  
        }

        public ISoundEffect CreatePowerUpAppearanceSound()
        {
            return new PowerUpAppearanceSoundEffect(powerUpAppearance);
        }

        public ISoundEffect CreateFireballShotSound()
        {
            return new FireballShotSoundEffect(fireballShot);
        }

        public ISoundEffect CreatePowerUpTransitionSound()
        {
            return new PowerUpTransitionSoundEffect(powerUpTransition);
        }

        public ISoundEffect CreateBrickBreakSound()
        {
            return new BrickBreakSoundEffect(brickBreak);
        }
        public ISoundEffect CreateMarioDieSound()
        {
            return new MarioDieSoundEffect(marioDie);
        }
        public ISoundEffect CreateProjectileHitSound()
        {
            return new ProjectileHitSoundEffect(projectileHit);
        }
        public ISoundEffect CreateEnemyStompSound()
        {
            return new EnemyStompSoundEffect(enemyStomp);
        }
        public ISoundEffect CreateBlockBumpSound()
        {
            return new BlockBumpSoundEffect(blockBump);
        }
        public ISoundEffect CreateCoinCollectSound()
        {
            return new CoinCollectSoundEffect(coinCollect);
        }
        public ISoundEffect CreatePlusLifeSound()
        {
            return new PlusLifeSoundEffect(plusLife);
        }
        public ISoundEffect CreateJumpSmallSound()
        {
            return new JumpSmallSoundEffect(jumpSmall);
        }
        public ISoundEffect CreateJumpSuperSound()
        {
            return new JumpSuperSoundEffect(jumpSuper);
        }
        public ISoundEffect CreatePipeDownSound()
        {
            return new PipeDownSoundEffect(pipeDown);
        }
        public ISoundEffect CreatePauseSound()
        {
            return new PauseSoundEffect(pause);
        }
        public ISoundEffect CreateGameOverSound()
        {
            return new GameOverSoundEffect(gameOver);
        }
        public ISoundEffect CreateFlagpoleSound()
        {
            return new FlagpoleSoundEffect(flagpole);
        }
        public ISoundEffect CreateStageClearSound()
        {
            return new StageClearSoundEffect(stageClear);
        }
        public ISoundEffect CreateInvicibleSound()
        {
            return new InvincibleSoundEffect(invincible);
        }
        public ISoundEffect CreateNightmareMarioDyingSound()
        {
            return new NightmareMarioDeathScreamSoundEffect(nightmareMarioScream);
        }
        public ISoundEffect CreateNightmareZombieSpawnSound()
        {
            return new NightmareZombieSpawnSoundEffect(nightmareZombieSpawn);
        }
    }
}
