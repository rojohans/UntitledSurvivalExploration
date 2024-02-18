
using UnityEngine;

namespace usea.graphics.controller
{
    /// <summary>
    /// Base class for all coordinators/controllers in a mvc (Model, View, Controller) triplet.
    /// </summary>
    public abstract partial class Controller : MonoBehaviour
    {
        // ###### PUBLIC ######
        public partial void Awake();

        // ###### PROTECTED ######
        /// <summary>
        /// Used for settings callbacks for all owned gui objects.
        /// </summary>
        protected abstract void Initialize();

        // ###### PRIVATE ######
        private bool m_isInitialized;
        [SerializeField] private GuiObjectTypeE m_name;
    }

    public abstract partial class Controller
    {
        public partial void Awake()
        {
            Initialize();
            GuiManager.Get().RegisterObject(m_name, this);
        }
    }
}