using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

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
        int clicksUsed = 0;

        int _colorIdx;
        KeyboardState _lastKeyboardState;
        GameState _state;
        bool _isColorChoosed = false;
        bool _isThePlayerTurn = false;

        List<int> gamesNumbers; 
        List<int> playersNumbers;

        float waitTime = 2f;
        int currentIteration = 0;
        float iterationTimer = 0f;

        enum GameState
        {
            Idle,
            gamesTurn,
            playerTurn
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
            _state = GameState.gamesTurn;
            gamesNumbers = new List<int>();
            playersNumbers = new List<int>();
        }

        public void LoadGameContent(Game1 game1)
        {
            string rougeImageName = "Images/Red";
            _rougeGO.GetSpriteRenderer.LoadContent(game1, rougeImageName);
            _rougeGO.GetSpriteRenderer.ChangeColor(Color.Gray);
            _rougeGO.GetCollider.CreateCollider();
            _rougeGO.GetCollider.OnClick += clickRouge;
            _rougeGO.GetCollider.OnReleased += releasedRouge;

            string bluerImageName = "Images/Blue";
            _bluerGO.GetSpriteRenderer.LoadContent(game1, bluerImageName);
            _bluerGO.GetSpriteRenderer.ChangeColor(Color.Gray);
            _bluerGO.GetCollider.CreateCollider();
            _bluerGO.GetCollider.OnClick += clickBluer;
            _bluerGO.GetCollider.OnReleased += releasedBluer;

            string jauneImageName = "Images/Yellow";
            _jauneGO.GetSpriteRenderer.LoadContent(game1, jauneImageName);
            _jauneGO.GetSpriteRenderer.ChangeColor(Color.Gray);
            _jauneGO.GetCollider.CreateCollider();
            _jauneGO.GetCollider.OnClick += clickJaune;
            _jauneGO.GetCollider.OnReleased += releasedJaune;

            string vertImageName = "Images/Green";
            _vertGO.GetSpriteRenderer.LoadContent(game1, vertImageName);
            _vertGO.GetSpriteRenderer.ChangeColor(Color.Gray);
            _vertGO.GetCollider.CreateCollider();
            _vertGO.GetCollider.OnClick += clickVert;
            _vertGO.GetCollider.OnReleased += releasedVert;
        }

        public void UpdateGame(GameTime gameTime)
        {
            //chrono++;
            
            foreach(GameObject gameObject in _gameColors)
            {
                gameObject.GetCollider.Update();
            }

            switch (_state)
            {
                case GameState.Idle:
                    ReffereesTurn();
                    break;

                case GameState.gamesTurn:
                    GamesTurn(gameTime);
                    break;

                case GameState.playerTurn:
                    playersTurn();
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

        #region GamesTurnLogic

        void ChooseARandomColor()
        {
            if (_isColorChoosed)
                return;
            Random randomNumber = new Random();
            _colorIdx = randomNumber.Next(0, 4);
           gamesNumbers.Add( _colorIdx );
            _isColorChoosed = true;
        }

        void GamesTurn(GameTime gameTime)
        {
            iterationTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentIteration < numOfSequences)
            {
                ChooseARandomColor();
                turnColorOn();
                if (iterationTimer >= waitTime)
                {
                    turnColorOff();
                    currentIteration++;
                    iterationTimer = 0f;
                }
            }
            else
            {
                changeState(GameState.playerTurn);
                _isThePlayerTurn = true;
            }
        }

        void turnColorOn()
        {
            _gameColors[_colorIdx].GetSpriteRenderer.ChangeColor(Color.White);
        }

        void turnColorOff()
        {
            _gameColors[_colorIdx].GetSpriteRenderer.ChangeColor(Color.Gray);
            _isColorChoosed = false;
        }

        #endregion

        #region PlayersTurnLogic

        void playersTurn()
        {
            if (clicksUsed >= numOfSequences)
            {
                _isThePlayerTurn = false;
                changeState(GameState.Idle);
            }
        }

        void clickRouge(object var, EventArgs e)
        {
            if (!_isThePlayerTurn)
                return;
            playersNumbers.Add(0);
            _gameColors[0].GetSpriteRenderer.ChangeColor(Color.White);
            clicksUsed++;
            Debug.WriteLine("Guy");
        }

        void releasedRouge(object var, EventArgs e)
        {
            _gameColors[0].GetSpriteRenderer.ChangeColor(Color.Gray);
        }

        void clickBluer(object var, EventArgs e)
        {
            if (!_isThePlayerTurn)
                return;
            playersNumbers.Add(1);
            _gameColors[1].GetSpriteRenderer.ChangeColor(Color.White);
            clicksUsed++;
            Debug.WriteLine("Rain");
        }

        void releasedBluer(object var, EventArgs e)
        {
            _gameColors[1].GetSpriteRenderer.ChangeColor(Color.Gray);
        }

        void clickJaune(object var, EventArgs e)
        {
            if (!_isThePlayerTurn)
                return;
            playersNumbers.Add(2);
            _gameColors[2].GetSpriteRenderer.ChangeColor(Color.White);
            clicksUsed++;
            Debug.WriteLine("Carrera");
        }

        void releasedJaune(object var, EventArgs e)
        {
            _gameColors[2].GetSpriteRenderer.ChangeColor(Color.Gray);
        }
        void clickVert(object var, EventArgs e)
        {
            if (!_isThePlayerTurn)
                return;
            playersNumbers.Add(3);
            _gameColors[3].GetSpriteRenderer.ChangeColor(Color.White);
            clicksUsed++;
            Debug.WriteLine("Missery");
        }

        void releasedVert(object var, EventArgs e)
        {
            _gameColors[3].GetSpriteRenderer.ChangeColor(Color.Gray);
        }

        #endregion

        #region ReffereeLogic

        void ReffereesTurn()
        {
            if (CompareLists())
            {
                Debug.WriteLine("Round Won");
                numOfSequences++;
                clicksUsed = 0;
                _colorIdx = 0;
                currentIteration = 0;
                gamesNumbers.Clear();
                playersNumbers.Clear();
                changeState(GameState.gamesTurn);
            }
            else
            {
                SceneManager.ChangeScene(3);
                Debug.WriteLine("Round Lost");
            }
        }

        public bool CompareLists()
        {
            for (int i = 0; i < numOfSequences; i++)
            {
                if (playersNumbers[i] != gamesNumbers[i])
                    return false;
                return true;
            }
            return false;
        }

        #endregion

        void changeState(GameState gameState)
        {
            _state = gameState;
        }
    }
}
