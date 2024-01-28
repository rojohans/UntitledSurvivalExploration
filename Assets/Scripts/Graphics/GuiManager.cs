

namespace usea.graphics
{
    /// <summary>
    /// A facade that provides access to the registered gui objects.
    /// </summary>
    public static class GuiManager
    {
        // ###### PUBLIC ######
        public static void RegisterObject(GuiObjectTypeE key, controller.Controller value)
        {
            if (m_guiRegistry == null)
            {
                m_guiRegistry = new GuiRegistry();
            }

            m_guiRegistry.AddGuiObject(key, value);
        }

        public static controller.Controller GetObject(GuiObjectTypeE key)
        {
            if (m_guiRegistry == null)
            {
                m_guiRegistry = new GuiRegistry();
            }

            return m_guiRegistry.GetGuiObject(key);
        }

        // ###### PRIVATE ######
        private static GuiRegistry m_guiRegistry;
    }
}

