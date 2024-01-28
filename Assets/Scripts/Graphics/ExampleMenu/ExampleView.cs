
using UnityEngine;
using UnityEngine.UI;

namespace usea.graphics.view
{
    public class ExampleView : MonoBehaviour
    {

        public delegate void Callback();

        // ###### PUBLIC ######
        public void AddButtonCallback(Callback OnButtonPress)
        {
            m_button.onClick.AddListener(() => { OnButtonPress(); });
            //m_slider.on
        }

        public void UpdateBar(float newValue)
        {
            m_slider.value = newValue;
        }

        // ###### PRIVATE ######
        [SerializeField] private Slider m_slider;
        [SerializeField] private Button m_button;
    }
}