using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    internal class CreditsScene : Scenes
    {
        GameObject _creditsTitle;
        GameObject _creditsText;
        GameObject _exitButton;

        public override void InitializeScene()
        {
            base.InitializeScene();

            _gameObjects = new List<GameObject>();

            //Credits Title
            _creditsTitle = new GameObject(new UI(), new Transform());
            _creditsTitle.GetTrasform.SetPosition(new Vector2(400, 50));
            string creditTitle = Localization.GetText("Credits");
            _creditsTitle.GetUI.CreateText(creditTitle, "Credits");
            _gameObjects.Add(_creditsTitle);

            //Credits Text
            _creditsText = new GameObject(new UI(), new Transform());
            _creditsText.GetTrasform.SetPosition(new Vector2(400, 200));
            string creditText = Localization.GetText("CreditsText");
            _creditsText.GetUI.CreateText(creditText, "CreditsText");
            _gameObjects.Add(_creditsText);

            //Exit Button
            _exitButton = new GameObject(new SpriteRenderer(), new UI(), new Transform());
            _exitButton.GetTrasform.SetPosition(new Vector2(700, 370));
            _exitButton.GetTrasform.SetScale(new Vector2(.2f, .2f));
            _gameObjects.Add(_exitButton);

        }

        public override void LoadContentScene(Game1 game1)
        {
            string titleFontName = "Fonts/TitleFont";
            _creditsTitle.GetUI.GetText().LoadContent(game1, titleFontName);

            //Credits Text Content
            string textFontName = "Fonts/TextFont";
            _creditsText.GetUI.GetText().LoadContent(game1, textFontName);

            //Exit Button Content
            string imageName = "Images/Yeet";
            _exitButton.GetSpriteRenderer.LoadContent(game1, imageName);
            _exitButton.GetUI.CreateButton(_exitButton.GetSpriteRenderer);
            _exitButton.GetUI.GetButton().OnClick += FinishGame;
        }

        void FinishGame(object sender, EventArgs e)
        {
            SceneManager.ChangeScene(0);
        }
    }
}
