
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using usea.data.gameplay;
using usea.graphics.controller;

namespace usea.graphics.scene
{
    /// <summary>
    /// This scene is where all the gameplay takes place. It is possible this scene will need to be subdivided.
    /// </summary>
    public partial class GameSessionScene : controller.Controller
    {
        // ###### PUBLIC ######
        public partial void SetCallbacks(usea.util.types.Callback onOpenSettings,
                                         usea.util.types.Callback onClose,
                                         usea.util.types.Callback onCloseProgram);

        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        [SerializeField] private view.GameSessionView m_view;
        private usea.util.types.Callback m_onOpenSettings;
        private usea.util.types.Callback m_onClose;
        private usea.util.types.Callback m_onCloseProgram;

        private List<uint> m_cardIds;
    }

    public partial class GameSessionScene : controller.Controller
    {
        public partial void SetCallbacks(usea.util.types.Callback onOpenSettings,
                                         usea.util.types.Callback onClose,
                                         usea.util.types.Callback onCloseProgram)
        {
            m_onOpenSettings = onOpenSettings;
            m_onClose = onClose;
            m_onCloseProgram = onCloseProgram;
        }

        protected override partial void Initialize()
        {
            m_cardIds = new List<uint>();

            m_view.m_mainMenuButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onClose(); });
            m_view.m_settingsButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onOpenSettings(); });
            m_view.m_quitProgramButton.AddOnPointerClickCallback((PointerEventData eventData) => { m_onCloseProgram(); });


            m_view.m_newCardButton.AddOnPointerClickCallback((PointerEventData eventData) =>
            {
                Dictionary<uint, EventCardTemplate> eventCards = data.Database.Get().GetGameplayData().getEventCardtemplates();

                EventCardPoolManager a = (EventCardPoolManager)GuiManager.Get().GetObject(GuiObjectTypeE.EVENT_CARD_POOL_MANAGER);
                m_cardIds.Add(a.VisualizeCard(eventCards[(uint)Random.Range(0, eventCards.Count)].GetProperties())); // TEMPORARY: Using randomness is just for testing.
            });

            m_view.m_destroyCardButton.AddOnPointerClickCallback((PointerEventData eventData) =>
            {
                if (m_cardIds.Count == 0)
                {
                    return;
                }

                EventCardPoolManager a = (EventCardPoolManager)GuiManager.Get().GetObject(GuiObjectTypeE.EVENT_CARD_POOL_MANAGER);
                uint idToDestroy = m_cardIds[Random.Range(0, m_cardIds.Count)];

                a.DevisualizeCard(idToDestroy);
                m_cardIds.Remove(idToDestroy);
            });
        }
    }
}