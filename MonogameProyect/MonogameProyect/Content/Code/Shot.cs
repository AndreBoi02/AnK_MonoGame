using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace MonogameProyect.Content.Code
{
    internal class Shot : Scripts
    {
        public override void InitializeScript()
        {
            base.InitializeScript();
        }

        public override void ExecuteScript()
        {
            base.ExecuteScript();
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("POW");
                //_gameObject.Instantiate(new GameObject(new SpriteRenderer(), new Transform(), new Bullets()));
            }
        }
    }
}
