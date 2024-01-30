
using UnityEngine;

namespace usea.graphics.controller
{
    public abstract partial class Controller : MonoBehaviour
    {
        // ###### PUBLIC ######
        public partial void OnEnable();
        public partial void OnDisable();

        // ###### PROTECTED ######
        protected abstract void Initialize();
        protected abstract void Show(); // Question: Is this really needed?
        protected abstract void Hide(); // Question: Is this really needed?

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