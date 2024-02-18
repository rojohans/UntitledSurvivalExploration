
using UnityEngine;

namespace usea.graphics.util
{
    /// <summary>
    /// Mouse dragging of an object with a RectTransform. The owner of this object needs to activate/deactivate this to start/stop dragging.
    /// </summary>
    public partial class ObjectDragger : MonoBehaviour
    {
        // ###### PUBLIC ######
        public partial void Update();
        public partial void SetCurrentMousePosition(Vector3 currentMousePosition);
        public partial void SetTranformToActOn(Transform transform);
        public partial void Activate();
        public partial void Deactivate();


        // ###### PRIVATE ######
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

        public partial void SetTranformToActOn(Transform transform)
        {
            m_tranformToActOn = transform;
        }

        public partial void SetCurrentMousePosition(Vector3 currentMousePosition)
        {
            m_previousFrameMousePosition = currentMousePosition;
        }

        /// <summary>
        /// Will start to move the attached object along with the mouse.
        /// </summary>
        public partial void Activate()
        {
            m_isActive = true;
        }

        /// <summary>
        /// Will stop moving the attached object.
        /// </summary>
        public partial void Deactivate()
        {
            m_isActive = false;
        }
    }
}