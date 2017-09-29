using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class FireballShotSoundEffect : ISoundEffect
    {
        private SoundEffect sound;
        

        public FireballShotSoundEffect(SoundEffect s)
        {
            sound = s;
        }

        public void PlaySound()
        {
            sound.CreateInstance().Play();
        }
    }
}
