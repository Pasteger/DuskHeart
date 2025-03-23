using Utilities;

namespace DuskHeart.Scripts.UI
{
    public class PlayerUIController : MonoSingleton<PlayerUIController>
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
