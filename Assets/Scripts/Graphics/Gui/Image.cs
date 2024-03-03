
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting;

namespace usea.graphics.gui
{
    /// <summary>
    /// Custom Gui image. Handles colour transitions on mouse events. Can optionally be draggable.
    /// </summary>
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

        public enum ColourMode
        {
            NORMAL,
            HOVER,
            CLICK
        }

        // ###### PUBLIC ######
        public partial void ChangeColour(ColourMode colourMode);
        public partial void ChangeSprite(Sprite sprite);

        // ###### PROTECTED ######
        protected override partial void Constructor();
        protected override void InitializeDependencies() { }

        // ###### PRIVATE ######
        private partial void SetColourListeners();
        [Header("Colour")]
        [SerializeField] private ColourSettings m_boxColour;
        [SerializeField] private bool m_isDraggable = false;

        private util.ObjectDragger m_objectDragger;
        private UnityEngine.UI.Image m_image;
        private bool m_isCursorOnThisObject;
    }

    public partial class Image : GuiBase
    {
        public partial void ChangeColour(ColourMode colourMode)
        {
            switch (colourMode)
            {
                case ColourMode.NORMAL:
                    m_image.color = m_boxColour.normal;
                    break;
                case ColourMode.HOVER:
                    m_image.color = m_boxColour.hover;
                    break;
                case ColourMode.CLICK:
                    m_image.color = m_boxColour.click;
                    break;
            }
        }

        public partial void ChangeSprite(Sprite sprite)
        {
            m_image.sprite = sprite;
        }

        protected override partial void Constructor()
        {
            m_isCursorOnThisObject = false;
            m_image = GetComponent<UnityEngine.UI.Image>();

            if (m_isDraggable)
            {
                m_objectDragger = gameObject.AddComponent<util.ObjectDragger>();
                m_objectDragger.Initialize(this, transform.parent.GetComponent<Transform>());
            }

            SetColourListeners();
        }

        private partial void SetColourListeners()
        {
            AddOnPointerEnterCallback((PointerEventData eventData) =>
            {
                if (m_isSelected) { return; } // Needed when dragging

                m_isCursorOnThisObject = true;
                ChangeColour(ColourMode.HOVER);
            });

            AddOnPointerExitCallback((PointerEventData eventData) =>
            {
                if (m_isSelected) { return; } // Needed when dragging

                m_isCursorOnThisObject = false;
                ChangeColour(ColourMode.NORMAL);

            });

            AddOnPointerDownCallback((PointerEventData eventData) =>
            {
                ChangeColour(ColourMode.CLICK);
            });

            AddOnPointerUpCallback((PointerEventData eventData) =>
            {
                ChangeColour(m_isCursorOnThisObject ? ColourMode.HOVER : ColourMode.NORMAL);
            });
        }
    }
}