
using UnityEngine;
using UnityEngine.EventSystems;

namespace usea.graphics.gui
{
    public partial class Image : GuiBase
    {
        // ###### TYPES ######
        [System.Serializable]
        private struct ColourSettings
        {
            public Color normal;
            public Color hover;
            public Color click;
        };

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        private partial void SetColourListeners();
        private partial void InitializeMouseDragging();
        [Header("Colour")]
        [SerializeField] private ColourSettings m_boxColour;

        private util.ObjectDragger m_objectDragger;
        private UnityEngine.UI.Image m_image;
        private bool m_isCursorOnThisObject;
    }

    public partial class Image : GuiBase
    {
        protected override partial void Initialize()
        {
            m_isCursorOnThisObject = false;
            m_image = GetComponent<UnityEngine.UI.Image>();

            SetColourListeners();
            InitializeMouseDragging();
        }

        private partial void SetColourListeners()
        {
            AddOnPointerEnterCallback((PointerEventData eventData) =>
            {
                if (m_isSelected) { return; } // Needed when dragging

                m_isCursorOnThisObject = true;
                m_image.color = m_boxColour.hover;
            });

            AddOnPointerExitCallback((PointerEventData eventData) =>
            {
                if (m_isSelected) { return; } // Needed when dragging

                m_isCursorOnThisObject = false;
                m_image.color = m_boxColour.normal;

            });
            AddOnPointerDownCallback((PointerEventData eventData) =>
            {
                m_image.color = m_boxColour.click;
            });
            AddOnPointerUpCallback((PointerEventData eventData) =>
            {
                m_image.color = m_isCursorOnThisObject ? m_boxColour.hover : m_boxColour.normal;
            });
        }

        private partial void InitializeMouseDragging()
        {
            m_objectDragger = gameObject.AddComponent<util.ObjectDragger>();
            m_objectDragger.SetTranformToActOn(transform.parent.GetComponent<Transform>());

            AddOnPointerDownCallback((PointerEventData eventData) =>
            {
                m_objectDragger.SetCurrentMousePosition(Input.mousePosition);
                m_objectDragger.Activate();
            });

            AddOnPointerUpCallback((PointerEventData eventData) =>
            {
                m_objectDragger.Deactivate();
            });
        }
    }
}