using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    internal class level1 : Scenes
    {
        GameManager _manager;

        public override void InitializeScene()
        {
            base.InitializeScene();

            _gameObjects = new List<GameObject>();

            _manager = new GameManager();
            _manager.InitiliazeGame();
        }

        public override void LoadContentScene(Game1 game1)
        {
            base.LoadContentScene(game1);

            _manager.LoadGameContent(game1);
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);

            _manager.UpdateGame(gameTime);
        }

        public override void DrawScene(Game1 game1)
        {
            base.DrawScene(game1);

            _manager.DrawGO(game1);
        }
    }
}
