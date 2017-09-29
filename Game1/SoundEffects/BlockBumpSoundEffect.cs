using Microsoft.Xna.Framework.Audio;


namespace Game1
{
    class BlockBumpSoundEffect : ISoundEffect
    {
        private SoundEffect sound;

        public BlockBumpSoundEffect(SoundEffect s)
        {
            sound = s;
        }

        public void PlaySound()
        {
            sound.CreateInstance().Play();
        }
    }
}
