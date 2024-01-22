

using UnityEngine;
using usea.graphics.model;
using usea.graphics.view;

namespace usea.graphics.controller
{
    public class ExampleController : Controller<ExampleModel, ExampleView>
    {
        protected override void Initialize()
        {
            print("Initialize");
            m_view.m_button.onClick.AddListener(OnButtonPress);
        }

        protected override void Show()
        {
            print("Show");
            m_view.UpdateBar(m_model.GetChargeRate());
        }

        protected override void Hide()
        {
            print("Hide");
        }

        private void OnButtonPress()
        {
            print("OnButtonPress");
            m_model.IncreaseCharge(1);
            m_view.UpdateBar(m_model.GetChargeRate());
        }

        void Update()
        {
            m_model.DecreaseCharge(Time.deltaTime);
            m_view.UpdateBar(m_model.GetChargeRate());
        }
    }
}