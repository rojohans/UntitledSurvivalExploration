
// usea: Untitled Survival Exploration Adventure


using usea.events; /// #include EventsExample.cs
using usea.data; /// #include DataExample.cs

namespace usea
{


    /// <summary>
    /// Some main classie.
    /// </summary>
    /// <include file="EventsExample.cs">
    class Main
    {

        public Main()
        {
            initializeStuff();
        }

        private void initializeStuff()
        {
            m_eventExample = new EventExample();
            m_eventExample.initialize();

            Database.initialize();
        }

        private EventExample m_eventExample;
    };
}
