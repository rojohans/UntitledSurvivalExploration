
using UnityEngine;
using UnityEngine.EventSystems;

namespace usea.graphics.gui
{
    /// <summary>
    /// Base class for gui objects that should use Unity events.
    /// </summary>
    public abstract partial class EventEnabled : MonoBehaviour,
                                        IPointerEnterHandler,
                                        IPointerClickHandler,
                                        IPointerExitHandler,
                                        IPointerDownHandler,
                                        IPointerUpHandler,
                                        IPointerMoveHandler
    {
        // ###### TYPES ######
        public delegate void EventCallback(PointerEventData eventData);

        // ###### PUBLIC ######
        public partial void AddOnPointerClickCallback(EventCallback callback);
        public partial void AddOnPointerEnterCallback(EventCallback callback);
        public partial void AddOnPointerExitCallback(EventCallback callback);
        public partial void AddOnPointerDownCallback(EventCallback callback);
        public partial void AddOnPointerUpCallback(EventCallback callback);
        public partial void AddOnPointerMoveCallback(EventCallback callback);
        public partial void AddOnUpdateCallback(usea.util.types.Callback callback);
        public partial void OnPointerClick(PointerEventData eventData);
        public partial void OnPointerEnter(PointerEventData eventData);
        public partial void OnPointerExit(PointerEventData eventData);
        public partial void OnPointerDown(PointerEventData eventData);
        public partial void OnPointerUp(PointerEventData eventData);
        public partial void OnPointerMove(PointerEventData eventData);
        public partial void Update();
        public bool IsSelected() { return m_isSelected; }
        public bool IsCursorOnThisObject() { return m_isCursorOnThisObject; }

        // ###### PROTECTED ######
        protected bool m_isSelected;
        protected bool m_isCursorOnThisObject;

        // ###### PRIVATE ######
        private struct Callbacks
        {
            public event EventCallback onPointerClick;
            public event EventCallback onPointerEnter;
            public event EventCallback onPointerExit;
            public event EventCallback onPointerDown;
            public event EventCallback onPointerUp;
            public event EventCallback onPointerMove;
            public event usea.util.types.Callback onUpdate;
            public void OnPointerClick(PointerEventData eventData) { onPointerClick?.Invoke(eventData); }
            public void OnPointerEnter(PointerEventData eventData) { onPointerEnter?.Invoke(eventData); }
            public void OnPointerExit(PointerEventData eventData) { onPointerExit?.Invoke(eventData); }
            public void OnPointerDown(PointerEventData eventData) { onPointerDown?.Invoke(eventData); }
            public void OnPointerUp(PointerEventData eventData) { onPointerUp?.Invoke(eventData); }
            public void OnPointerMove(PointerEventData eventData) { onPointerMove?.Invoke(eventData); }
            public void OnUpdate() { onUpdate?.Invoke(); }
        }
        private Callbacks m_callbacks = new Callbacks();
    }

    public abstract partial class EventEnabled : MonoBehaviour,
                                        IPointerEnterHandler,
                                        IPointerClickHandler,
                                        IPointerExitHandler,
                                        IPointerDownHandler,
                                        IPointerUpHandler,
                                        IPointerMoveHandler
    {
        public partial void AddOnPointerClickCallback(EventCallback callback)
        {
            m_callbacks.onPointerClick += callback;
        }

        public partial void AddOnPointerEnterCallback(EventCallback callback)
        {
            m_callbacks.onPointerEnter += callback;
        }

        public partial void AddOnPointerExitCallback(EventCallback callback)
        {
            m_callbacks.onPointerExit += callback;
        }

        public partial void AddOnPointerDownCallback(EventCallback callback)
        {
            m_callbacks.onPointerDown += callback;
        }

        public partial void AddOnPointerUpCallback(EventCallback callback)
        {
            m_callbacks.onPointerUp += callback;
        }

        public partial void AddOnPointerMoveCallback(EventCallback callback)
        {
            m_callbacks.onPointerMove += callback;
        }

        public partial void AddOnUpdateCallback(usea.util.types.Callback callback)
        {
            m_callbacks.onUpdate += callback;
        }

        public partial void OnPointerClick(PointerEventData eventData)
        {
            m_callbacks.OnPointerClick(eventData);
        }

        public partial void OnPointerEnter(PointerEventData eventData)
        {
            m_isCursorOnThisObject = true;
            m_callbacks.OnPointerEnter(eventData);
        }

        public partial void OnPointerExit(PointerEventData eventData)
        {
            m_isCursorOnThisObject = false;
            m_callbacks.OnPointerExit(eventData);
        }

        public partial void OnPointerDown(PointerEventData eventData)
        {
            m_isSelected = true;
            m_callbacks.OnPointerDown(eventData);
        }

        public partial void OnPointerUp(PointerEventData eventData)
        {
            m_isSelected = false;
            m_callbacks.OnPointerUp(eventData);
        }

        public partial void OnPointerMove(PointerEventData eventData)
        {
            m_callbacks.OnPointerMove(eventData);
        }

        public partial void Update()
        {
            m_callbacks.OnUpdate();
        }
    }
}
