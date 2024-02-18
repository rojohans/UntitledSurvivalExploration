
using UnityEngine;
using UnityEngine.EventSystems;

namespace usea.graphics.scene
{
    /// <summary>
    /// This scene is where all the gameplay takes place. It is possible this scene will need to be subdivided.
    /// </summary>
    public partial class GameSessionScene : controller.Controller
    {
        // ###### PUBLIC ######
        public partial void SetCallbacks(usea.util.types.Callback onOpenSettings,
                                         usea.util.types.Callback onClose,
                                         usea.util.types.Callback onCloseProgram);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.GameSessionView m_view;
        private usea.util.types.Callback m_onOpenSettings;
        private usea.util.types.Callback m_onClose;
        private usea.util.types.Callback m_onCloseProgram;
    }

    public partial class GameSessionScene : controller.Controller
    {
        public partial void SetCallbacks(usea.util.types.Callback onOpenSettings,
                                         usea.util.types.Callback onClose,
                                         usea.util.types.Callback onCloseProgram)
        {
            m_onOpenSettings = onOpenSettings;
            m_onClose = onClose;
            m_onCloseProgram = onCloseProgram;
        }

        protected override partial void Initialize()
        {
            m_view.m_mainMenuButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onClose(); });
            m_view.m_settingsButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onOpenSettings(); });
            m_view.m_quitProgramButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onCloseProgram(); });
        }
    }
}