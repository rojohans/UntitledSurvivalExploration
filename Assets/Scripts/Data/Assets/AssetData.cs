
using System.Collections.Generic;
using UnityEngine;

namespace usea.data.asset
{
    /// <summary>
    /// Data related to external resources. This can be sound files, sprites etc.
    /// </summary>
    public partial class AssetData
    {
        //###### PUBLIC ######
        public partial Sprite GetAssetSprite(string name);

        //###### PRIVATE ######
        private Dictionary<string, Sprite> m_assetSprites;
    }

    public partial class AssetData
    {
        /// <summary>
        /// If the given name does not match a stored sprite, a default placeholder sprite is returned.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public partial Sprite GetAssetSprite(string name)
        {
            if (!m_assetSprites.ContainsKey(name))
            {
                return m_assetSprites["placeholder"];
            }

            return m_assetSprites[name];
        }

        public AssetData()
        {
            m_assetSprites = new Dictionary<string, Sprite>();
            Sprite[] readObjects = Resources.LoadAll<Sprite>("Art/Event_Card_Images/");
            foreach (Sprite obj in readObjects)
            {
                m_assetSprites.Add(obj.name, obj);
                MonoBehaviour.print(obj.name + "::" + obj.ToString());
            }
        }
    }
}