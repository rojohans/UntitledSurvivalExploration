
using UnityEngine;
using UnityEngine.EventSystems;

namespace usea.graphics.scene
{
    /// <summary>
    /// This scene acts as a sort of README. It should give the user some background information, and possible a text based description of what the game is about.
    /// </summary>
    public partial class AboutScene : controller.Controller
    {
        // ###### PUBLIC ######
        public partial void SetCallbacks(usea.util.types.Callback onClose);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.AboutSceneView m_view;
        private usea.util.types.Callback m_onClose;
    }

    public partial class AboutScene : controller.Controller
    {
        public partial void SetCallbacks(usea.util.types.Callback onClose)
        {
            m_onClose = onClose;
        }

        protected override partial void Initialize()
        {
            m_view.m_backButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onClose(); });
        }
    }
}