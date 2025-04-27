using DuskHeart.Scripts.Data;
using DuskHeart.Scripts.EventBus.Signals.UISignals;
using UnityEngine;

namespace DuskHeart.Scripts.UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        private WorldLoader _worldLoader;

        public void Initialize(GameObject worldLoader)
        {
            _worldLoader = worldLoader.GetComponent<WorldLoader>();
            gameObject.SetActive(true);
        }
        
        private void Awake()
        {
            EventBus.EventBus.Subscribe<ButtonClickSignal>(OnNewGameButtonClick);
            EventBus.EventBus.Subscribe<ButtonClickSignal>(OnExitButtonClick);
        }

        private void OnDestroy()
        {
            EventBus.EventBus.Unsubscribe<ButtonClickSignal>(OnNewGameButtonClick);
            EventBus.EventBus.Unsubscribe<ButtonClickSignal>(OnExitButtonClick);
        }

        private void OnNewGameButtonClick(ButtonClickSignal signal)
        {
            if (signal.ButtonName != "NewGame") return; 
            StartCoroutine(_worldLoader.Load());
        }

        private void OnExitButtonClick(ButtonClickSignal signal)
        {
            if (signal.ButtonName != "Exit") return; 
            Application.Quit();
        }
    }
}