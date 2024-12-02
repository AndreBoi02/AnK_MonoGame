using Microsoft.Xna.Framework;

namespace MonogameProyect.Content.Code
{
    internal class Transform
    {
        Vector2 _position;
        Vector2 _scale;

        public Vector2 GetPosition
        {
            get { return _position; }
        }

        public Vector2 GetScale
        {
            get { return _scale; }
        }

        public void SetPosition(Vector2 value)
        {
            _position = value;
        }

        public void SetScale(Vector2 value) 
        {
            _scale = value;
        }
    }
}
