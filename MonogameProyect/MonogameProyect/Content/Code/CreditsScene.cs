using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    internal class CreditsScene : Scenes
    {
        GameObject _player;

        public override void InitializeScene()
        {
            base.InitializeScene();

            _gameObjects = new List<GameObject>();

            //Test PLayer Script
            _player = new GameObject(new SpriteRenderer(), new Transform(), new Move());
            _player.GetTrasform.SetPosition(new Vector2(100, 100));
            _player.GetTrasform.SetScale(new Vector2(.2f, .2f));
            _player.InitializeScript();
            _gameObjects.Add(_player);
        }

        public override void LoadContentScene(Game1 game1)
        {
            //Test Player Script
            string imageName = "Images/Yeet";
            _player.GetSpriteRenderer.LoadContent(game1, imageName);
        }
    }
}
