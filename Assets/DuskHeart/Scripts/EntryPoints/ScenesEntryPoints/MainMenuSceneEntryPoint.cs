using DuskHeart.Scripts.UI.MainMenu;
using UnityEngine;

namespace DuskHeart.Scripts.EntryPoints.ScenesEntryPoints
{
    public class MainMenuSceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject eventSystem;
        [SerializeField] private GameObject worldLoader;
        [SerializeField] private GameObject mainMenuCanvas;
        [SerializeField] private GameObject pressAnyKeyText;
        [SerializeField] private GameObject mainMenuButtons;
        [SerializeField] private GameObject backgroundVideoRawImage;
        [SerializeField] private GameObject mainMenuUIController;
        [SerializeField] private GameObject mainMenuController;

        private void Start()
        {
            Instantiate(eventSystem);

            var loader = Instantiate(worldLoader);
            var canvas = Instantiate(mainMenuCanvas);
            var video = Instantiate(backgroundVideoRawImage, canvas.transform);
            var anyKeyText = Instantiate(pressAnyKeyText, canvas.transform);
            var buttons = Instantiate(mainMenuButtons, canvas.transform);
            
            var uiController = Instantiate(mainMenuUIController);
            var menuController = Instantiate(mainMenuController);

            uiController.GetComponent<MainMenuUIController>().Initialize(anyKeyText, buttons);
            menuController.GetComponent<MainMenuController>().Initialize(loader);
        }
    }
}