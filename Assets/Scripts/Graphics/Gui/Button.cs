using UnityEngine;
using TMPro;
using UnityEngine.UI;
using usea.graphics.controller;

namespace usea.graphics.gui
{
    /// <summary>
    /// A custom implementation of a button. Has more flexible callbacks than Unity's default button implementation.
    /// 
    /// @TODO: SetSoundListener functionality
    /// @TODO: SetImage functionality
    /// </summary>
    public partial class Button : EventEnabled
    {
        // ###### PUBLIC ######
        public partial void Awake();
        public partial void SetTooltip(string message);

        // ###### PRIVATE ######
        private partial void SetColourListeners();
        [System.Serializable]
        private struct ColourSettings
        {
            public Color normal;
            public Color onPointerEnter;
            public Color onPointerClick;
        };

        [Header("Colour")]
        [SerializeField] private ColourSettings m_boxColour;
        [SerializeField] private ColourSettings m_textColour;

        [Header("Components")]
        [SerializeField] private Image m_image;
        [SerializeField] private TMP_Text m_text;
        private bool m_isCursorOnThisObject;
    }

    public partial class Button : EventEnabled
    {
        public partial void Awake()
        {
            m_isCursorOnThisObject = false;
            //SetSoundListeners();
            //SetTooltipListeners();
            SetColourListeners();
        }

        public partial void SetTooltip(string message)
        {
            AddOnPointerEnterCallback(() =>
            {
                TooltipController a = (TooltipController)GuiManager.Get().GetObject(GuiObjectTypeE.TOOLTIP);
                a.Activate(message);
            });

            AddOnPointerExitCallback(() =>
            {
                TooltipController a = (TooltipController)GuiManager.Get().GetObject(GuiObjectTypeE.TOOLTIP);
                a.Deactivate();
            });
        }

        private partial void SetColourListeners()
        {
            AddOnPointerEnterCallback(() =>
            {
                m_isCursorOnThisObject = true;
                m_image.color = m_boxColour.onPointerEnter;
                m_text.color = m_textColour.onPointerEnter;
            });
            AddOnPointerExitCallback(() =>
            {
                m_isCursorOnThisObject = false;
                m_image.color = m_boxColour.normal;
                m_text.color = m_textColour.normal;
            });
            AddOnPointerDownCallback(() =>
            {
                m_image.color = m_boxColour.onPointerClick;
                m_text.color = m_textColour.onPointerClick;
            });
            AddOnPointerUpCallback(() =>
            {
                m_image.color = m_isCursorOnThisObject ? m_boxColour.onPointerEnter : m_boxColour.normal;
                m_text.color = m_isCursorOnThisObject ? m_textColour.onPointerEnter : m_textColour.normal;
            });
        }
    }
}


