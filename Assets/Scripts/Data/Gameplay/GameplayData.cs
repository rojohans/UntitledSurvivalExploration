
using System.Collections.Generic;
using UnityEngine;

namespace usea.data.gameplay
{
    /// <summary>
    /// Data related to a specific gameplay session. This includes player resources, scores and map states.
    /// </summary>
    public partial class GameplayData
    {
        // ###### PUBLIC ######
        public uint GetNumberOfSettingsViews() { return m_numberOfSettingsViews; } // TEMPORARY:
        public void SetNumberOfSettingsViews(uint value) { m_numberOfSettingsViews = value; } // TEMPORARY:

        // ###### PRIVATE ######
        private partial void InitializeEventCards();
        private uint m_numberOfSettingsViews; // TEMPORARY:
        private Dictionary<uint, EventCard> m_eventCards;
    }

    public partial class GameplayData
    {
        public GameplayData()
        {
            m_numberOfSettingsViews = 0;

            InitializeEventCards();
        }

        private partial void InitializeEventCards()
        {
            m_eventCards = new Dictionary<uint, EventCard>();

            EventCard.InsertInDictionary(ref m_eventCards,
                                         "Ocelot encounter!",
                                         20,
                                         "ocelotEncounter.png",
                                         "Beware the ocelot!!!");

            EventCard.InsertInDictionary(ref m_eventCards,
                                         "Abandoned tools",
                                         2,
                                         "abandonedTools.png",
                                         "This will surely prove useful.\nBut why were the abandoned?");

            EventCard.InsertInDictionary(ref m_eventCards,
                                         "Poachers",
                                         10,
                                         "poachers.png",
                                         "Join them in the hunt?\nOr stop their crimes?");

            EventCard.InsertInDictionary(ref m_eventCards,
                                         "Unstable bridge",
                                         15,
                                         "unstableBridge.png",
                                         "Do you dare to pass?");

            MonoBehaviour.print("InitializeEventCards, #cards=" + m_eventCards.Count);
            foreach (KeyValuePair<uint, EventCard> pair in m_eventCards)
            {
                MonoBehaviour.print(pair.Key + " || " + pair.Value.GetName());
            }
        }
    }
}