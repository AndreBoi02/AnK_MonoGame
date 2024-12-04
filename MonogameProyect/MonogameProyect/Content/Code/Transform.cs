using Microsoft.Xna.Framework;

namespace MonogameProyect.Content.Code
{
    internal class Transform
    {
        Vector2 _position;
        Vector2 _scale;
        SpriteRenderer _sprieRenderer;

        //Transform(SpriteRenderer spriteRenderer, Vector2 position)
        //{
        //    _position = position;
        //    _sprieRenderer = spriteRenderer;
        //    _sprieRenderer.SetSpritePosition(_position);
        //}

        public void SetSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            _sprieRenderer = spriteRenderer;
        }

        public Vector2 GetScale
        {
            get { return _scale; }
        }

        public void SetScale(Vector2 value) 
        {
            _scale = value;
        }

        #region PositionStuff

        public void SetPosition(Vector2 value)
        {
            _position = value;
            _sprieRenderer?.SetSpritePosition(_position);
        }

        public Vector2 GetPosition
        {
            get { return _position; }
        }

        public void PosX(int val)
        {
            _position.X = val;
            _sprieRenderer?.SetSpritePosition(_position);
        }

        public void PosX(float val)
        {
            _position.X = val;
            _sprieRenderer?.SetSpritePosition(_position);
        }

        public void PosY(int val)
        {
            _position.Y = val;
            _sprieRenderer?.SetSpritePosition(_position);
        }

        public void PosY(float val)
        {
            _position.Y = val;
            _sprieRenderer?.SetSpritePosition(_position);
        }

        #endregion
    }
}
