
namespace usea.graphics.controller
{
    /// <summary>
    /// This class invokes callbacks each frame. Other classes might register callbacks to be invoked.
    /// </summary>
    public partial class FrameTicker : Controller
    {
        // ###### PUBLIC ######
        public partial void Update();
        public partial void RegisterCallback(util.types.Callback callback);

        // ###### PROTECTED ######
        protected override void Initialize() { }
        protected override void Show() { }
        protected override void Hide() { }

        // ###### PRIVATE ######
        private util.types.Callback m_onUpdate;
    }

    public partial class FrameTicker : Controller
    {
        public partial void Update()
        {
            m_onUpdate?.Invoke();
        }

        /// <summary>
        /// The registered callback will be invoked each frame.
        /// </summary>
        /// <param name="callback"></param>
        public partial void RegisterCallback(util.types.Callback callback)
        {
            m_onUpdate += callback;
        }
    }
}
