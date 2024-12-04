using Microsoft.Xna.Framework;

namespace MonogameProyect.Content.Code
{
    internal class Transform
    {
        #region References

        SpriteRenderer _sprieRenderer;

        #endregion

        #region Variables

        Vector2 _position;
        Vector2 _scale;

        #endregion

        #region PublicMethods

        public void SetSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            _sprieRenderer = spriteRenderer;
        }

        #endregion

        #region ScaleStuff

        public void SetScale(Vector2 value) 
        {
            _scale = value;
            _sprieRenderer.SetSpriteScale(_scale);
        }

        public void ScaleX(int val) 
        {
            _scale.X = val;
        }
        
        public void ScaleX(float val) 
        {
            _scale.X = val;
        }

        public void ScaleY(int val) 
        {
            _scale.Y = val;
        }
        
        public void ScaleY(float val) 
        {
            _scale.Y = val;
        }

        public Vector2 GetScale {
            get { return _scale; }
        }

        #endregion
       
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
