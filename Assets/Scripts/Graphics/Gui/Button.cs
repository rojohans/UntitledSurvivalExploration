using UnityEngine;
using TMPro;
using UnityEngine.UI;
using usea.graphics.controller;

namespace usea.graphics.gui
{
    public class Button : EventEnabled
    {
        [System.Serializable]
        public struct ColourSettings
        {
            public Color normal;
            public Color onPointerEnter;
            public Color onPointerClick;
        };

        [Header("Colour")]
        public ColourSettings boxColour;
        public ColourSettings textColour;

        public void Awake()
        {
            //SetSoundListeners();
            //SetTooltipListeners();
            //SetColourListeners();
        }

        public void SetTooltip(string message)
        {
            AddOnPointerEnterCallback(() =>
            {
                TooltipController a = (TooltipController)GuiManager.Get().GetObject(GuiObjectTypeE.TOOLTIP);
                print(message);
                a.Activate(message);
            });

            AddOnPointerExitCallback(() =>
            {
                TooltipController a = (TooltipController)GuiManager.Get().GetObject(GuiObjectTypeE.TOOLTIP);
                a.Deactivate();
            });
        }

        private void SetColourListeners()
        {
            Image image = transform.Find("Image").GetComponent<Image>();
            boxColour.normal = image.color;
            AddOnPointerEnterCallback(() => { image.color = boxColour.onPointerEnter; });
            AddOnPointerExitCallback(() => { image.color = boxColour.normal; });
            AddOnPointerDownCallback(() => { image.color = boxColour.onPointerClick; });
            AddOnPointerUpCallback(() => { image.color = boxColour.normal; });

            TMP_Text text = transform.Find("Text").GetComponent<TMP_Text>();
            textColour.normal = text.color;
            AddOnPointerEnterCallback(() => { text.color = textColour.onPointerEnter; });
            AddOnPointerExitCallback(() => { text.color = textColour.normal; });
            AddOnPointerDownCallback(() => { text.color = textColour.onPointerClick; });
            AddOnPointerUpCallback(() => { image.color = boxColour.normal; });
        }

        // TODO: SetImage
    }
}


