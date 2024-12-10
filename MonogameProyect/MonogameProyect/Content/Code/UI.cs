using Microsoft.Xna.Framework;

namespace MonogameProyect.Content.Code
{
    internal class UI
    {
        Text _text;
        Button _button;

        protected Vector2 _position;
        protected Vector2 _scale;

        public void CreateText(string pText, string pDKey)
        {
           _text = new Text(_position, pText, pDKey);
        }

        public void CreateButton(SpriteRenderer spriteRenderer) 
        {
            _button = new Button( spriteRenderer, _position, _scale);
        }

        public void CreateButton(Vector2 pivot) 
        {
            _button = new Button( pivot, _position, _scale);
        }

        public void SetTextPosition(Vector2 value)
        {
            _position = value;
        }

        public void SetButtonPosition(Vector2 value)
        {
            _position = value;
        }
        
        public void SetButtonScale(Vector2 value)
        {
            _scale = value;
        }

        public Text GetText()
        {
            return _text;
        }

        public Button GetButton()
        {
            return _button;
        }
    }
}
