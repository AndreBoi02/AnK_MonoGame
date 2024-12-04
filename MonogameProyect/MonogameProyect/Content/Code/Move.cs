using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProyect.Content.Code
{
    internal class Move : Scripts
    {
        float velX;
        float velY;

        public override void InitializeScript()
        {
            base.InitializeScript();
            velX = 0;
            velY = 0;
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
