
using UnityEngine;
using usea.util.types;

namespace usea.func.task
{
    public class StopGameplaySession : ITask
    {
        public string GetName()
        {
            return "StopGameplaySession";
        }

        public void Execute(Callback onExecutionDone)
        {
            MonoBehaviour.print("# settings views = " + data.Database.Get().GetGameplayData().GetNumberOfSettingsViews()); // TEMPORARY:
            data.Database.Get().ClearGameplayData();
            onExecutionDone();
        }
    }
}