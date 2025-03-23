using Utilities;

namespace DuskHeart.Scripts.Character.Player
{
    public class PlayerCameraManager : MonoSingleton<PlayerCameraManager>
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
