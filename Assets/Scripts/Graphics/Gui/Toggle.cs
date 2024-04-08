
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace usea.graphics.gui
{
    /// <summary>
    /// A custom implementation of a toggle button. Can be either on or off.
    /// </summary>
    public partial class Toggle : GuiBase
    {
        // ###### TYPES ######
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

        // ###### PUBLIC ######
        public partial void SetOnCallback(usea.util.types.Callback callback);
        public partial void SetOffCallback(usea.util.types.Callback callback);
        public partial void ToggleOff();
        public partial bool IsActive();

        // ###### PROTECTED ######
        protected override partial void Constructor();
        protected override void InitializeDependencies() { }

        // ###### PRIVATE ######
        private partial void SetInitialCallbacks();
        private partial void UpdateImageColours();

        internal void AddOnPointerDownCallback()
        {
            throw new NotImplementedException();
        }

        [Header("Colour")]
        [SerializeField] private ColourSettings m_backgroundColour;
        [SerializeField] private ColourSettings m_centerColour;

        [Header("Components")]
        [SerializeField] private UnityEngine.UI.Image m_backgroundImage;
        [SerializeField] private UnityEngine.UI.Image m_centerImage;
        private event usea.util.types.Callback m_onCallback;
        private event usea.util.types.Callback m_offCallback;
        private ToggleState m_state;
    }

    public partial class Toggle : GuiBase
    {
        /// <summary>
        /// Set callback used when toggle activates.
        /// </summary>
        /// <param name="callback"></param>
        public partial void SetOnCallback(usea.util.types.Callback callback)
        {
            m_onCallback += callback;
        }

        /// <summary>
        /// Set callback used when toggle deactivates.
        /// </summary>
        /// <param name="callback"></param>
        public partial void SetOffCallback(usea.util.types.Callback callback)
        {
            m_offCallback += callback;
        }

        /// <summary>
        /// Forcibly deactivates toggle state.
        /// </summary>
        public partial void ToggleOff()
        {
            if (m_state == ToggleState.ON)
            {
                m_state = ToggleState.OFF;
            }

            if (m_state == ToggleState.ON_HIGHLIGHT)
            {
                m_state = ToggleState.OFF_HIGHLIGHT;
            }
            UpdateImageColours();
        }

        public partial bool IsActive()
        {
            print(m_state);
            return m_state == ToggleState.ON || m_state == ToggleState.ON_HIGHLIGHT;
        }

        protected override partial void Constructor()
        {
            m_state = ToggleState.OFF;
            SetInitialCallbacks();
            UpdateImageColours();
        }

        private partial void SetInitialCallbacks()
        {
            Dictionary<ToggleState, usea.util.types.Callback> callbacks = new()
            {
                {ToggleState.ON_HIGHLIGHT, m_onCallback},
                {ToggleState.OFF_HIGHLIGHT, m_offCallback}
            };
            AddOnPointerDownCallback((PointerEventData eventData) =>
                {
                    if (ToggleState.ON_HIGHLIGHT == m_state)
                    {
                        m_offCallback?.Invoke();
                        m_state = ToggleState.OFF_HIGHLIGHT;
                    }
                    else if (ToggleState.OFF_HIGHLIGHT == m_state)
                    {
                        m_onCallback?.Invoke();
                        m_state = ToggleState.ON_HIGHLIGHT;
                    }

                    UpdateImageColours();
                });
            AddOnPointerEnterCallback((PointerEventData eventData) =>
                {
                    m_state = m_state == ToggleState.ON
                        ? ToggleState.ON_HIGHLIGHT
                        : ToggleState.OFF_HIGHLIGHT;
                    UpdateImageColours();
                });
            AddOnPointerExitCallback((PointerEventData eventData) =>
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