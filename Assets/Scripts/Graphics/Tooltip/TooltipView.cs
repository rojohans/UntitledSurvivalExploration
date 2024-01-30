

using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace usea.graphics.view
{
    /// <summary>
    /// Handles the gui parts of a tooltip.
    /// </summary>
    public partial class TooltipView : MonoBehaviour
    {
        // ###### PUBLIC ######
        public partial void SetMessage(string message);
        public partial void UpdatePosition();

        // ###### PRIVATE ######
        private partial void UpdateDimensions(float width, float height);
        [SerializeField] private Image m_background;
        [SerializeField] private TMPro.TextMeshProUGUI m_text;
        [SerializeField] private float m_paddingInPixels;
    }

    public partial class TooltipView : MonoBehaviour
    {
        public partial void SetMessage(string message)
        {
            m_text.GetComponent<TMPro.TMP_Text>().text = message;
            UpdateDimensions(m_text.preferredWidth, m_text.preferredHeight);
            UpdateDimensions(m_text.preferredWidth, m_text.preferredHeight); // Needs to be done twice to set it correctly.
            UpdatePosition();
        }

        public partial void UpdatePosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            m_background.GetComponent<RectTransform>().position = new Vector3(mousePosition.x, mousePosition.y, 0);
            m_text.GetComponent<RectTransform>().position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }

        private partial void UpdateDimensions(float width, float height)
        {
            m_background.GetComponent<RectTransform>().sizeDelta = new Vector2(width + 2 * m_paddingInPixels, height + 2 * m_paddingInPixels);
            m_text.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        }
    }
}