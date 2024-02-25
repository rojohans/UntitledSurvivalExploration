
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace usea.graphics.view
{
    public partial class EventCardView : MonoBehaviour
    {
        // ###### PUBLIC ######
        public partial void ResetAppearance(string title, string description, uint priority, Sprite image);
        public partial gui.Image GetArt();
        public partial gui.GuiBase GetMouseEventCatcher();

        // ###### PRIVATE ######
        [Header("Components")]
        [SerializeField] private TMP_Text m_title;
        [SerializeField] private TMP_Text m_description;
        [SerializeField] private TMP_Text m_priority;
        [SerializeField] private gui.Image m_frame;
        [SerializeField] private gui.Image m_art;
        [SerializeField] private gui.Dragger m_dragger;
    }

    public partial class EventCardView : MonoBehaviour
    {
        public partial void ResetAppearance(string title, string description, uint priority, Sprite image)
        {
            m_title.SetText(title);
            m_description.SetText(description);
            m_priority.SetText(priority.ToString());
            m_art.ChangeSprite(image);
        }

        public partial gui.Image GetArt()
        {
            return m_art;
        }

        public partial gui.GuiBase GetMouseEventCatcher()
        {
            return m_dragger;
        }
    }
}