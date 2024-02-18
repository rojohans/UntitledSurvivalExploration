using UnityEngine;
using UnityEngine.EventSystems;

namespace usea.graphics.gui
{
    /// <summary>
    /// Base class for gui objects that should use Unity events.
    /// </summary>
    public abstract class EventEnabled : MonoBehaviour,
                                        IPointerEnterHandler,
                                        IPointerClickHandler,
                                        IPointerExitHandler,
                                        IPointerDownHandler,
                                        IPointerUpHandler,
                                        IPointerMoveHandler
    {
        // ###### PUBLIC ######

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


        public void AddOnPointerClickCallback(util.types.Callback callback)
        {
            m_callbacks.onPointerClick += callback;
        }

        public void AddOnPointerEnterCallback(util.types.Callback callback)
        {
            m_callbacks.onPointerEnter += callback;
        }

        public void AddOnPointerExitCallback(util.types.Callback callback)
        {
            m_callbacks.onPointerExit += callback;
        }

        public void AddOnPointerDownCallback(util.types.Callback callback)
        {
            m_callbacks.onPointerDown += callback;
        }

        public void AddOnPointerUpCallback(util.types.Callback callback)
        {
            m_callbacks.onPointerUp += callback;
        }

        public void AddOnPointerMoveCallback(util.types.Callback callback)
        {
            m_callbacks.onPointerMove += callback;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_callbacks.OnPointerClick();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_callbacks.OnPointerEnter();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_callbacks.OnPointerExit();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            m_callbacks.OnPointerDown();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_callbacks.OnPointerUp();
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            m_callbacks.OnPointerMove();
        }

        // ###### PRIVATE ######
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
            public event util.types.Callback onPointerClick;
            public event util.types.Callback onPointerEnter;
            public event util.types.Callback onPointerExit;
            public event util.types.Callback onPointerDown;
            public event util.types.Callback onPointerUp;
            public event util.types.Callback onPointerMove;
            public void OnPointerClick() { onPointerClick?.Invoke(); }
            public void OnPointerEnter() { onPointerEnter?.Invoke(); }
            public void OnPointerExit() { onPointerExit?.Invoke(); }
            public void OnPointerDown() { onPointerDown?.Invoke(); }
            public void OnPointerUp() { onPointerUp?.Invoke(); }
            public void OnPointerMove() { onPointerMove?.Invoke(); }
        }
        private Callbacks m_callbacks = new Callbacks();
    }
}
