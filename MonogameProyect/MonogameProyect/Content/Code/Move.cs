using Microsoft.Xna.Framework.Input;

namespace MonogameProyect.Content.Code
{
    internal class Move : Scripts
    {
        float velX;
        float velY;

        public override void InitializeScript()
        {
            base.InitializeScript();
            velX = _gameObject.GetTrasform.GetPosition.X;
            velY = _gameObject.GetTrasform.GetPosition.Y;

        }

        public override void ExecuteScript()
        {
            base.ExecuteScript();
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
        }
    }
}
