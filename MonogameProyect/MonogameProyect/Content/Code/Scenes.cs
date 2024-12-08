
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    internal class Scenes
    {
        protected List<GameObject> _gameObjects;

        public virtual void InitializeScene(){}

        public virtual void LoadContentScene(Game1 game1){}

        public virtual void UpdateScene()
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.GetScripts() != null)
                    gameObject.RunScript();
                if (gameObject.GetUI != null && gameObject.GetUI.GetButton() != null)
                    gameObject.GetUI.GetButton().Update();
            }
        }

        public virtual void DrawScene(Game1 game1)
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.GetSpriteRenderer != null)
                    gameObject.GetSpriteRenderer.DrawSprite(game1);
                if (gameObject.GetUI != null && gameObject.GetUI.GetText() != null)
                    gameObject.GetUI.GetText().DrawText(game1);
            }
        }
    }
}
