using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class CoinCollectSoundEffect : ISoundEffect
    {
        private SoundEffect sound;

        public CoinCollectSoundEffect(SoundEffect s)
        {
            sound = s;
        }

        public void PlaySound()
        {
            sound.CreateInstance().Play();
        }
    }
}
