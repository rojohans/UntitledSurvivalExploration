
using UnityEngine;
using UnityEngine.EventSystems;
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
        public partial void SetCallbacks(usea.util.types.Callback onOpenAbout,
                                         usea.util.types.Callback onOpenSettings,
                                         usea.util.types.Callback onOpenNewGameMenu,
                                         usea.util.types.Callback onCloseProgram);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.MainMenuView m_view;
        private usea.util.types.Callback m_onOpenAbout;
        private usea.util.types.Callback m_onOpenSettings;
        private usea.util.types.Callback m_onOpenNewGameMenu;
        private usea.util.types.Callback m_onCloseProgram;
    }

    public partial class MainMenuScene : controller.Controller
    {
        public partial void SetCallbacks(usea.util.types.Callback onOpenAbout,
                                         usea.util.types.Callback onOpenSettings,
                                         usea.util.types.Callback onOpenNewGameMenu,
                                         usea.util.types.Callback onCloseProgram)
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

            m_view.m_newgameButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onOpenNewGameMenu(); });
            m_view.m_newgameButton.AddOnPointerClickCallback((PointerEventData eventData) =>
            {
                // TEMPORARY: This is just for testing.
                new EngineWrapper(new ExampleTask()).Schedule(() => { print("Task 1 is done"); });
                new EngineWrapper(new ExampleTask()).Schedule(() => { print("Task 2 is done"); }, true);
                new EngineWrapper(new ExampleTask()).Schedule(() => { print("Task 3 is done"); });
            });

            m_view.m_settingsButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onOpenSettings(); });
            m_view.m_aboutButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onOpenAbout(); });
            m_view.m_closeProgramButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onCloseProgram(); });
        }
    }
}