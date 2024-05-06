

using Game;

namespace Vault
{
    public class ContextController : Registere
    {
        public override void Initial()
        {
            AddObserver(EventManager.Instance);
            AddObserver(new LevelController());
            AddObserver(new CharacterSelectionController());
      
        }

        public override void Enable()
        {
           
        }

        public override void OnShow()
        {

        }
    }
}

