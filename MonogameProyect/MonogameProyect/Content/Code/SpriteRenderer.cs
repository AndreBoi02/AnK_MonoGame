using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonogameProyect.Content.Code
{
    internal class SpriteRenderer
    {
        private Texture2D spriteTexture;
        private Vector2 spritePosition;
        private Vector2 nonUniformScale = Vector2.One;
         
        public void LoadContent(Game1 game1, string spriteName)
        {
            spriteTexture = game1.Content.Load<Texture2D>(spriteName);
        }

        public void DrawSprite(Game1 game1)
        {
            game1.GetSpriteBatch.Begin();
            game1.GetSpriteBatch.Draw(spriteTexture, spritePosition, null,
                Color.White, 0f, Vector2.Zero, nonUniformScale, SpriteEffects.None, 0f);

            game1.GetSpriteBatch.End();
        }

        public void SetSpritePosition(Vector2 value)
        {
            spritePosition = value;
        }

        public void SetSpriteScale(Vector2 value) 
        {
            nonUniformScale = value;
        }
    }
}
