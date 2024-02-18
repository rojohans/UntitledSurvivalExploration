
using UnityEngine;
using usea.func.engine;
using usea.func.task;

namespace usea.graphics.scene
{
    /// <summary>
    /// This scene is active on start up, and will be the first interface the user is faced with.
    /// </summary>
    public partial class MainMenuScene : controller.Controller
    {
        // ###### PUBLIC ######
        public partial void SetCallbacks(util.types.Callback onOpenAbout,
                                         util.types.Callback onOpenSettings,
                                         util.types.Callback onOpenNewGameMenu,
                                         util.types.Callback onCloseProgram);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.MainMenuView m_view;
        private util.types.Callback m_onOpenAbout;
        private util.types.Callback m_onOpenSettings;
        private util.types.Callback m_onOpenNewGameMenu;
        private util.types.Callback m_onCloseProgram;
    }

    public partial class MainMenuScene : controller.Controller
    {
        public partial void SetCallbacks(util.types.Callback onOpenAbout,
                                         util.types.Callback onOpenSettings,
                                         util.types.Callback onOpenNewGameMenu,
                                         util.types.Callback onCloseProgram)
        {
            m_onOpenAbout = onOpenAbout;
            m_onOpenSettings = onOpenSettings;
            m_onOpenNewGameMenu = onOpenNewGameMenu;
            m_onCloseProgram = onCloseProgram;
        }

        protected override partial void Initialize()
        {
            // TEMPORARY: For testing tooltips.
            m_view.m_closeProgramButton.SetTooltip("Are you sure you want to end the game?");

            m_view.m_newgameButton.AddOnPointerClickCallback(() => { m_onOpenNewGameMenu(); });
            m_view.m_newgameButton.AddOnPointerClickCallback(() =>
            {
                // TEMPORARY: This is just for testing.
                new EngineWrapper(new ExampleTask()).Schedule(() => { print("Task 1 is done"); });
                new EngineWrapper(new ExampleTask()).Schedule(() => { print("Task 2 is done"); }, true);
                new EngineWrapper(new ExampleTask()).Schedule(() => { print("Task 3 is done"); });
            });

            m_view.m_settingsButton.AddOnPointerClickCallback(() => { m_onOpenSettings(); });
            m_view.m_aboutButton.AddOnPointerClickCallback(() => { m_onOpenAbout(); });
            m_view.m_closeProgramButton.AddOnPointerClickCallback(() => { m_onCloseProgram(); });
        }
    }
}