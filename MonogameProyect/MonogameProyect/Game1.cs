using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameProyect.Content.Code;
using System.Diagnostics;

namespace MonogameProyect
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //SpriteRenderer _spriteRenderer;

        GameObject _gameObject;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _gameObject = new GameObject(new SpriteRenderer(), new Transform());
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            string lol = "Images/Yeet";

            _gameObject.GetSpriteRenderer.LoadContent(this, lol);
        }

        float velX = 0;
        float velY = 0;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
            {
                velX++;
               _gameObject.GetTrasform.PosX(velX);
            }
            if (state.IsKeyDown(Keys.Left))
            {
                velX--;
                _gameObject.GetTrasform.PosX(velX);
            }
            if (state.IsKeyDown(Keys.Up))
            {
                velY--;
                _gameObject.GetTrasform.PosY(velY);
            }
            if (state.IsKeyDown(Keys.Down))
            {
                velY++;
                _gameObject.GetTrasform.PosY(velY);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _gameObject.GetSpriteRenderer.DrawSprite(this);
            //_gameObject.GetTrasform.SetPosition(new Vector2(100, 100));

            base.Draw(gameTime);
        }

        public SpriteBatch GetSpriteBatch 
        { 
            get { return _spriteBatch; } 
        }
    }
}