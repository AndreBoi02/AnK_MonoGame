using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonogameProyect.Content.Code
{
    internal class Button : UI
    {
        Rectangle _rectangle;
        Color _shade = Color.White;
        SpriteRenderer _spriteRenderer;
        MouseState _lastMouseState;

        public event EventHandler OnClick;

        public Button(SpriteRenderer spriteRenderer, Vector2 position, Vector2 scale) 
        {
            _spriteRenderer = spriteRenderer;
            _position = position;
            _scale = scale;
            _rectangle = new((int)position.X, (int)position.Y, 
                (int)(_spriteRenderer.GetTexture2D().Width * scale.X),
                (int)(_spriteRenderer.GetTexture2D().Height * scale.Y));
        }

        public Button(Vector2 pivot, Vector2 position, Vector2 scale)
        {
            _position = position;
            _scale = scale;
            _rectangle = new((int)position.X, (int)position.Y, (int)pivot.X, (int)pivot.Y);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            Rectangle cursor = new((int)mouseState.Position.X, (int)mouseState.Position.Y, 1, 1);

            if (cursor.Intersects(_rectangle))
            {
                _shade = Color.DarkGray;
                _spriteRenderer?.ChangeColor(_shade);
                if(mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released)
                {
                    Click();
                }
            }
            else
            {
                _shade = Color.White;
                _spriteRenderer?.ChangeColor(_shade);
            }
            _lastMouseState = mouseState;
        }

        void Click()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
