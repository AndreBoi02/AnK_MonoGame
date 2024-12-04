using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonogameProyect.Content.Code
{
    internal class SpriteRenderer
    {
        // The reference to the loaded sprite
        private Texture2D spriteTexture;
        // The position to draw the sprite
        private Vector2 spritePosition;

        public void LoadContent(Game1 game1, string spriteName)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteTexture = game1.Content.Load<Texture2D>(spriteName);
            spritePosition = Vector2.Zero;
        }

        public void DrawSprite(Game1 game1)
        {
            game1.GetSpriteBatch.Begin();
            game1.GetSpriteBatch.Draw(spriteTexture, spritePosition, Color.White);
            game1.GetSpriteBatch.End();
        }

        public void SetSpritePosition(Vector2 value)
        {
            spritePosition = value;
        }
    }
}
