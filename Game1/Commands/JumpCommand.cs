
namespace Game1
{
    class JumpCommand : ICommand
    {
        Game1 gamePlay;

        public JumpCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            if (!gamePlay.Character.ReachFlag)
                gamePlay.Character.Jump();
            //if (gamePlay.Character.JumpCounter == 1)
                //gamePlay.Character.MakeJumpSound();
    
        }
        public void Stop()
        {
            gamePlay.Character.StopJumping();
        }
    }
}
