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
        private GameTime gameTime1;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Localization.InitializeText();
            SceneManager.InitializeScences();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            SceneManager.LoadScenesContent(this);

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            SceneManager.UpdateScenes(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SceneManager.DrawScenes(this);

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