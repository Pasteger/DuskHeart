using System.Collections;
using DuskHeart.Scripts.UI.Utilities;
using UnityEngine;

namespace DuskHeart.Scripts.UI.MainMenu
{
	public class MainMenuUIController : MonoBehaviour
	{
		[SerializeField] private CanvasGroupFadeController canvasGroupFadeControllerPrefab;

		private CanvasGroup _pressAnyKeyText;
		private CanvasGroup _mainMenuButtons;

		public void Initialize(GameObject pressAnyKeyText, GameObject mainMenuButtons)
		{
			_pressAnyKeyText = pressAnyKeyText.GetComponent<CanvasGroup>();
			_mainMenuButtons = mainMenuButtons.GetComponent<CanvasGroup>();
			gameObject.SetActive(true);
		}
		
		private IEnumerator Start()
		{
			var canvasGroupFadeController = Instantiate(canvasGroupFadeControllerPrefab);
			yield return canvasGroupFadeController.Show(_pressAnyKeyText, 1);
			yield return new WaitUntil(() => Input.anyKey);
			yield return canvasGroupFadeController.Hide(_pressAnyKeyText, 1);
			yield return canvasGroupFadeController.Show(_mainMenuButtons, 1);
		}
	}
}
