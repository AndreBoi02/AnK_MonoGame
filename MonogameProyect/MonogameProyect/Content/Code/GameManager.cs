using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonogameProyect.Content.Code
{
    internal class GameManager
    {
        List<GameObject> _gameColors;

        GameObject _rougeGO;
        GameObject _bluerGO;
        GameObject _jauneGO;
        GameObject _vertGO;

        int numOfSequences = 1;

        int _colorIdx;
        KeyboardState _lastKeyboardState;
        GameState _state;
        bool _isColorChoosed = false;
        bool _isThePlayerTurn = false;

        List<int> gamesColors; 
        List<int> playersColors; 

        enum GameState
        {
            Idle,
            ColorOn,
            ColorOff
        }

        public void InitiliazeGame()
        {
            _gameColors = new List<GameObject>();

            //Rouge Button
            _rougeGO = new GameObject(new SpriteRenderer(), new Transform(), new Collider());
            _rougeGO.GetTrasform.SetPosition(new Vector2(240, 70));
            _rougeGO.GetTrasform.SetScale(new Vector2(10, 10));
            _gameColors.Add(_rougeGO);

            //Bluer Button
            _bluerGO = new GameObject(new SpriteRenderer(), new Transform(), new Collider());
            _bluerGO.GetTrasform.SetPosition(new Vector2(400, 70));
            _bluerGO.GetTrasform.SetScale(new Vector2(10, 10));
            _gameColors.Add(_bluerGO);

            //Jaune Button
            _jauneGO = new GameObject(new SpriteRenderer(), new Transform(), new Collider());
            _jauneGO.GetTrasform.SetPosition(new Vector2(240, 230));
            _jauneGO.GetTrasform.SetScale(new Vector2(10, 10));
            _gameColors.Add(_jauneGO);

            //Vert Button
            _vertGO = new GameObject(new SpriteRenderer(), new Transform(), new Collider());
            _vertGO.GetTrasform.SetPosition(new Vector2(400, 230));
            _vertGO.GetTrasform.SetScale(new Vector2(10, 10));
            _gameColors.Add(_vertGO);

            //GameLogic
            _state = GameState.ColorOn;
            gamesColors = new List<int>();
            playersColors = new List<int>();
        }

        public void LoadGameContent(Game1 game1)
        {
            string rougeImageName = "Images/Red";
            _rougeGO.GetSpriteRenderer.LoadContent(game1, rougeImageName);
            _rougeGO.GetSpriteRenderer.ChangeColor(Color.Gray);
            _rougeGO.GetCollider.CreateCollider();
            _rougeGO.GetCollider.OnClick += clickRouge;

            string bluerImageName = "Images/Blue";
            _bluerGO.GetSpriteRenderer.LoadContent(game1, bluerImageName);
            _bluerGO.GetSpriteRenderer.ChangeColor(Color.Gray);
            _bluerGO.GetCollider.CreateCollider();
            _bluerGO.GetCollider.OnClick += clickBluer;

            string jauneImageName = "Images/Yellow";
            _jauneGO.GetSpriteRenderer.LoadContent(game1, jauneImageName);
            _jauneGO.GetSpriteRenderer.ChangeColor(Color.Gray);
            _jauneGO.GetCollider.CreateCollider();
            _jauneGO.GetCollider.OnClick += clickJaune;

            string vertImageName = "Images/Green";
            _vertGO.GetSpriteRenderer.LoadContent(game1, vertImageName);
            _vertGO.GetSpriteRenderer.ChangeColor(Color.Gray);
            _vertGO.GetCollider.CreateCollider();
            _vertGO.GetCollider.OnClick += clickVert;
        }

        int chrono;

        public void UpdateGame()
        {
            chrono++;
            
            foreach(GameObject gameObject in _gameColors)
            {
                gameObject.GetCollider.Update();
            }

            switch (_state)
            {
                case GameState.Idle:
                    _isThePlayerTurn = true;
                    break;

                case GameState.ColorOn:
                    for (int i = 0; i < numOfSequences; i++)
                    {
                        ChooseARandomColor();
                        turnColorOn();
                        if (chrono >= 100)
                        {
                            _state = GameState.ColorOff;
                            chrono = 0;
                        }
                    }
                    break;

                case GameState.ColorOff:
                    for (int i = 0; i < numOfSequences; i++)
                    {
                        turnColorOff();
                        if (chrono >= 1000)
                        {
                            _state = GameState.Idle;
                            chrono = 0;
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        public void DrawGO(Game1 game1)
        {
            foreach (GameObject gameObject in _gameColors)
            {
                if (gameObject.GetSpriteRenderer != null)
                    gameObject.GetSpriteRenderer.DrawSprite(game1);
                if (gameObject.GetUI != null && gameObject.GetUI.GetText() != null)
                    gameObject.GetUI.GetText().DrawText(game1);
            }
        }

        void ChooseARandomColor()
        {
            if (_isColorChoosed)
                return;
            Random randomNumber = new Random();
            _colorIdx = randomNumber.Next(0, 4);
           gamesColors.Add( _colorIdx );
            _isColorChoosed = true;
        }

        void turnColorOn()
        {
            _gameColors[_colorIdx].GetSpriteRenderer.ChangeColor(Color.White);
        }

        void turnColorOff()
        {
            _gameColors[_colorIdx].GetSpriteRenderer.ChangeColor(Color.Gray);
            _isColorChoosed =false;
        }

        public void CompareLists()
        {
            int idx = 0;
            foreach(int playerNum in playersColors)
            {
                if(playerNum == gamesColors[idx])
                {

                }
                idx++;
            }
        }

        #region SubscribeEvents
        void clickRouge(object var, EventArgs e)
        {
            if (!_isThePlayerTurn)
                return;
            playersColors.Add(0);
            Debug.WriteLine("Guy");
        }

        void clickBluer(object var, EventArgs e)
        {
            if (!_isThePlayerTurn)
                return;
            playersColors.Add(1);
            Debug.WriteLine("Rain");
        }

        void clickVert(object var, EventArgs e)
        {
            if (!_isThePlayerTurn)
                return;
            playersColors.Add(2);
            Debug.WriteLine("Missery");
        }

        void clickJaune(object var, EventArgs e)
        {
            if (!_isThePlayerTurn)
                return;
            playersColors.Add(3);
            Debug.WriteLine("Carrera");
        }
        #endregion
    }
}
