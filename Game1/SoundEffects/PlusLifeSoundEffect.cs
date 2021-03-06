﻿using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class PlusLifeSoundEffect : ISoundEffect
    {
        private SoundEffect sound;

        public PlusLifeSoundEffect(SoundEffect s)
        {
            sound = s;
        }

        public void PlaySound()
        {
            sound.CreateInstance().Play();
        }
    }
}
