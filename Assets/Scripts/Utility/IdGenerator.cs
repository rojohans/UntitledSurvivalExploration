
namespace usea.util
{
    /// <summary>
    /// A helper class that can be used to generate unique IDs.
    /// </summary>
    public partial class UniqueIdGenerator
    {
        // ###### PUBLIC ######
        public partial uint GenerateId();
        public partial uint GetNumberOfGeneratedIds();
        public partial void Reset();

        // ###### PRIVATE ######
        private uint m_idCounter;
    }

    public partial class UniqueIdGenerator
    {
        public UniqueIdGenerator()
        {
            Reset();
        }

        /// <summary>
        /// Returns unique ID.
        /// </summary>
        /// <returns></returns>
        public partial uint GenerateId()
        {
            uint idToReturn = m_idCounter;
            m_idCounter += 1;
            return idToReturn;
        }

        /// <summary>
        /// Returns the number of previously generated IDs.
        /// </summary>
        /// <returns></returns>
        public partial uint GetNumberOfGeneratedIds()
        {
            return m_idCounter;
        }

        /// <summary>
        /// Reset the counter, use with care!
        /// </summary>
        public partial void Reset()
        {
            m_idCounter = 0;
        }
    }
}