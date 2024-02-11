
namespace usea.data
{
    /// <summary>
    /// Data related to a specific gameplay session. This includes player resources, scores and map states.
    /// </summary>
    public class GameplayData
    {
        // ###### PUBLIC ######
        public GameplayData()
        {
            m_numberOfSettingsViews = 0;
        }

        public uint GetNumberOfSettingsViews() { return m_numberOfSettingsViews; } // TEMPORARY:
        public void SetNumberOfSettingsViews(uint value) { m_numberOfSettingsViews = value; } // TEMPORARY:

        // ###### PRIVATE ######
        private uint m_numberOfSettingsViews; // TEMPORARY:
    }
}