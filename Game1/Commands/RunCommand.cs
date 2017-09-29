using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class RunCommand : ICommand
    {
        private Game1 g;

        public RunCommand(Game1 game)
        {
            g = game;
        }

        public void Execute()
        {
            g.Character.Movement.Run();
        }
        public void Stop()
        {
            g.Character.Movement.StopRunning();
        }
    }
}
