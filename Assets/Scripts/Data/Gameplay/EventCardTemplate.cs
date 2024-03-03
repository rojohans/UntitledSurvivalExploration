
using System.Collections.Generic;

namespace usea.data.gameplay
{
    /// <summary>
    /// Describes the properties of a card.
    /// </summary>
    public struct EventCardProperties
    {
        public EventCardProperties(string titleIn, uint priorityIn, UnityEngine.Sprite imageIn, string descriptionIn)
        {
            title = titleIn;
            priority = priorityIn;
            image = imageIn;
            description = descriptionIn;
        }

        public string title;
        public uint priority;
        public UnityEngine.Sprite image;
        public string description;
    }

    /// <summary>
    /// A container for a unique card. Each instance will have a unique ID.
    /// </summary>
    public partial class EventCardTemplate
    {
        // ###### PUBLIC ######
        public partial string GetName();
        public partial uint GetId();
        public partial EventCardProperties GetProperties();
        public static partial void ResetIdGenerator();
        public static partial void InsertInDictionary(ref Dictionary<uint, EventCardTemplate> dictionary, string title, uint priority, string imageName, string description);

        // ###### PRIVATE ######
        private static util.UniqueIdGenerator m_idGenerator = new util.UniqueIdGenerator();
        private uint m_id;
        private EventCardProperties m_properties;
    }

    public partial class EventCardTemplate
    {
        public EventCardTemplate(EventCardProperties properties)
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
        public static partial void InsertInDictionary(ref Dictionary<uint, EventCardTemplate> dictionary,
                                                      string title,
                                                      uint priority,
                                                      string imageName,
                                                      string description)
        {
            UnityEngine.Sprite testSprite = Database.Get().GetAssetData().GetAssetSprite(imageName);

            EventCardTemplate newCard = new EventCardTemplate(new EventCardProperties(title, priority, testSprite, description));
            dictionary.Add(newCard.GetId(), newCard);
        }
    }
}
