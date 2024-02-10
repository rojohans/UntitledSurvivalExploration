using UnityEngine;
using UnityEngine.Events;

namespace usea.graphics.gui
{
    public class InteractableGui : EventEnabled
    {
        //[Header("Sound")]
        //public bool defaultSound = true;

        /*
        [Header("Tooltip")]
        public string tooltipMessage = "";
        public GameObject tooltipObject;
        */

        /*
        protected void SetSoundListeners()
        {
            if (defaultSound)
            {
                AddOnPointerClickCallback(() => { HandlerContainer.soundHandler.PlaySound(Settings.GuiSettings.BUTTON_ON_POINTER_CLICK_SOUND_CLIP_NAME); });
                AddOnPointerEnterCallback(() => { HandlerContainer.soundHandler.PlaySound(Settings.GuiSettings.BUTTON_ON_POINTER_ENTER_SOUND_CLIP_NAME); });
            }
        }
        */

        /*
        protected void SetTooltipListeners()
        {
            if (tooltipMessage != "")
            {
                InteractableGui interactableGui;
                if (tooltipObject == null || !tooltipObject.TryGetComponent(out interactableGui))
                {
                    interactableGui = this;
                }
                interactableGui.AddOnPointerEnterCallback(() => { Tooltip.Show(tooltipMessage); });
                interactableGui.AddOnPointerExitCallback(() => { Tooltip.Hide(); });
                interactableGui.AddOnPointerClickCallback(() => { Tooltip.Hide(); });
            }
        }
        */
    }

    abstract public class InteractableGuiWithValue : InteractableGui
    {
        public event util.types.Callback _onValueChangedCallback;

        public void AddOnValueChangedCallback(util.types.Callback callback)
        {
            _onValueChangedCallback += callback;
        }

        protected void _OnValueChange()
        {
            _onValueChangedCallback?.Invoke();
        }
    }
}
