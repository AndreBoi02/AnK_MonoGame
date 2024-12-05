using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProyect.Content.Code;
using System;
using System.Diagnostics;

namespace MonogameProyect
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //SpriteRenderer _spriteRenderer;

        GameObject _gameObject;
        GameObject _gameObject2;
        GameObject _gameObject3;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Crea un gameObject de un jugador
            _gameObject = new GameObject(new SpriteRenderer(), new Transform(), new Move());
            _gameObject.GetTrasform.SetPosition(new Vector2(100, 100));
            _gameObject.GetTrasform.SetScale(new Vector2(.2f, .2f));
            _gameObject.InitializeScript();

            //Crea un gameObject de Texto UI
            _gameObject2 = new GameObject(new UI(), new Transform());
            _gameObject2.GetTrasform.SetPosition(new Vector2(400, 200));
            string text = "BRUHHH";
            _gameObject2.GetUI.CreateText(text);

            //Crea un gameObject de Boton UI
            _gameObject3 = new GameObject(new SpriteRenderer(), new UI(), new Transform());
            _gameObject3.GetTrasform.SetPosition(new Vector2(400, 200));
            _gameObject3.GetTrasform.SetScale(new Vector2(.02f, .02f));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            string imageName = "Images/Yeet";
            _gameObject.GetSpriteRenderer.LoadContent(this, imageName);

            string fontName = "MyMenuFont";
            _gameObject2.GetUI.GetText().LoadContent(this, fontName);

            string imageName2 = "Images/OF";
            _gameObject3.GetSpriteRenderer.LoadContent(this, imageName2);
            _gameObject3.GetUI.CreateButton(_gameObject3.GetSpriteRenderer);
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            _gameObject.RunScript();

            _gameObject3.GetUI.GetButton().Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _gameObject.GetSpriteRenderer.DrawSprite(this);

            _gameObject2.GetUI.GetText().DrawText(this);

            _gameObject3.GetSpriteRenderer.DrawSprite(this);
            
            base.Draw(gameTime);
        }

        public SpriteBatch GetSpriteBatch 
        { 
            get { return _spriteBatch; } 
        }

        public GraphicsDeviceManager GetGraphicsDevice
        {
            get { return _graphics; }
        }
    }
}