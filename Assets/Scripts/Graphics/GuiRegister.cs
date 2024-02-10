
using System.Collections.Generic;
using UnityEngine;

namespace usea.graphics
{
    /// <summary>
    /// Defines the names of gui objects that can be stored in the registry.
    /// </summary>
    public enum GuiObjectTypeE
    {
        NONE,
        TOOLTIP,
        FRAME_TICKER
    };

    /// <summary>
    /// Stores all registered gui objects.
    /// </summary>
    public partial class GuiRegistry
    {
        // ###### PUBLIC ######
        public partial void AddGuiObject(GuiObjectTypeE key, controller.Controller value);
        public partial controller.Controller GetGuiObject(GuiObjectTypeE key);

        // ###### PRIVATE ######
        private Dictionary<GuiObjectTypeE, controller.Controller> m_guiObjects;
    }

    public partial class GuiRegistry
    {
        public GuiRegistry()
        {
            m_guiObjects = new Dictionary<GuiObjectTypeE, controller.Controller>();
        }

        public partial void AddGuiObject(GuiObjectTypeE key, controller.Controller value)
        {
            if (m_guiObjects.ContainsKey(key))
            {
                MonoBehaviour.print("Entry already exist for key=" + key + ", will replace existing gui object.");
            }
            // MonoBehaviour.print("Adding gui object of type=" + key);
            m_guiObjects.Add(key, value);
        }

        public partial controller.Controller GetGuiObject(GuiObjectTypeE key)
        {
            if (!m_guiObjects.ContainsKey(key))
            {
                MonoBehaviour.print("No entry exist for key=" + key + ", will return null.");
                return null;
            }
            return m_guiObjects[key];
        }
    }
}