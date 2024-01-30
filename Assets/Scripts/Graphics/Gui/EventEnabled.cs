using UnityEngine;

namespace usea.graphics.gui
{
    /// <summary>
    /// Base class for gui objects that should use Unity events.
    /// </summary>
    public abstract class EventEnabled : MonoBehaviour,
                                UnityEngine.EventSystems.IPointerEnterHandler,
                                UnityEngine.EventSystems.IPointerClickHandler,
                                UnityEngine.EventSystems.IPointerExitHandler,
                                UnityEngine.EventSystems.IPointerDownHandler,
                                UnityEngine.EventSystems.IPointerUpHandler
    {
        // PUBLIC
        // TODO: Should this be defined in some utility place? There will be many classes which use "empty" callbacks.
        public delegate void Callback(); // Da fuc isa dis?

        /*
        public EventEnabled()
        {
            
            m_callbacks = new Dictionary<EventTypeE, Callback>() {{EventTypeE.ON_POINTER_CLICK, null},
                                                                  {EventTypeE.ON_POINTER_ENTER, null},
                                                                  {EventTypeE.ON_POINTER_EXIT, null},
                                                                  {EventTypeE.ON_POINTER_DOWN, null},
                                                                  {EventTypeE.ON_POINTER_UP, null}};
            
        }
        */

        public void AddOnPointerClickCallback(Callback callback)
        {
            m_callbacks.onPointerClick += callback;
        }

        public void AddOnPointerEnterCallback(Callback callback)
        {
            m_callbacks.onPointerEnter += callback;
        }

        public void AddOnPointerExitCallback(Callback callback)
        {
            m_callbacks.onPointerExit += callback;
        }

        public void AddOnPointerDownCallback(Callback callback)
        {
            m_callbacks.onPointerDown += callback;
        }

        public void AddOnPointerUpCallback(Callback callback)
        {
            m_callbacks.onPointerUp += callback;
        }

        public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            m_callbacks.OnPointerClick();
        }

        public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
        {
            m_callbacks.OnPointerEnter();
        }

        public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
        {
            m_callbacks.OnPointerExit();
        }

        public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            m_callbacks.OnPointerDown();
        }

        public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            m_callbacks.OnPointerUp();
        }

        // PRIVATE
        /*
        private enum EventTypeE
        {
            ON_POINTER_CLICK,
            ON_POINTER_ENTER,
            ON_POINTER_EXIT,
            ON_POINTER_DOWN,
            ON_POINTER_UP
        }
        private Dictionary<EventTypeE, Callback> m_callbacks;
        */

        private struct Callbacks
        {
            public event Callback onPointerClick;
            public event Callback onPointerEnter;
            public event Callback onPointerExit;
            public event Callback onPointerDown;
            public event Callback onPointerUp;
            public void OnPointerClick() { onPointerClick?.Invoke(); }
            public void OnPointerEnter() { onPointerEnter?.Invoke(); }
            public void OnPointerExit() { onPointerExit?.Invoke(); }
            public void OnPointerDown() { onPointerDown?.Invoke(); }
            public void OnPointerUp() { onPointerUp?.Invoke(); }
        }
        private Callbacks m_callbacks = new Callbacks();
    }
}
