using DuskHeart.Scripts.Data;
using UnityEngine;
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
        
        private void StartNewGame() => StartCoroutine(WorldSaveGameManager.Instance.LoadNewGame());
    }
}
