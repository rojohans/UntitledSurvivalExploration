
using usea.util.types;

namespace usea.func.task
{
    // TEMPORARY: This class is just for testing.
    public class ExampleTask : ITask
    {
        public string GetName()
        {
            return "ExampleTask";
        }

        public void Execute(Callback onExecutionDone)
        {
            int a = 0;
            for (int i = 0; i < 10000000; i++)
            {
                a += i;
            }

            onExecutionDone?.Invoke();
        }
    }
}