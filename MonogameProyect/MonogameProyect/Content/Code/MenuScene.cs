using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    internal class MenuScene : Scenes
    {
        GameObject _titleText;
        GameObject _startButton;
        GameObject _optionsButton;

        public override void InitializeScene()
        {
            base.InitializeScene();

            _gameObjects = new List<GameObject>();

            //This is the title text
            _titleText = new GameObject(new UI(), new Transform());
            _titleText.GetTrasform.SetPosition(new Vector2(400, 50));
            string text = Localization.GetText("Title");
            _titleText.GetUI.CreateText(text, "Title");
            _gameObjects.Add(_titleText);

            //This is the start button
            _startButton = new GameObject(new SpriteRenderer(), new UI(), new Transform());
            _startButton.GetTrasform.SetPosition(new Vector2(370, 130));
            _startButton.GetTrasform.SetScale(new Vector2(.2f, .2f));
            _gameObjects.Add(_startButton);

            //This is the options button
            _optionsButton = new GameObject(new SpriteRenderer(), new UI(), new Transform());
            _optionsButton.GetTrasform.SetPosition(new Vector2(300, 250));
            _optionsButton.GetTrasform.SetScale(new Vector2(.2f, .2f));
            _gameObjects.Add(_optionsButton);
        }

        public override void LoadContentScene(Game1 game1)
        {
            //Tittle text content
            string fontName = "MyMenuFont";
            _titleText.GetUI.GetText().LoadContent(game1, fontName);

            //Start button content
            string imageName = "Images/Yeet";
            _startButton.GetSpriteRenderer.LoadContent(game1, imageName);
            _startButton.GetUI.CreateButton(_startButton.GetSpriteRenderer);

            //Options button content
            string imageName2 = "Images/OF";
            _optionsButton.GetSpriteRenderer.LoadContent(game1, imageName2);
            _optionsButton.GetUI.CreateButton(_optionsButton.GetSpriteRenderer);
        }
    }
}
