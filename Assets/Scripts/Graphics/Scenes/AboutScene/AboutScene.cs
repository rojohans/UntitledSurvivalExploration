
using UnityEngine;

namespace usea.graphics.scene
{
    /// <summary>
    /// This scene acts as a sort of README. It should give the user some background information, and possible a text based description of what the game is about.
    /// </summary>
    public partial class AboutScene : controller.Controller
    {
        // ###### PUBLIC ######
        public partial void SetCallbacks(util.types.Callback onClose);

        // ###### PROTECTED ######
        protected override partial void Initialize();
        protected override void Show() { }
        protected override void Hide() { }

        // ###### PRIVATE ######
        [SerializeField] private view.AboutSceneView m_view;
        private util.types.Callback m_onClose;
    }

    public partial class AboutScene : controller.Controller
    {
        public partial void SetCallbacks(util.types.Callback onClose)
        {
            m_onClose = onClose;
        }

        protected override partial void Initialize()
        {
            m_view.m_backButton.AddOnPointerClickCallback(() => { m_onClose(); });
        }
    }
}