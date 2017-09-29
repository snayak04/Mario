using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public class MarioFactory
    {

        public static ITextureAtlas smallMarioRightWalkingAtlas;
        public static ITextureAtlas smallMarioLeftWalkingAtlas;
        public static ITextureAtlas smallMarioRightStandingAtlas;
        public static ITextureAtlas smallMarioLeftStandingAtlas;
        public static ITextureAtlas smallMarioRightJumpingAtlas;
        public static ITextureAtlas smallMarioLeftJumpingAtlas;
        public static ITextureAtlas smallMarioDeadAtlas;
        public static ITextureAtlas smallMarioLeftFlagAtlas;

        public static ITextureAtlas bigMarioRightStandingAtlas;
        public static ITextureAtlas bigMarioLeftStandingAtlas;
        public static ITextureAtlas bigMarioRightWalkingAtlas;
        public static ITextureAtlas bigMarioLeftWalkingAtlas;
        public static ITextureAtlas bigMarioRightCrouchingAtlas;
        public static ITextureAtlas bigMarioLeftCrouchingAtlas;
        public static ITextureAtlas bigMarioRightJumpingAtlas;
        public static ITextureAtlas bigMarioLeftJumpingAtlas;
        public static ITextureAtlas bigMarioLeftFlagAtlas;

        public static ITextureAtlas fireMarioRightStandingAtlas;
        public static ITextureAtlas fireMarioLeftStandingAtlas;
        public static ITextureAtlas fireMarioRightWalkingAtlas;
        public static ITextureAtlas fireMarioLeftWalkingAtlas;
        public static ITextureAtlas fireMarioRightCrouchingAtlas;
        public static ITextureAtlas fireMarioLeftCrouchingAtlas;
        public static ITextureAtlas fireMarioRightJumpingAtlas;
        public static ITextureAtlas fireMarioLeftJumpingAtlas;
        public static ITextureAtlas fireMarioLeftFlagAtlas;


        private static MarioFactory instance = new MarioFactory();

        private MarioFactory()
        {

        }

        public static MarioFactory Instance
        {
            get {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            smallMarioRightStandingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("SmallMarioRightStandingNew"));
            smallMarioRightWalkingAtlas = new ThreeFrameTextureAtlas(content.Load<Texture2D>("SmallMarioRightWalkingNew"));
            smallMarioRightJumpingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("SmallMarioRightJumpingNew"));
            smallMarioLeftStandingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("SmallMarioLeftStandingNew"));
            smallMarioLeftWalkingAtlas = new ThreeFrameTextureAtlas(content.Load<Texture2D>("SmallMarioLeftWalkingNew1"));
            smallMarioLeftJumpingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("SmallMarioLeftJumpingNew"));
            smallMarioDeadAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("SmallMarioDead"));
            smallMarioLeftFlagAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("SmallMarioLeftFlag"));

            bigMarioRightStandingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("BigMarioRightStanding"));
            bigMarioRightCrouchingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("BigMarioRightCrouching"));
            bigMarioRightJumpingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("BigMarioRightJumping"));
            bigMarioRightWalkingAtlas = new ThreeFrameTextureAtlas(content.Load<Texture2D>("BigMarioRightWalking"));
            bigMarioLeftStandingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("BigMarioLeftStanding"));
            bigMarioLeftCrouchingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("BigMarioLeftCrouching"));
            bigMarioLeftJumpingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("BigMarioLeftJumping"));
            bigMarioLeftWalkingAtlas = new ThreeFrameTextureAtlas(content.Load<Texture2D>("BigMarioLeftWalking"));
            bigMarioLeftFlagAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("BigMarioLeftFlag"));

            fireMarioRightStandingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("FireMarioRightStandingNew"));
            fireMarioRightCrouchingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("FireMarioRightCrouchingNew"));
            fireMarioRightJumpingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("FireMarioRightJumpingNew"));
            fireMarioRightWalkingAtlas = new ThreeFrameTextureAtlas(content.Load<Texture2D>("FireMarioRightWalkingNew"));
            fireMarioLeftStandingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("FireMarioLeftStandingNew"));
            fireMarioLeftCrouchingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("FireMarioLeftCrouchingNew"));
            fireMarioLeftJumpingAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("FireMarioLeftJumpingNew"));
            fireMarioLeftWalkingAtlas = new ThreeFrameTextureAtlas(content.Load<Texture2D>("FireMarioLeftWalkingNew"));
            fireMarioLeftFlagAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("FireMarioLeftFlag"));
        }


        //Big Mario States// 
        public IMarioState CreateBigLeftFlagState(IMario mario)
        {
            return new BigLeftFlagState(mario);
        }
        public IMarioState CreateBigLeftStandingState(IMario mario)
        {
            return new BigMarioLeftStandingState(mario);
        }
        public IMarioState CreateBigRightStandingState(IMario mario)
        {
            return new BigRightStandingState(mario);
        }
        public IMarioState CreateBigLeftCrouchState(IMario mario)
        {
            return new BigLeftCrouchState(mario);
        }
        public IMarioState CreateBigRightCrouchState(IMario mario)
        {
            return new BigRightCrouchState(mario);
        }
        public IMarioState CreateBigLeftJumpingState(IMario mario)
        {
            return new BigLeftJumpingState(mario);
        }
        public IMarioState CreateBigRightJumpingState(IMario mario)
        {
            return new BigMarioRightJumpingState(mario);
        }
        public IMarioState CreateBigLeftWalkingState(IMario mario) 
        {
            return new BigLeftWalkingState(mario); 
        }
        public IMarioState CreateBigRightWalkingState(IMario mario)
        {
            return new BigRightWalkingState(mario);
        }
        //Small Mario States //
        public IMarioState CreateSmallLeftFlagState(IMario mario)
        {
            return new SmallLeftFlagState(mario);
        }
        public IMarioState CreateSmallRightStandingState(IMario mario)
        {
            return new SmallMarioRightStandingState(mario);
        }

        public IMarioState CreateSmallLeftStandingState(IMario mario)
        {
            return new SmallMarioLeftStandingState(mario);
        }

        public IMarioState CreateSmallRightWalkingState(IMario mario)
        {
            return new SmallMarioRightWalkingState(mario);
        }

        public IMarioState CreateSmallLeftWalkingState(IMario mario)
        {
            return new SmallMarioLeftWalkingState(mario);
        }

        public IMarioState CreateSmallRightJumpingState(IMario mario)
        {
            return new SmallMarioRightJumpingState(mario);
        }

        public IMarioState CreateSmallLeftJumpingState(IMario mario)
        {
            return new SmallMarioLeftJumpingState(mario);
        }
        public IMarioState CreateSmallDeadState(IMario mario)
        {
            return new SmallMarioDeadState(mario);
        }
        public IMarioState CreateSmallRightCrouchingState(IMario mario)
        {
            return new SmallMarioRightCrouchingState(mario);
        }
        public IMarioState CreateSmallLeftCrouchingState(IMario mario)
        {
            return new SmallMarioLeftCrouchingState(mario);
        }

        //FIRE MARIO STATES//
        public IMarioState CreateFireLeftFlagState(IMario mario)
        {
            return new FireLeftFlagState(mario);
        }
        public IMarioState CreateFireLeftStandingState(IMario mario)
        {
            return new FireMarioLeftStandingState(mario);
        }
        public IMarioState CreateFireLeftWalkingState(IMario mario)
        {
            return new FireMarioLeftWalkingState(mario);
        }
        public IMarioState CreateFireLeftJumpingState(IMario mario)
        {
            return new FireMarioLeftJumpingState(mario);
        }
        public IMarioState CreateFireLeftCrouchingState(IMario mario)
        {
            return new FireMarioLeftCrouchingState(mario);
        }
        public IMarioState CreateFireRightStandingState(IMario mario)
        {
            return new FireMarioRightStandingState(mario);
        }
        public IMarioState CreateFireRightWalkingState(IMario mario)
        {
            return new FireMarioRightWalkingState(mario);
        }
        public IMarioState CreateFireRightJumpingState(IMario mario)
        {
            return new FireMarioRightJumpingState(mario);
        }
        public IMarioState CreateFireRightCrouchingState(IMario mario)
        {
            return new FireMarioRightCrouchingState(mario);
        }
    }
}
