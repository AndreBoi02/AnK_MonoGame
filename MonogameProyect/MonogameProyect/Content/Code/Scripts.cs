

namespace MonogameProyect.Content.Code
{
    internal class Scripts
    {
        protected GameObject _gameObject;

        public virtual void InitializeScript(){}
        public virtual void ExecuteScript(){}

        public void SetGameObeject(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
    }
}
