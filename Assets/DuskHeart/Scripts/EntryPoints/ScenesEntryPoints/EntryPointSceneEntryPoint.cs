using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuskHeart.Scripts.EntryPoints.ScenesEntryPoints
{
    public class EntryPointSceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject entryPointCanvas;

        private IEnumerator Start()
        {
            Instantiate(entryPointCanvas);
            yield return SceneManager.LoadSceneAsync("MainMenuScene");
        }
    }
}