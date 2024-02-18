
using UnityEngine;

namespace usea.graphics.scene
{
    /// <summary>
    /// This scene lets the user customize the game settings before launching a game session.
    /// </summary>
    public partial class NewGameMenuScene : controller.Controller
    {
        // ###### PUBLIC ######
        public partial void SetCallbacks(util.types.Callback onClose,
                                         util.types.Callback onStartNewGameSession,
                                         util.types.Callback onOpenSettings);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.NewGameMenuView m_view;
        private util.types.Callback m_onClose;
        private util.types.Callback m_onStartNewGameSession;
        private util.types.Callback m_onOpenSettings;
    }

    public partial class NewGameMenuScene : controller.Controller
    {
        public partial void SetCallbacks(util.types.Callback onClose,
                                         util.types.Callback onStartNewGameSession,
                                         util.types.Callback onOpenSettings)
        {
            m_onClose = onClose;
            m_onStartNewGameSession = onStartNewGameSession;
            m_onOpenSettings = onOpenSettings;
        }

        protected override partial void Initialize()
        {
            m_view.m_startGameButton.AddOnPointerClickCallback(() => { m_onStartNewGameSession(); });
            m_view.m_settingsButton.AddOnPointerClickCallback(() => { m_onOpenSettings(); });
            m_view.m_backButton.AddOnPointerClickCallback(() => { m_onClose(); });
        }
    }
}