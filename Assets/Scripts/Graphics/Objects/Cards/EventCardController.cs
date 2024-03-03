
using UnityEngine;
using UnityEngine.EventSystems;
using usea.data.gameplay;

namespace usea.graphics.controller
{
    /// <summary>
    /// Controller for event card Gui. 
    /// </summary>
    public partial class EventCardController : Controller
    {
        // ###### PUBLIC ######
        public partial void ResetAppearance(EventCardProperties template);
        public uint GetId() { return m_id; }
        public partial void Show();
        public partial void Hide();

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        private partial void OnPointerEnter();
        private partial void OnPointerExit();
        private partial void OnPointerDown();
        private partial void OnPointerUp();

        private const float NORMAL_SCALE = 1f;
        private const float HOVER_SCALE = 1.1f;
        private const float SELECTED_SCALE = 1.2f;
        [SerializeField] private view.EventCardView m_view;
        private static usea.util.UniqueIdGenerator m_idGenerator = new usea.util.UniqueIdGenerator();
        private static bool m_isCardSelected;
        private util.ControllerAccessor<SimpleController> m_selectedCardHolderAccessor;
        private util.ControllerAccessor<EventCardPoolManager> m_cardPoolAccessor;
        private gui.GuiBase m_mouseEventCatcher;
        private uint m_id;
    }

    public partial class EventCardController : Controller
    {
        /// <summary>
        /// Updates the visual aspect of the card.
        /// </summary>
        /// <param name="template"></param>
        public partial void ResetAppearance(EventCardProperties template)
        {
            m_view.ResetAppearance(template.title, template.description, template.priority, template.image);
        }

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
            m_mouseEventCatcher = m_view.GetMouseEventCatcher();
            m_selectedCardHolderAccessor = new util.ControllerAccessor<SimpleController>(GuiObjectTypeE.SELECTED_CARD_HOLDER);
            m_cardPoolAccessor = new util.ControllerAccessor<EventCardPoolManager>(GuiObjectTypeE.EVENT_CARD_POOL_MANAGER);

            m_mouseEventCatcher.AddOnPointerEnterCallback((PointerEventData eventData) =>
            {
                OnPointerEnter();
            });

            m_mouseEventCatcher.AddOnPointerExitCallback((PointerEventData eventData) =>
            {
                OnPointerExit();
            });

            m_mouseEventCatcher.AddOnPointerDownCallback((PointerEventData eventData) =>
            {
                OnPointerDown();
            });

            m_mouseEventCatcher.AddOnPointerUpCallback((PointerEventData eventData) =>
            {
                OnPointerUp();
            });
        }

        private partial void OnPointerEnter()
        {
            if (m_isCardSelected)
            {
                return;
            }
            transform.SetParent(m_selectedCardHolderAccessor.Get().transform);
            m_view.SetScale(HOVER_SCALE);
            m_view.GetArt().ChangeColour(gui.Image.ColourMode.HOVER);
        }

        private partial void OnPointerExit()
        {
            if (m_isCardSelected)
            {
                return;
            }
            transform.SetParent(m_cardPoolAccessor.Get().transform);
            m_view.SetScale(NORMAL_SCALE);
            m_view.GetArt().ChangeColour(gui.Image.ColourMode.NORMAL);
        }

        private partial void OnPointerDown()
        {
            m_isCardSelected = true;
            m_view.SetScale(SELECTED_SCALE);
            m_view.GetArt().ChangeColour(gui.Image.ColourMode.CLICK);
        }

        private partial void OnPointerUp()
        {
            m_isCardSelected = false;
            m_view.SetScale(m_mouseEventCatcher.IsCursorOnThisObject() ? HOVER_SCALE : NORMAL_SCALE);
            m_view.GetArt().ChangeColour(m_mouseEventCatcher.IsCursorOnThisObject() ? gui.Image.ColourMode.HOVER : gui.Image.ColourMode.NORMAL);
        }
    }
}