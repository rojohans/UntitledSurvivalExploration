
using System.Runtime.InteropServices;
using UnityEngine;

namespace usea.util
{
    public partial class Optional<T>
    {
        //###### PUBLIC ######
        public partial void SetValue(T value);
        public partial bool HasValue();
        public partial T GetValue();

        //###### PRIVATE ######
        private T m_value;
        private bool m_hasValue;
    }

    public partial class Optional<T>
    {
        public partial void SetValue(T value)
        {
            m_value = value;
            m_hasValue = true;
        }

        public partial bool HasValue()
        {
            return m_hasValue;
        }

        public partial T GetValue()
        {
            if (!m_hasValue)
            {
                MonoBehaviour.print("NO VALUE EXIST FOR OPTIONAL TYPE.");
                return default;
            }

            return m_value;
        }

        public Optional()
        {
            m_hasValue = false;
        }
    }
}