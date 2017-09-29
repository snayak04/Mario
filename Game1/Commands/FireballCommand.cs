
namespace Game1
{
    class FireballCommand : ICommand
    {
        bool keyPressed = false;
        Game1 gamePlay;

        public FireballCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Character.Shoot();
        }
        public void Stop()
        {
            gamePlay.Character.Movement.StopRunning();
        }
    }
}
