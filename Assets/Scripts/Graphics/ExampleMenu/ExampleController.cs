


using UnityEngine;
using usea.graphics.model;
using usea.graphics.view;


namespace usea.graphics.controller
{
    public partial class ExampleController : Controller
    {
        // ###### PUBLIC ######
        public partial void Update();

        // ###### PROTECTED ######
        protected override partial void Initialize();
        protected override partial void Show();
        protected override partial void Hide();

        // ###### PRIVATE ######
        private partial void OnButtonPress();
        [SerializeField] private ExampleModel m_model;
        [SerializeField] private ExampleView m_view;
    }

    public partial class ExampleController : Controller
    {
        public partial void Update()
        {
            m_model.DecreaseCharge(Time.deltaTime);
            m_view.m_slider.value = m_model.GetChargeRate();
        }

        protected override partial void Initialize()
        {
            print("Initialize");
            m_model.SetChargeIncrement(1);
            m_view.m_button.AddOnPointerClickCallback(OnButtonPress);
            m_view.m_toggle.SetOnCallback(() => { m_model.SetChargeIncrement(3); });
            m_view.m_toggle.SetOffCallback(() => { m_model.SetChargeIncrement(1); });
            //m_view.m_toggle.SetTooltip("On: Increment=3\nOff: Increment=1");
            m_view.m_slider.value = m_model.GetChargeRate();
        }

        protected override partial void Show()
        {
            print("Show");
        }

        protected override partial void Hide()
        {
            print("Hide");
        }

        private partial void OnButtonPress()
        {
            print("OnButtonPress");
            m_model.IncreaseCharge();
            m_view.m_slider.value = m_model.GetChargeRate();
        }
    }
}