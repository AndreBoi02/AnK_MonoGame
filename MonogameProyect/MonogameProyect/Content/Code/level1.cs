using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    internal class level1 : Scenes
    {
        GameManager _manager;
        GameObject _exitButton;


        public override void InitializeScene()
        {
            base.InitializeScene();

            _gameObjects = new List<GameObject>();

            _manager = new GameManager();
            _manager.InitiliazeGame();

            //Exit Button
            _exitButton = new GameObject(new SpriteRenderer(), new UI(), new Transform());
            _exitButton.GetTrasform.SetPosition(new Vector2(700, 370));
            _exitButton.GetTrasform.SetScale(new Vector2(.2f, .2f));
            _gameObjects.Add(_exitButton);
        }

        public override void LoadContentScene(Game1 game1)
        {
            base.LoadContentScene(game1);

            _manager.LoadGameContent(game1);

            //Exit Button Content
            string imageName = "Images/Yeet";
            _exitButton.GetSpriteRenderer.LoadContent(game1, imageName);
            _exitButton.GetUI.CreateButton(_exitButton.GetSpriteRenderer);
            _exitButton.GetUI.GetButton().OnClick += FinishGame;
        }

        public override void UpdateScene()
        {
            base.UpdateScene();

            _manager.UpdateGame();
        }

        public override void DrawScene(Game1 game1)
        {
            base.DrawScene(game1);

            _manager.DrawGO(game1);
        }

        void FinishGame(object sender, EventArgs e)
        {
            SceneManager.ChangeScene(3);
        }
    }
}
