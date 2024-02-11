
using System.Collections.Generic;
using UnityEngine;

namespace usea.data.gameplay
{
    /// <summary>
    /// Describes the properties of a card.
    /// </summary>
    public struct EventCardProperties
    {
        public EventCardProperties(string titleIn, uint priorityIn, string imageNameIn, string descriptionIn)
        {
            title = titleIn;
            priority = priorityIn;
            imageName = imageNameIn;
            description = descriptionIn;
        }

        public string title;
        public uint priority;
        public string imageName;
        public string description;
    }

    /// <summary>
    /// A container for a unique card. Each instance will have a unique ID.
    /// </summary>
    public partial class EventCard
    {
        // ###### PUBLIC ######
        public partial string GetName();
        public partial uint GetId();
        public partial EventCardProperties GetProperties();
        public static partial void ResetIdGenerator();
        public static partial void InsertInDictionary(ref Dictionary<uint, EventCard> dictionary, string title, uint priority, string imageName, string description);

        // ###### PRIVATE ######
        private static util.UniqueIdGenerator m_idGenerator = new util.UniqueIdGenerator();
        private uint m_id;
        private EventCardProperties m_properties;
    }

    public partial class EventCard
    {
        public EventCard(EventCardProperties properties)
        {
            m_id = m_idGenerator.GenerateId();
            m_properties = properties;
        }

        public partial string GetName()
        {
            return m_properties.title;
        }

        public partial uint GetId()
        {
            return m_id;
        }

        public partial EventCardProperties GetProperties()
        {
            return m_properties;
        }

        public static partial void ResetIdGenerator()
        {
            m_idGenerator.Reset();
        }

        /// <summary>
        /// Creates a new EventCard and inserts it into the provided dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="title"></param>
        /// <param name="priority"></param>
        /// <param name="imageName"></param>
        /// <param name="description"></param>
        public static partial void InsertInDictionary(ref Dictionary<uint, EventCard> dictionary,
                                                      string title,
                                                      uint priority,
                                                      string imageName,
                                                      string description)
        {
            EventCard newCard = new EventCard(new EventCardProperties(title, priority, imageName, description));
            dictionary.Add(newCard.GetId(), newCard);
        }
    }
}
