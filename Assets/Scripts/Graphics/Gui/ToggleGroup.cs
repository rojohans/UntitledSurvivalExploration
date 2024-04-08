

using System.Collections.Generic;
using UnityEngine;

namespace usea.graphics.gui
{
    public partial class ToggleGroup
    {
        //###### PUBLIC ######
        public partial uint AddToggle(graphics.gui.Toggle newToggle);
        public partial usea.util.Optional<uint> GetActiveToggle();

        //###### PRIVATE ######
        private Dictionary<uint, graphics.gui.Toggle> m_toggleButtons;
        private usea.util.UniqueIdGenerator m_idGenerator;
    }

    public partial class ToggleGroup
    {
        public ToggleGroup()
        {
            m_toggleButtons = new Dictionary<uint, Toggle>();
            m_idGenerator = new usea.util.UniqueIdGenerator();
            MonoBehaviour.print("ToggleGroup::Constructor: #toggles=" + m_toggleButtons.Count);
        }

        /// <summary>
        /// Adds a Toggle object that the group should own.
        /// </summary>
        /// <param name="newToggle"></param>
        /// <returns>Id of toggle button</returns>
        public partial uint AddToggle(graphics.gui.Toggle newToggle)
        {
            uint newId = m_idGenerator.GenerateId();
            m_toggleButtons.Add(newId, newToggle);

            newToggle.SetOnCallback(() =>
            {
                foreach (KeyValuePair<uint, graphics.gui.Toggle> toggleEntry in m_toggleButtons)
                {
                    if (toggleEntry.Key != newId)
                    {
                        toggleEntry.Value.ToggleOff();
                    }
                }
            });

            return newId;
        }

        /// <summary>
        /// Returns the ID of any active toggle. Will return empty optional in case of no active item.
        /// </summary>
        /// <returns></returns>
        public partial usea.util.Optional<uint> GetActiveToggle()
        {
            usea.util.Optional<uint> result = new usea.util.Optional<uint>();

            foreach (KeyValuePair<uint, graphics.gui.Toggle> entry in m_toggleButtons)
            {
                if (entry.Value.IsActive())
                {
                    result.SetValue(entry.Key);
                    break;
                }
            }
            return result;
        }
    }
}