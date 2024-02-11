
using UnityEngine;

using usea.data.asset;
using usea.data.gameplay;
using usea.data.settings;

namespace usea.data
{
    /// <summary>
    /// A container for various data categories. This is a singleton.
    /// </summary>
    public partial class Database
    {
        // ###### PUBLIC ######
        public static partial Database Get();
        public partial AssetData GetAssetData();
        public partial SettingsData GetSettingsData();
        public partial GameplayData GetGameplayData();
        public partial void ResetGameplayData();
        public partial void ClearGameplayData();

        // ###### PRIVATE ######
        private static Database m_instance;
        private AssetData m_assetData;
        private SettingsData m_settingsData;
        private GameplayData m_gameplayData;
    }

    public partial class Database
    {
        public Database()
        {
            m_assetData = new AssetData();
            m_settingsData = new SettingsData();
            m_gameplayData = null;
        }

        /// <summary>
        /// Get singleton instance.
        /// </summary>
        /// <returns></returns>
        public static partial Database Get()
        {
            if (m_instance == null)
            {
                m_instance = new Database();
            }
            return m_instance;
        }

        public partial AssetData GetAssetData()
        {
            return m_assetData;
        }

        public partial SettingsData GetSettingsData()
        {
            return m_settingsData;
        }

        public partial GameplayData GetGameplayData()
        {
            if (m_gameplayData == null)
            {
                MonoBehaviour.print("[ERROR]: Gameplay data has not been initialized. Returning null.");
                return null;
            }
            return m_gameplayData;
        }

        /// <summary>
        /// Will initialize gameplay data.
        /// </summary>
        public partial void ResetGameplayData()
        {
            m_gameplayData = new GameplayData();
        }

        /// <summary>
        /// Will clear all gameplay data.
        /// </summary>
        public partial void ClearGameplayData()
        {
            m_gameplayData = null;
        }
    }
}