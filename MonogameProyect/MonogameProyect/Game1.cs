using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProyect.Content.Code;
using System;
using System.Diagnostics;
//List
using System.Collections.Generic;

namespace MonogameProyect
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Scenes> _scenes;

        MenuScene _menuScene;
        CreditsScene _creditsScene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _scenes = new List<Scenes>();

            _menuScene = new MenuScene();
            _menuScene.InitializeScene();
            _scenes.Add(_menuScene);

            _creditsScene = new CreditsScene();
            _creditsScene.InitializeScene();
            _scenes.Add(_creditsScene);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _menuScene.LoadContentScene(this);
            _creditsScene.LoadContentScene(this);
        }

        int sceneIdx = 1;
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                sceneIdx = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                sceneIdx = 0;
            }

            _scenes[sceneIdx].UpdateScene();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _scenes[sceneIdx].DrawScene(this);
            
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