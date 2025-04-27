using DuskHeart.Scripts.EventBus.Signals.UISignals;
using UnityEngine;
using UnityEngine.UI;

namespace DuskHeart.Scripts.UI.MainMenu
{
	public class MainMenuButtonsBehaviour : MonoBehaviour
	{
		[SerializeField] private Button continueButton;
		[SerializeField] private Button newGameButton;
		[SerializeField] private Button loadGameButton;
		[SerializeField] private Button settingsButton;
		[SerializeField] private Button exitButton;
		
		private void Awake()
		{
			continueButton.onClick.AddListener(ContinueButtonClick);
			newGameButton.onClick.AddListener(NewGameButtonClick);
			loadGameButton.onClick.AddListener(LoadGameButtonClick);
			settingsButton.onClick.AddListener(SettingsButtonClick);
			exitButton.onClick.AddListener(ExitButtonClick);
		}

		private void OnDestroy()
		{
			continueButton.onClick.RemoveListener(ContinueButtonClick);
			newGameButton.onClick.RemoveListener(NewGameButtonClick);
			loadGameButton.onClick.RemoveListener(LoadGameButtonClick);
			settingsButton.onClick.RemoveListener(SettingsButtonClick);
			exitButton.onClick.RemoveListener(ExitButtonClick);
		}

		private void ContinueButtonClick() => EventBus.EventBus.Invoke(new ButtonClickSignal("ContinueGame"));
		private void NewGameButtonClick() => EventBus.EventBus.Invoke(new ButtonClickSignal("NewGame"));

		private void LoadGameButtonClick() => EventBus.EventBus.Invoke(new ButtonClickSignal("LoadGame"));
		private void SettingsButtonClick() => EventBus.EventBus.Invoke(new ButtonClickSignal("Settings"));
		private void ExitButtonClick() => EventBus.EventBus.Invoke(new ButtonClickSignal("Exit"));
	}
}
