
using UnityEngine;

namespace usea.graphics.scene
{
    /// <summary>
    /// This scene will contain all global settings to the program that the user can make. Things like resolution and sound/music volume.
    /// </summary>
    public partial class SettingsScene : controller.Controller
    {
        // ###### PUBLIC ######
        public partial void SetCallbacks(util.types.Callback onClose);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.SettingsSceneView m_view;
        private util.types.Callback m_onClose;
    }

    public partial class SettingsScene : controller.Controller
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