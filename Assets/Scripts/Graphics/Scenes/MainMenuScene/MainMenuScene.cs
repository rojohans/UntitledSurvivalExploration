
using UnityEngine;

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
        protected override void Show() { }
        protected override void Hide() { }

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
            m_view.m_newgameButton.AddOnPointerClickCallback(() => { m_onOpenNewGameMenu(); });
            m_view.m_settingsButton.AddOnPointerClickCallback(() => { m_onOpenSettings(); });
            m_view.m_aboutButton.AddOnPointerClickCallback(() => { m_onOpenAbout(); });
            m_view.m_closeProgramButton.AddOnPointerClickCallback(() => { m_onCloseProgram(); });
        }
    }
}