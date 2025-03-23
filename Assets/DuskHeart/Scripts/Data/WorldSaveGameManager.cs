using System.Collections;
using UnityEngine.SceneManagement;
using Utilities;

namespace DuskHeart.Scripts.Data
{
    public class WorldSaveGameManager : MonoSingleton<WorldSaveGameManager>
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public IEnumerator LoadNewGame()
        {
            yield return SceneManager.LoadSceneAsync($"OverworldScene");
        }
    }
}
