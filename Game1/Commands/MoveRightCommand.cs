
namespace Game1
{
    class MoveRightCommand : ICommand
    {
        Game1 gamePlay;

        public MoveRightCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            if (!gamePlay.Character.ReachFlag)
                gamePlay.Character.MoveRight();
        }

        public void Stop()
        {
            gamePlay.Character.StopWalking();
        }
    }
}
