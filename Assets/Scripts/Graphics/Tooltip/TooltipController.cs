
namespace usea.graphics.controller
{
    /// <summary>
    /// Used for showing text on mouse hover for other gui objects.
    /// </summary>
    public partial class TooltipController : Controller
    {
        // ###### PUBLIC ######
        public partial void Update();
        public partial void Activate(string message);
        public partial void Deactivate();

        // ###### PROTECTED ######
        protected override partial void Initialize();
        protected override partial void Show();
        protected override partial void Hide();

        // ###### PRIVATE ######
        [UnityEngine.SerializeField] private view.TooltipView m_view;
    }

    public partial class TooltipController : Controller
    {
        public partial void Update()
        {
            m_view.UpdatePosition();
        }

        public partial void Activate(string message)
        {
            gameObject.SetActive(true);
            m_view.SetMessage(message);
        }

        public partial void Deactivate()
        {
            gameObject.SetActive(false);
        }

        protected override partial void Initialize()
        {
            Deactivate();
        }

        protected override partial void Show()
        {
        }

        protected override partial void Hide()
        {
        }
    }
}