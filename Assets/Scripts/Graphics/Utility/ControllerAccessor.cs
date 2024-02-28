
using UnityEngine;

namespace usea.graphics.util
{
    /// <summary>
    /// Responsible for accessing and storing controllers. This class can be used to access controllers in a clean and safe way.
    /// </summary>
    public partial class ControllerAccessor<ControllerType> where ControllerType : controller.Controller
    {
        // ###### PUBLIC ######
        public partial controller.Controller Get();

        // ###### PRIVATE ######
        private GuiObjectTypeE m_type;
        private ControllerType m_fetchedController;
    }

    public partial class ControllerAccessor<ControllerType>
    {
        public ControllerAccessor(GuiObjectTypeE type)
        {
            m_type = type;
            m_fetchedController = null;
        }

        public partial controller.Controller Get()
        {
            if (!m_fetchedController)
            {
                m_fetchedController = (ControllerType)GuiManager.Get().GetObject(m_type);
                if (!m_fetchedController)
                {
                    // TODO: Add ERROR trace.
                    return null;
                }
            }

            return m_fetchedController;
        }
    }
}