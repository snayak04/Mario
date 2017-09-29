using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class JumpSuperSoundEffect : ISoundEffect
    {
        private SoundEffect sound;

        public JumpSuperSoundEffect(SoundEffect s)
        {
            sound = s;
        }

        public void PlaySound()
        {
            sound.CreateInstance().Play();
        }
    }
}
