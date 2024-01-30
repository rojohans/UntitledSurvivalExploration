
using UnityEngine;
using UnityEngine.UI;
using usea.graphics.gui;

namespace usea.graphics.view
{
    public class ExampleView : MonoBehaviour
    {

        public delegate void Callback();

        // ###### PUBLIC ######
        public void AddButtonCallback(Callback OnButtonPress)
        {
            m_button.AddOnPointerClickCallback(() => { OnButtonPress(); });
            //m_button.onClick.AddListener(() => { OnButtonPress(); });
        }

        public void AddButtonTooltip(string message)
        {
            m_button.SetTooltip(message);
        }

        public void UpdateBar(float newValue)
        {
            m_slider.value = newValue;
        }

        // ###### PRIVATE ######
        [SerializeField] private Slider m_slider;
        //[SerializeField] private Button m_button;
        [SerializeField] private gui.Button m_button;
    }
}