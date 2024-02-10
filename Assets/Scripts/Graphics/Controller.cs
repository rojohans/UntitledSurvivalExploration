
using UnityEngine;

namespace usea.graphics.controller
{
    /// <summary>
    /// Base class for all coordinators/controllers in a mvc (Model, View, Controller) triplet.
    /// </summary>
    public abstract partial class Controller : MonoBehaviour
    {
        // ###### PUBLIC ######
        public partial void OnEnable();
        public partial void OnDisable();

        // ###### PROTECTED ######
        /// <summary>
        /// Used for settings callbacks for all owned gui objects.
        /// </summary>
        protected abstract void Initialize();
        protected abstract void Show(); // QUESTION: Is this really needed?
        protected abstract void Hide(); // QUESTION: Is this really needed?

        // ###### PRIVATE ######
        private bool m_isInitialized;
        [SerializeField] private GuiObjectTypeE m_name;
    }

    public abstract partial class Controller
    {
        public partial void OnEnable()
        {
            if (!m_isInitialized)
            {
                m_isInitialized = true;
                Initialize();
                GuiManager.Get().RegisterObject(m_name, this);
            }

            Show();
        }

        public partial void OnDisable()
        {
            Hide();
        }
    }
}