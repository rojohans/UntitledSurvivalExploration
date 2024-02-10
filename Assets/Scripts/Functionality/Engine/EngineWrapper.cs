
namespace usea.func.engine
{
    /// <summary>
    /// A wrapper class, that enables tasks to be scheduled and timed. It also enables better logging for execution.
    /// </summary>
    public partial class EngineWrapper : ITask
    {
        // ###### PUBLIC ######
        public partial string GetName();
        public partial void Execute(util.types.Callback onExecutionDone = null);
        public partial void Schedule(util.types.Callback onExecutionDone = null, bool shouldPrioritize = false);
        // TODO: [8693th5n6] Implement: public void SetTimer()

        // ###### PRIVATE ######
        private ITask m_task;
    }

    public partial class EngineWrapper : ITask
    {
        public EngineWrapper(ITask task)
        {
            m_task = task;
        }

        public partial string GetName()
        {
            return m_task.GetName();
        }

        public partial void Execute(util.types.Callback onExecutionDone = null)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            onExecutionDone += () =>
            {
                stopWatch.Stop();
                UnityEngine.MonoBehaviour.print("   EXECUTION DONE: " + m_task.GetName() + ", elapsed time: " + stopWatch.ElapsedMilliseconds + " ms");
            };

            UnityEngine.MonoBehaviour.print("EXECUTION STARTED: " + m_task.GetName());
            m_task.Execute(onExecutionDone);
        }

        /// <summary>
        /// Schedules the task for execution. Execution is done according to a queue.
        /// </summary>
        /// <param name="onExecutionDone"></param>
        /// <param name="shouldPrioritize"></param>
        public partial void Schedule(util.types.Callback onExecutionDone = null, bool shouldPrioritize = false)
        {
            Scheduler.Get().Schedule(this, onExecutionDone, shouldPrioritize);
        }
    }
}
