using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProyect.Content.Code
{
    internal class Bullets : Scripts
    {
        float speed;

        public override void InitializeScript()
        {
            base.InitializeScript();
            speed = _gameObject.GetTrasform.GetPosition.Y;
        }

        public override void ExecuteScript()
        {
            base.ExecuteScript();
            speed += .1f;
            _gameObject.GetTrasform.PosY(speed);
        }
    }
}
