

using UnityEngine;
using UnityEngine.UI;

namespace usea.graphics.view
{
    public class ExampleView : MonoBehaviour
    {
        public void UpdateBar(float newValue)
        {
            m_slider.value = newValue;
        }

        public Slider m_slider;
        public Button m_button;
    }
}