
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

namespace usea.data.gameplay
{
    /// <summary>
    /// Data related to a specific gameplay session. This includes player resources, scores and map states.
    /// </summary>
    public partial class GameplayData
    {
        // ###### PUBLIC ######
        public partial Dictionary<uint, EventCardTemplate> getEventCardtemplates();
        public uint GetNumberOfSettingsViews() { return m_numberOfSettingsViews; } // TEMPORARY:
        public void SetNumberOfSettingsViews(uint value) { m_numberOfSettingsViews = value; } // TEMPORARY:

        // ###### PRIVATE ######
        private partial void InitializeEventCards();
        private uint m_numberOfSettingsViews; // TEMPORARY:
        private Dictionary<uint, EventCardTemplate> m_eventCardTemplates;
    }

    public partial class GameplayData
    {
        public GameplayData()
        {
            m_numberOfSettingsViews = 0;

            InitializeEventCards();
        }

        public partial Dictionary<uint, EventCardTemplate> getEventCardtemplates()
        {
            return m_eventCardTemplates;
        }

        private partial void InitializeEventCards()
        {
            m_eventCardTemplates = new Dictionary<uint, EventCardTemplate>();

            EventCardTemplate.InsertInDictionary(ref m_eventCardTemplates,
                                         "Ocelot encounter!",
                                         15,
                                         "ocelot_encounter",
                                         "Beware the ocelot!!!");

            EventCardTemplate.InsertInDictionary(ref m_eventCardTemplates,
                                         "Abandoned camp",
                                         5,
                                         "abandoned_camp",
                                         "This will surely prove useful.\nBut why were it abandoned?");

            EventCardTemplate.InsertInDictionary(ref m_eventCardTemplates,
                                         "Poachers",
                                         20,
                                         "poachers",
                                         "What does your moral compass say?\nFun, or crime?");

            EventCardTemplate.InsertInDictionary(ref m_eventCardTemplates,
                                         "Unstable bridge",
                                         25,
                                         "unstable_bridge",
                                         "Do you dare to pass?");

            EventCardTemplate.InsertInDictionary(ref m_eventCardTemplates,
                                         "Wise fox",
                                         10,
                                         "wise_fox",
                                         "If sage be de, follow me.");
            // Follow the path, or face my wrath.

            MonoBehaviour.print("InitializeEventCards, #cards=" + m_eventCardTemplates.Count);
            foreach (KeyValuePair<uint, EventCardTemplate> pair in m_eventCardTemplates)
            {
                MonoBehaviour.print(pair.Key + " || " + pair.Value.GetName());
            }
        }
    }
}