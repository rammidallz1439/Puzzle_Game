

using Game;

namespace Vault
{
    public class ContextController : Registere
    {
        public override void Initial()
        {
            AddObserver(EventManager.Instance);
            AddObserver(new LevelController());
      
        }

        public override void Enable()
        {
           
        }

        public override void OnShow()
        {

        }
    }
}

