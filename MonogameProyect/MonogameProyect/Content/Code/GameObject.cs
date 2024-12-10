using System;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    internal class GameObject
    {
        #region References

        Transform transform;
        AudioSource audioSource;
        SpriteRenderer spriteRenderer;
        Collider collider;
        Scripts script;
        UI uI;

        #endregion

        #region Constructors

        public GameObject()
        {

        }

        public GameObject(SpriteRenderer pSpriteRenderer)
        {
            spriteRenderer = pSpriteRenderer;
        }

        public GameObject(SpriteRenderer pSpriteRenderer, Transform pTransform)
        {
            spriteRenderer = pSpriteRenderer;
            transform = pTransform;
            transform?.SetSpriteRenderer(spriteRenderer);
        }

        public GameObject(UI pUI, Transform pTransform)
        {
            uI = pUI;
            transform = pTransform;
            transform.SetUI(pUI);
        }

        public GameObject( SpriteRenderer pSpriteRenderer, UI pUI, Transform pTransform)
        {
            spriteRenderer = pSpriteRenderer;
            transform = pTransform;
            transform?.SetSpriteRenderer(spriteRenderer);
            uI = pUI;
            transform.SetUI(pUI);
        }

        public GameObject(SpriteRenderer pSpriteRenderer, Transform pTransform, Scripts script)
        {
            spriteRenderer = pSpriteRenderer;
            transform = pTransform;
            transform.SetSpriteRenderer(spriteRenderer);
            _scripts = new List<Scripts>();
            AddScript(script);
        }

        public GameObject(SpriteRenderer pSpriteRenderer, Transform pTransform, Collider pCollider)
        {
            spriteRenderer = pSpriteRenderer;
            transform = pTransform;
            transform.SetSpriteRenderer(spriteRenderer);
            collider = pCollider;
            transform.SetCollider(collider);
            collider.SetSpriteRenderer(spriteRenderer);
        }

        #endregion

        #region ScriptSystem

        List<Scripts> _scripts;

        public void AddScript(Scripts scripts)
        {
            _scripts.Add(scripts);
        }

        public void InitializeScript()
        {
            if (_scripts == null)
                return;
            foreach (Scripts script in _scripts)
            {
                script.SetGameObeject(this);
                script.InitializeScript();
            }
        }

        public void RunScript()
        {
            if (_scripts == null) 
                return;
            foreach (Scripts script in _scripts)
            {
                script.ExecuteScript();
            }
        }

        public List<Scripts> GetScripts()
        {
            return _scripts;
        }

        #endregion

        #region Getters

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

        public Collider GetCollider
        {
            get { return collider; }
        }
        
        public Scripts GetScript
        {
            get { return script; }
        }

        public UI GetUI 
        {
            get { return uI; }
        }

        #endregion
    }
}
