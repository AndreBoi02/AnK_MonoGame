using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MonogameProyect.Content.Code
{
    internal class SettingScene : Scenes
    {
        GameObject _settingText;
        GameObject _settingButton;
        GameObject _backToMenuButton;
        bool _englishEnabled = true;

        public override void InitializeScene()
        {
            base.InitializeScene();

            _gameObjects = new List<GameObject>();

            //Text of the Scene
            _settingText = new GameObject(new UI(), new Transform());
            _settingText.GetTrasform.SetPosition(new Vector2(400, 50));
            string text = Localization.GetText("Settings");
            _settingText.GetUI.CreateText(text, "Settings");
            _gameObjects.Add(_settingText);

            //Change Language Button
            _settingButton = new GameObject(new SpriteRenderer(), new UI(), new Transform());
            _settingButton.GetTrasform.SetPosition(new Vector2(370, 130));
            _settingButton.GetTrasform.SetScale(new Vector2(.2f, .2f));
            _gameObjects.Add(_settingButton);

            //Return to menu button
            _backToMenuButton = new GameObject(new SpriteRenderer(), new UI(), new Transform());
            _backToMenuButton.GetTrasform.SetPosition(new Vector2(300, 250));
            _backToMenuButton.GetTrasform.SetScale(new Vector2(.2f, .2f));
            _gameObjects.Add(_backToMenuButton);
        }

        public override void LoadContentScene(Game1 game1)
        {
            //Settings text content
            string fontName = "Fonts/TitleFont";
            _settingText.GetUI.GetText().LoadContent(game1, fontName);

            //Start button content
            string imageName = "Images/Yeet";
            _settingButton.GetSpriteRenderer.LoadContent(game1, imageName);
            _settingButton.GetUI.CreateButton(_settingButton.GetSpriteRenderer);
            _settingButton.GetUI.GetButton().OnClick += ChangeLanguage;

            //Options button content
            string imageName2 = "Images/OF";
            _backToMenuButton.GetSpriteRenderer.LoadContent(game1, imageName2);
            _backToMenuButton.GetUI.CreateButton(_backToMenuButton.GetSpriteRenderer);
            _backToMenuButton.GetUI.GetButton().OnClick += BackToMenu;
        }

        public void ChangeLanguage(object sender, EventArgs e)
        {
            _englishEnabled = !_englishEnabled;
            if ( _englishEnabled)
            {
                Localization.ChangeLanguage(Languages.ENG);
            }
            else
            {
                Localization.ChangeLanguage(Languages.ESP);
            }
        }

        public void BackToMenu(object sender, EventArgs e)
        {
            SceneManager.ChangeScene(0);
        }
    }
}
