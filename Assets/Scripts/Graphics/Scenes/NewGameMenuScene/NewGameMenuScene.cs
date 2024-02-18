
using UnityEngine;
using UnityEngine.EventSystems;

namespace usea.graphics.scene
{
    /// <summary>
    /// This scene lets the user customize the game settings before launching a game session.
    /// </summary>
    public partial class NewGameMenuScene : controller.Controller
    {
        // ###### PUBLIC ######
        public partial void SetCallbacks(usea.util.types.Callback onClose,
                                         usea.util.types.Callback onStartNewGameSession,
                                         usea.util.types.Callback onOpenSettings);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.NewGameMenuView m_view;
        private usea.util.types.Callback m_onClose;
        private usea.util.types.Callback m_onStartNewGameSession;
        private usea.util.types.Callback m_onOpenSettings;
    }

    public partial class NewGameMenuScene : controller.Controller
    {
        public partial void SetCallbacks(usea.util.types.Callback onClose,
                                         usea.util.types.Callback onStartNewGameSession,
                                         usea.util.types.Callback onOpenSettings)
        {
            m_onClose = onClose;
            m_onStartNewGameSession = onStartNewGameSession;
            m_onOpenSettings = onOpenSettings;
        }

        protected override partial void Initialize()
        {
            m_view.m_startGameButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onStartNewGameSession(); });
            m_view.m_settingsButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onOpenSettings(); });
            m_view.m_backButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onClose(); });
        }
    }
}