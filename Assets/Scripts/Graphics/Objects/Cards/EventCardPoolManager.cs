
using System.Collections.Generic;
using UnityEngine;
using usea.data.gameplay;

namespace usea.graphics.controller
{
    /// <summary>
    /// Owns a collection of event card gameobjects. Manages their lifespan, and lets users access them. 
    /// </summary>
    public partial class EventCardPoolManager : Controller
    {
        // ###### TYPES ######
        private struct ObjectPoolItem
        {
            public EventCardController controller;
            public bool isTemporary;

            public ObjectPoolItem(EventCardController controller, bool isTemporary) : this()
            {
                this.controller = controller;
                this.isTemporary = isTemporary;
            }
        }

        // ###### PUBLIC ######
        public partial uint VisualizeCard(EventCardProperties template);
        public partial void DevisualizeCard(uint id);
        public partial EventCardController GetCardById(uint id);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        private partial void InstantiateObject(bool isTemporary = false);
        [SerializeField] private GameObject m_prefab;
        [SerializeField] private uint m_minimumPoolSize = 20;

        private Dictionary<uint, ObjectPoolItem> m_objectPool;
        private List<uint> m_activeObjectIds;
        private List<uint> m_inactiveObjectIds;
    }

    public partial class EventCardPoolManager : Controller
    {
        /// <summary>
        /// Visualizes a new card.
        /// </summary>
        /// <returns>ID of created card</returns>
        public partial uint VisualizeCard(EventCardProperties template)
        {
            if (m_inactiveObjectIds.Count == 0)
            {
                InstantiateObject(isTemporary: true);
            }

            uint idToActivate = m_inactiveObjectIds[0];

            m_inactiveObjectIds.Remove(idToActivate);
            m_activeObjectIds.Add(idToActivate);

            m_objectPool[idToActivate].controller.Show();
            m_objectPool[idToActivate].controller.ResetAppearance(template);

            return idToActivate;
        }

        /// <summary>
        /// Removes a card from the visualization.
        /// </summary>
        /// <param name="id"></param>
        public partial void DevisualizeCard(uint id)
        {
            if (m_objectPool[id].isTemporary)
            {
                MonoBehaviour.Destroy(m_objectPool[id].controller.gameObject);
                m_objectPool.Remove(id);
                if (m_inactiveObjectIds.Contains(id))
                {
                    m_inactiveObjectIds.Remove(id);
                }
                else
                {
                    m_activeObjectIds.Remove(id);
                }
                return;
            }

            m_objectPool[id].controller.Hide();
            if (m_activeObjectIds.Contains(id))
            {
                m_inactiveObjectIds.Add(id);
                m_activeObjectIds.Remove(id);
            }
            else
            {
                m_inactiveObjectIds.Remove(id);
                m_activeObjectIds.Add(id);
            }
        }

        public partial EventCardController GetCardById(uint id)
        {
            if (!m_objectPool.ContainsKey(id))
            {
                print("ERROR: EventCardPoolManager: No object with id=" + id);
                return null;
            }

            return m_objectPool[id].controller;
        }

        protected override partial void Initialize()
        {
            m_objectPool = new Dictionary<uint, ObjectPoolItem>();
            m_activeObjectIds = new List<uint>();
            m_inactiveObjectIds = new List<uint>();

            for (uint iPoolObjects = 0; iPoolObjects < m_minimumPoolSize; iPoolObjects++)
            {
                InstantiateObject();
            }
        }

        private partial void InstantiateObject(bool isTemporary = false)
        {
            GameObject newObject;
            uint newObjectId;
            EventCardController newEventCardController;

            newObject = Instantiate(m_prefab);
            newObject.transform.SetParent(gameObject.transform);

            Vector3 newVector = new Vector3(Random.Range(-1920 / 2, 1920 / 2), Random.Range(-1080 / 2, 1080 / 2), 0);
            newObject.transform.localPosition = newVector;

            newEventCardController = newObject.GetComponent<EventCardController>();
            newEventCardController.Show();
            newEventCardController.Hide();

            newObjectId = newEventCardController.GetId();
            m_inactiveObjectIds.Add(newObjectId);
            m_objectPool.Add(newObjectId, new ObjectPoolItem(newEventCardController, isTemporary));
        }
    }
}