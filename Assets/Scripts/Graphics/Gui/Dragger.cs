
namespace usea.graphics.gui
{
    /// <summary>
    /// A custom GUI element for making objects draggable.
    /// </summary>
    public partial class Dragger : GuiBase
    {
        // ###### PROTECTED ######
        protected override partial void Initialize();

        // ###### PRIVATE ######
        private util.ObjectDragger m_objectDragger;
    }

    public partial class Dragger : GuiBase
    {
        protected override partial void Initialize()
        {
            m_objectDragger = gameObject.AddComponent<util.ObjectDragger>();
            m_objectDragger.Initialize(this, transform.parent.GetComponent<UnityEngine.Transform>());
        }
    }
}