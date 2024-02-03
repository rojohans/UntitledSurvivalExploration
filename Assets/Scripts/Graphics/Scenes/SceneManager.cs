
using UnityEngine;

namespace usea.graphics.scene
{
    /// <summary>
    /// Responsible for managing all scene transitions. It owns all scenes. And will inject individual scenes with callbacks that are used for transitions.
    /// </summary>
    public partial class SceneManager : controller.Controller
    {
        // ###### PROTECTED ######
        protected override partial void Initialize();
        protected override void Show() { }
        protected override void Hide() { }

        // ###### PRIVATE ######
        private partial void OpenAbout();
        private partial void CloseAbout();
        private partial void OpenSettings();
        private partial void CloseSettings();
        private partial void OpenNewGameMenu();
        private partial void CloseNewGameMenu();
        private partial void StartNewGameSession();
        private partial void CloseGameSession();

        // [SerializeField] private MainMenuScene m_mainMenu;
        // [SerializeField] private AboutScene m_about;
        // [SerializeField] private SettingsScene m_settings;
        // [SerializeField] private NewGameMenuScene m_newGameMenu;
        // [SerializeField] private GameSessionMenu m_gameSession;

        private MonoBehaviour m_activeScene;
        private MonoBehaviour m_previousScene;
    }

    public partial class SceneManager : controller.Controller
    {
        protected override partial void Initialize()
        {
            // m_mainMenu.gameObject.SetActive(true);
            // m_about.gameObject.SetActive(false);
            // m_settings.gameObject.SetActive(false);
            // m_newGameMenu.gameObject.SetActive(false);
            // m_gameSession.gameObject.SetActive(false);

            // m_mainMenu.SetCallbacks(OpenAbout, OpenSettings, OpenNewGameMenu);
            // m_about.SetCallbacks(CloseAbout);
            // m_settings.SetCallbacks(CloseSettings);
            // m_newGameMenu.SetCallbacks(CloseNewGameMenu, StartNewGameSession);
            // m_gameSession.SetCallbacks(OpenSettings, CloseGameSession);
        }

        private partial void OpenAbout()
        {
            // m_previousScene = m_activeScene;
            // m_activeScene = 
        }

        private partial void CloseAbout()
        {
        }

        private partial void OpenSettings()
        {
        }

        private partial void CloseSettings()
        {
        }

        private partial void OpenNewGameMenu()
        {
        }

        private partial void CloseNewGameMenu()
        {
        }

        private partial void StartNewGameSession()
        {
        }

        private partial void CloseGameSession()
        {
        }
    }
}