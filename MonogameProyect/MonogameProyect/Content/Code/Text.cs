using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonogameProyect.Content.Code
{
    internal class Text : UI
    {
        SpriteFont font1;

        Viewport _viewport;
        string _output;

        public Text(Vector2 position, string output)
        {
            _position = position;
            _output = output;
        }

        public void LoadContent(Game1 game1, string fontName)
        {
            font1 = game1.Content.Load<SpriteFont>(fontName);
            Viewport viewport = game1.GetGraphicsDevice.GraphicsDevice.Viewport;
            SetViewport(viewport);
        }

        public void DrawText(Game1 game1)
        {
            game1.GetSpriteBatch.Begin();

            // Find the center of the string
            Vector2 FontOrigin = font1.MeasureString(_output) / 2;
            // Draw the string
            game1.GetSpriteBatch.DrawString(font1, _output, _position, Color.LightGreen,
                0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            game1.GetSpriteBatch.End();
        }

        public void SetViewport(Viewport viewport)
        {
            _viewport = viewport;
        }

        public Viewport GetViewport
        {
            get { return _viewport; }
        }
    }
}
