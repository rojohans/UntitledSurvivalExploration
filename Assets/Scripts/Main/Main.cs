
// usea: Untitled Survival Exploration Adventure


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
            // m_eventExample = new events.EventExample();
            // m_eventExample.initialize();

            data.Database.initialize();
        }

        //private events.EventExample m_eventExample;
    };
}
