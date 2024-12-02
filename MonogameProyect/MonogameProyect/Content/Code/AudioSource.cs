using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace MonogameProyect.Content.Code
{
    internal class AudioSource
    {
        SoundEffect _soundEffect;
        SoundEffectInstance _soundEffectInstance;
        float _pitch;
        float _volume;
        
        public void TurnSoundEffectIntoSoundEfectInstance(string fileName)
        {
            using Stream soundfile = TitleContainer.OpenStream(fileName);
            _soundEffect = SoundEffect.FromStream(soundfile);
            _soundEffectInstance = _soundEffect.CreateInstance();
        }

        public void PlaySoundEffectInstance()
        {
            _soundEffectInstance.Play();
        }

        public void SetLoopSound(bool value)
        {
            _soundEffectInstance.IsLooped = value;
        }

        public void AdjustPitch()
        {
            // Pitch takes values from -1 to 1
            _soundEffectInstance.Pitch = _pitch;
        }

        public void AdjustVolume()
        {
            // Volume only takes values from 0 to 1
            _soundEffectInstance.Volume = _volume;
        }

        public void SetPitch(float value)
        {
            _soundEffectInstance.Pitch = value;
        }

        public void SetVolume(float value)
        {
            _soundEffectInstance.Volume = value;
        }
    }
}
