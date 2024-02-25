
using UnityEngine;
using UnityEngine.EventSystems;
using usea.graphics.gui;

namespace usea.graphics.util
{
    /// <summary>
    /// Mouse dragging of an object with a RectTransform. The owner of this object needs to activate/deactivate this to start/stop dragging.
    /// </summary>
    public partial class ObjectDragger : MonoBehaviour
    {
        // ###### PUBLIC ######
        public partial void Update();
        public partial void Initialize(GuiBase user, Transform transform);

        // ###### PRIVATE ######
        private partial void SetCurrentMousePosition(Vector3 currentMousePosition);
        private partial void Activate();
        private partial void Deactivate();
        private Transform m_tranformToActOn;
        private Vector3 m_previousFrameMousePosition;
        private bool m_isActive;
    }

    public partial class ObjectDragger
    {
        public ObjectDragger()
        {
            m_isActive = false;
            m_previousFrameMousePosition = new Vector3(0, 0, 0);
        }

        /// <summary>
        /// Moves the attached object along with the mouse.
        /// </summary>
        public partial void Update()
        {
            if (!m_isActive) { return; }

            Vector3 currentMousePosition = Input.mousePosition;
            m_tranformToActOn.position += new Vector3(currentMousePosition.x - m_previousFrameMousePosition.x,
                                                      currentMousePosition.y - m_previousFrameMousePosition.y,
                                                      0);
            m_previousFrameMousePosition = currentMousePosition;
        }

        /// <summary>
        /// Sets the transform to update, and adds mouse event callbacks for the user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="transform"></param>
        public partial void Initialize(GuiBase user, Transform transform)
        {
            m_tranformToActOn = transform;

            user.AddOnPointerDownCallback((PointerEventData eventData) =>
            {
                SetCurrentMousePosition(Input.mousePosition);
                Activate();
            });

            user.AddOnPointerUpCallback((PointerEventData eventData) =>
            {
                Deactivate();
            });
        }

        private partial void SetCurrentMousePosition(Vector3 currentMousePosition)
        {
            m_previousFrameMousePosition = currentMousePosition;
        }

        private partial void Activate()
        {
            m_isActive = true;
        }

        private partial void Deactivate()
        {
            m_isActive = false;
        }
    }
}