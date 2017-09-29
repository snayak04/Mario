using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class JumpSmallSoundEffect : ISoundEffect
    {
        private SoundEffect sound;

        public JumpSmallSoundEffect(SoundEffect s)
        {
            sound = s;
        }

        public void PlaySound()
        {
            sound.CreateInstance().Play();
        }
    }
}
