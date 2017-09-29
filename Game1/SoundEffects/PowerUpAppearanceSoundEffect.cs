using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class PowerUpAppearanceSoundEffect : ISoundEffect
    {
        private SoundEffect sound;

        public PowerUpAppearanceSoundEffect(SoundEffect s)
        {
            sound = s;
        }

        public void PlaySound()
        {
            sound.CreateInstance().Play();
        }
    }
}
