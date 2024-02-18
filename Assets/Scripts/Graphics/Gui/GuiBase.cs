
using UnityEngine.EventSystems;

namespace usea.graphics.gui
{
    /// <summary>
    /// Base class for all custom gui elements. Adds tooltip support.
    /// </summary>
    public abstract partial class GuiBase : EventEnabled
    {
        //###### PUBLIC ######
        public partial void Start();
        public partial void SetTooltip(string message);

        //###### PROTECTED ######
        protected abstract void Initialize();

        //###### PRIVATE ######
        private controller.TooltipController m_tooltipController;
    }

    public abstract partial class GuiBase : EventEnabled
    {
        public partial void Start()
        {
            m_tooltipController = (controller.TooltipController)GuiManager.Get().GetObject(GuiObjectTypeE.TOOLTIP);
            Initialize();
        }

        /// <summary>
        /// Enables tooltip functionality for the gui element.
        /// </summary>
        /// <param name="message"></param>
        public partial void SetTooltip(string message)
        {
            AddOnPointerEnterCallback((PointerEventData eventData) =>
            {
                m_tooltipController.Activate(message);
            });

            AddOnPointerExitCallback((PointerEventData eventData) =>
            {
                m_tooltipController.Deactivate();
            });
        }
    }
}