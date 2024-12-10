using System;
using System.Collections.Generic;
using System.Security.AccessControl;

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

        static public event Action? AddGameObject;

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

        public GameObject Instantiate(GameObject prefab)
        {
            GameObject gO = new GameObject();

            if (prefab.GetCollider != null)
                gO.collider = prefab.GetCollider;

            if (prefab.GetTrasform != null)
                gO.transform = prefab.GetTrasform;

            if (prefab.GetScripts() != null)
                gO.script = prefab.GetScript;

            if (prefab.GetSpriteRenderer != null)
                gO.spriteRenderer = prefab.GetSpriteRenderer;

            if (prefab.GetUI != null)
                gO.uI = prefab.GetUI;

            if (prefab.GetAudioSource != null)
                gO.audioSource = prefab.GetAudioSource;

            AddGameObject?.Invoke();
            return gO;
        }
    }
}
