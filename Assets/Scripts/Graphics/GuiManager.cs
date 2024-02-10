

using UnityEngine;

namespace usea.graphics
{
    /// <summary>
    /// A facade that provides access to common gui functionality. It also provides access to all stored gui objects.
    /// </summary>
    public partial class GuiManager
    {
        // ###### PUBLIC ######
        public static partial GuiManager Get();
        public partial void RegisterObject(GuiObjectTypeE key, controller.Controller value);
        public partial controller.Controller GetObject(GuiObjectTypeE key);
        public partial void ShowTooltipOnObject(MonoBehaviour guiObject, string message);

        // ###### PRIVATE ######
        private static GuiManager m_instance;
        private GuiRegistry m_guiRegistry;
    }

    public partial class GuiManager
    {
        public static partial GuiManager Get()
        {
            if (m_instance == null)
            {
                m_instance = new GuiManager
                {
                    m_guiRegistry = new GuiRegistry()
                };
            }
            return m_instance;
        }

        public partial void RegisterObject(GuiObjectTypeE key, controller.Controller value)
        {
            if (key != GuiObjectTypeE.NONE)
            {
                m_guiRegistry.AddGuiObject(key, value);
            }
        }

        public partial controller.Controller GetObject(GuiObjectTypeE key)
        {
            return m_guiRegistry.GetGuiObject(key);
        }

        public partial void ShowTooltipOnObject(MonoBehaviour guiObject, string message)
        {
            // QUESTION: Should this be implemented?
        }
    }

}

