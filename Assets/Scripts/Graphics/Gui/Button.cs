using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace usea.graphics.gui
{
    /// <summary>
    /// A custom implementation of a button. Has more flexible callbacks than Unity's default button implementation.
    /// 
    /// @TODO: SetSoundListener functionality
    /// @TODO: SetImage functionality
    /// </summary>
    public partial class Button : GuiBase
    {
        // ###### TYPES ######
        [System.Serializable]
        private struct ColourSettings
        {
            public Color normal;
            public Color onPointerEnter;
            public Color onPointerClick;
        };

        // ###### PROTECTED ######
        protected override partial void Constructor();
        protected override void InitializeDependencies() { }

        // ###### PRIVATE ######
        private partial void SetColourListeners();
        [Header("Colour")]
        [SerializeField] private ColourSettings m_boxColour;
        [SerializeField] private ColourSettings m_textColour;

        [Header("Components")]
        [SerializeField] private UnityEngine.UI.Image m_image;
        [SerializeField] private TMP_Text m_text;
        private bool m_isCursorOnThisObject;
    }

    public partial class Button : GuiBase
    {
        protected override partial void Constructor()
        {
            m_isCursorOnThisObject = false;
            //SetSoundListeners();
            //SetTooltipListeners();
            SetColourListeners();
        }

        private partial void SetColourListeners()
        {
            AddOnPointerEnterCallback((PointerEventData eventData) =>
            {
                m_isCursorOnThisObject = true;
                m_image.color = m_boxColour.onPointerEnter;
                m_text.color = m_textColour.onPointerEnter;
            });
            AddOnPointerExitCallback((PointerEventData eventData) =>
            {
                m_isCursorOnThisObject = false;
                m_image.color = m_boxColour.normal;
                m_text.color = m_textColour.normal;
            });
            AddOnPointerDownCallback((PointerEventData eventData) =>
            {
                m_image.color = m_boxColour.onPointerClick;
                m_text.color = m_textColour.onPointerClick;
            });
            AddOnPointerUpCallback((PointerEventData eventData) =>
            {
                m_image.color = m_isCursorOnThisObject ? m_boxColour.onPointerEnter : m_boxColour.normal;
                m_text.color = m_isCursorOnThisObject ? m_textColour.onPointerEnter : m_textColour.normal;
            });
        }
    }
}


