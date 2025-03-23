using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DuskHeart.Scripts.UI
{
    public class TitleScreenManager : MonoBehaviour
    {
        [SerializeField] private Button pressStartButton;
        [SerializeField] private Button newGameButton;

        private void Awake()
        {
            pressStartButton.onClick.AddListener(PressStartButtonClick);
            newGameButton.onClick.AddListener(StartNewGame);
        }

        private void OnDestroy()
        {
            pressStartButton.onClick.RemoveListener(PressStartButtonClick);
            newGameButton.onClick.RemoveListener(StartNewGame);
        }

        private void PressStartButtonClick()
        {
            pressStartButton.gameObject.SetActive(false);
            newGameButton.gameObject.SetActive(true);
        }
        
        private static void StartNewGame()
        {
            SceneManager.LoadScene($"OverworldScene");
        }
    }
}
