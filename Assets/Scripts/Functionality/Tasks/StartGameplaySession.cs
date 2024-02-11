
using usea.util.types;

namespace usea.func.task
{
    public class StartGameplaySession : ITask
    {
        public string GetName()
        {
            return "StartGameplaySession";
        }

        public void Execute(Callback onExecutionDone)
        {
            data.Database.Get().ResetGameplayData();
            onExecutionDone();
        }
    }
}