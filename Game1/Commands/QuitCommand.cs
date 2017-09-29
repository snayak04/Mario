using System;

namespace Game1
{
    public class QuitCommand : ICommand
    {
        private Game1 gamePlay;

        public QuitCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Exit();
        }
        public void Stop()
        {
            //Do nothing
        }
    }
}
