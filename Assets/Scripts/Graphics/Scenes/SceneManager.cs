
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
        private partial void SwitchScene(MonoBehaviour newScene);
        private partial void OpenAbout();
        private partial void CloseAbout();
        private partial void OpenSettings();
        private partial void CloseSettings();
        private partial void OpenNewGameMenu();
        private partial void CloseNewGameMenu();
        private partial void StartNewGameSession();
        private partial void CloseGameSession();
        private partial void CloseProgram();

        [SerializeField] private MainMenuScene m_mainMenuScene;
        [SerializeField] private AboutScene m_aboutScene;
        [SerializeField] private SettingsScene m_settingsScene;
        [SerializeField] private NewGameMenuScene m_newGameMenuScene;
        [SerializeField] private GameSessionScene m_gameSessionScene;

        private MonoBehaviour m_activeScene;
        private MonoBehaviour m_previousScene;
    }

    public partial class SceneManager : controller.Controller
    {
        protected override partial void Initialize()
        {
            m_mainMenuScene.SetCallbacks(OpenAbout, OpenSettings, OpenNewGameMenu, CloseProgram);
            m_aboutScene.SetCallbacks(CloseAbout);
            m_settingsScene.SetCallbacks(CloseSettings);
            m_newGameMenuScene.SetCallbacks(CloseNewGameMenu, StartNewGameSession, OpenSettings);
            m_gameSessionScene.SetCallbacks(OpenSettings, CloseGameSession, CloseProgram);

            m_mainMenuScene.gameObject.SetActive(true);
            m_aboutScene.gameObject.SetActive(false);
            m_settingsScene.gameObject.SetActive(false);
            m_newGameMenuScene.gameObject.SetActive(false);
            m_gameSessionScene.gameObject.SetActive(false);

            m_activeScene = null;
            SwitchScene(m_mainMenuScene);
        }

        private partial void SwitchScene(MonoBehaviour newScene)
        {
            m_activeScene?.gameObject.SetActive(false);
            m_previousScene = m_activeScene;
            m_activeScene = newScene;
            m_activeScene.gameObject.SetActive(true);
        }

        private partial void OpenAbout()
        {
            SwitchScene(m_aboutScene);
        }

        private partial void CloseAbout()
        {
            SwitchScene(m_mainMenuScene);
        }

        private partial void OpenSettings()
        {
            SwitchScene(m_settingsScene);
        }

        private partial void CloseSettings()
        {
            SwitchScene(m_previousScene);
        }

        private partial void OpenNewGameMenu()
        {
            SwitchScene(m_newGameMenuScene);
        }

        private partial void CloseNewGameMenu()
        {
            SwitchScene(m_mainMenuScene);
        }

        private partial void StartNewGameSession()
        {
            SwitchScene(m_gameSessionScene);
        }

        private partial void CloseGameSession()
        {
            SwitchScene(m_mainMenuScene);
        }

        private partial void CloseProgram()
        {
            Application.Quit();
        }
    }
}