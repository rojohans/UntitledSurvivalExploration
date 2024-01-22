
using UnityEngine;

namespace usea.graphics.controller
{
    public abstract partial class Controller<modelT, viewT> : MonoBehaviour
    {
        // ====== PUBLIC ======
        public partial void OnEnable();
        public partial void OnDisable();

        // ====== PROTECTED ======
        protected abstract void Initialize();
        protected abstract void Show();
        protected abstract void Hide();

        // ====== PRIVATE ======
        private bool m_isInitialized;
        public modelT m_model;
        public viewT m_view;
    }

    public abstract partial class Controller<modelT, viewT>
    {
        // ====== PUBLIC ======
        public partial void OnEnable()
        {
            if (!m_isInitialized)
            {
                Initialize();
            }

            Show();
        }

        public partial void OnDisable()
        {
            Hide();
        }
    }
}