

namespace usea.func
{
    /// <summary>
    /// An interface that makes all tasks executable.
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Gets a unique name that can be used for identifying tasks.
        /// </summary>
        /// <returns></returns>
        public string GetName();

        /// <summary>
        /// Performs the action the task is responsible for. The onExecutionDone callback must be called 
        /// when the task is done, otherwise the scheduler will get stuck.
        /// </summary>
        /// <param name="onExecutionDone"></param>
        public void Execute(util.types.Callback onExecutionDone);
    }
}

