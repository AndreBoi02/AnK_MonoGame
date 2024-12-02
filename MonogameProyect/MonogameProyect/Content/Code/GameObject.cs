﻿using Microsoft.Xna.Framework;

namespace MonogameProyect.Content.Code
{
    internal class GameObject
    {
        Transform transform;
        AudioSource audioSource;
        SpriteRenderer spriteRenderer;
        Collider collider;

        public GameObject()
        {
            transform = new Transform();
            audioSource = new AudioSource();
            spriteRenderer = new SpriteRenderer();
            collider = new Collider();
        }

        public Transform GetTrasform
        {
            get { return transform; }
        }

        public AudioSource GetAudioSource 
        {
            get { return audioSource; }
        }

        public SpriteRenderer GetSpriteRenderer
        {
            get { return spriteRenderer; }
        }
    }
}
