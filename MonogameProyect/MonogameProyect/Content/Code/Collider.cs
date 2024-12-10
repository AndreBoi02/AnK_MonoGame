using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

namespace MonogameProyect.Content.Code
{
    internal class Collider
    {
        Vector2 _position;
        Vector2 _scale;
        Rectangle _rectangle;
        MouseState _lastMouseState;
        SpriteRenderer _spriteRenderer;
        public event EventHandler OnClick;

        public void SetSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }

        public void CreateCollider()
        {
            _rectangle = new((int)_position.X, (int)_position.Y,
                (int)(_spriteRenderer.GetTexture2D().Width * _scale.X),
                (int)(_spriteRenderer.GetTexture2D().Height * _scale.Y));
            getRecatngle();
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            Rectangle cursor = new((int)mouseState.Position.X, (int)mouseState.Position.Y, 1, 1);

            if (cursor.Intersects(_rectangle))
            {
                if (mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released)
                {
                    Click();
                }
            }
            _lastMouseState = mouseState;
        }

         void Click()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }

        public void SetColliterPosition(Vector2 position)
        {
            _position = position;
        }

        public void SetColliterScale(Vector2 scale)
        {
            _scale = scale;
        }

        public void getRecatngle()
        {
            Debug.WriteLine(_rectangle.Height);
            Debug.WriteLine(_rectangle.Width);
            
        }
    }
}
