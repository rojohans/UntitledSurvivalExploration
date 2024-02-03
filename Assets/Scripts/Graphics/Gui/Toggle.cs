

using System.Collections.Generic;
using UnityEngine;
using usea.graphics.controller;

namespace usea.graphics.gui
{
    /// <summary>
    /// A custom implementation of a toggle button. Can be either on or off.
    /// </summary>
    public partial class Toggle : EventEnabled
    {
        // ###### PUBLIC ######
        public partial void Awake();
        public partial void SetOnCallback(Callback callback);
        public partial void SetOffCallback(Callback callback);
        public partial void SetTooltip(string message);

        // ###### PRIVATE ######
        [System.Serializable]
        private struct ColourSettings
        {
            public Color off;
            public Color on;
            public Color highlightOff;
            public Color highlightOn;
        };

        private enum ToggleState
        {
            ON,
            OFF,
            ON_HIGHLIGHT,
            OFF_HIGHLIGHT
        };

        private partial void SetInitialCallbacks();
        private partial void UpdateImageColours();

        [Header("Colour")]
        [SerializeField] private ColourSettings m_backgroundColour;
        [SerializeField] private ColourSettings m_centerColour;

        [Header("Components")]
        [SerializeField] private UnityEngine.UI.Image m_backgroundImage;
        [SerializeField] private UnityEngine.UI.Image m_centerImage;
        private event Callback m_onCallback;
        private event Callback m_offCallback;
        private ToggleState m_state;
    }

    public partial class Toggle : EventEnabled
    {
        public partial void Awake()
        {
            m_state = ToggleState.OFF;
            SetInitialCallbacks();
            UpdateImageColours();
        }

        public partial void SetOnCallback(Callback callback)
        {
            m_onCallback += callback;
        }

        public partial void SetOffCallback(Callback callback)
        {
            m_offCallback += callback;
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

        private partial void SetInitialCallbacks()
        {
            Dictionary<ToggleState, Callback> callbacks = new()
            {
                {ToggleState.ON_HIGHLIGHT, m_onCallback},
                {ToggleState.OFF_HIGHLIGHT, m_offCallback}
            };
            AddOnPointerDownCallback(() =>
                {
                    m_state = m_state == ToggleState.ON_HIGHLIGHT
                                ? ToggleState.OFF_HIGHLIGHT
                                : ToggleState.ON_HIGHLIGHT;
                    callbacks[m_state]?.Invoke();
                    UpdateImageColours();
                });
            AddOnPointerEnterCallback(() =>
                {
                    m_state = m_state == ToggleState.ON
                        ? ToggleState.ON_HIGHLIGHT
                        : ToggleState.OFF_HIGHLIGHT;
                    UpdateImageColours();
                });
            AddOnPointerExitCallback(() =>
                {
                    m_state = m_state == ToggleState.ON_HIGHLIGHT
                        ? ToggleState.ON
                        : ToggleState.OFF;
                    UpdateImageColours();
                });
        }

        private partial void UpdateImageColours()
        {
            switch (m_state)
            {
                case ToggleState.ON:
                    {
                        m_backgroundImage.color = m_backgroundColour.on;
                        m_centerImage.color = m_centerColour.on;
                        break;
                    }
                case ToggleState.OFF:
                    {
                        m_backgroundImage.color = m_backgroundColour.off;
                        m_centerImage.color = m_centerColour.off;
                        break;
                    }
                case ToggleState.ON_HIGHLIGHT:
                    {
                        m_backgroundImage.color = m_backgroundColour.highlightOn;
                        m_centerImage.color = m_centerColour.highlightOn;
                        break;
                    }
                case ToggleState.OFF_HIGHLIGHT:
                    {
                        m_backgroundImage.color = m_backgroundColour.highlightOff;
                        m_centerImage.color = m_centerColour.highlightOff;
                        break;
                    }
            }
        }
    }
}