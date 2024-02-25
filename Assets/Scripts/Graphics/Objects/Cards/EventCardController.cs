
using UnityEngine;
using UnityEngine.EventSystems;

namespace usea.graphics.controller
{
    /// <summary>
    /// Controller for event card Gui. 
    /// </summary>
    public partial class EventCardController : Controller
    {
        // ###### PUBLIC ######
        public uint GetId() { return m_id; }
        public partial void Show();
        public partial void Hide();

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.EventCardView m_view;
        private static usea.util.UniqueIdGenerator m_idGenerator = new usea.util.UniqueIdGenerator();
        private uint m_id;
    }

    public partial class EventCardController : Controller
    {
        public partial void Show()
        {
            gameObject.SetActive(true);
        }

        public partial void Hide()
        {
            gameObject.SetActive(false);
        }

        protected override partial void Initialize()
        {
            m_id = m_idGenerator.GenerateId();

            gui.Image art = m_view.GetArt();
            gui.GuiBase mouseEventCatcher = m_view.GetMouseEventCatcher();

            // TODO: Make utility function/class for providing this common functionality.
            mouseEventCatcher.AddOnPointerEnterCallback((PointerEventData eventData) =>
            {
                art.ChangeColour(gui.Image.ColourMode.HOVER);
            });

            mouseEventCatcher.AddOnPointerExitCallback((PointerEventData eventData) =>
            {
                art.ChangeColour(gui.Image.ColourMode.NORMAL);
            });

            mouseEventCatcher.AddOnPointerDownCallback((PointerEventData eventData) =>
            {
                art.ChangeColour(gui.Image.ColourMode.CLICK);
            });

            mouseEventCatcher.AddOnPointerUpCallback((PointerEventData eventData) =>
            {
                art.ChangeColour(mouseEventCatcher.IsCursorOnThisObject() ? gui.Image.ColourMode.HOVER : gui.Image.ColourMode.NORMAL);
            });
        }
    }
}