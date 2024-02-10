
using System.Collections.Generic;

namespace usea.func.engine
{
    /// <summary>
    /// A class used to coordinate task execution. Only one task is executed at a time.
    /// </summary>
    public partial class Scheduler
    {
        // ###### TYPES ######
        public struct QueueItem
        {
            public ITask task;
            public util.types.Callback additionalCallback;
        }

        // ###### PUBLIC ######
        public static partial Scheduler Get();
        public partial void Schedule(ITask taskToSchedule, util.types.Callback onExecutionDone, bool shouldPrioritize);

        // ###### PRIVATE ######
        private partial void OnFrame();
        private partial void ExecuteNextTask();
        private static Scheduler m_instance;
        private LinkedList<QueueItem> m_queuedTasks;
        private bool m_isCurrentlyExecutingTask;
    }

    public partial class Scheduler
    {
        public Scheduler()
        {
            m_queuedTasks = new LinkedList<QueueItem>();
            m_isCurrentlyExecutingTask = false;
            graphics.controller.FrameTicker frameTicker = (graphics.controller.FrameTicker)graphics.GuiManager.Get().GetObject(graphics.GuiObjectTypeE.FRAME_TICKER);
            frameTicker.RegisterCallback(OnFrame);
        }

        /// <summary>
        /// Gets singleton instance.
        /// </summary>
        /// <returns></returns>
        public static partial Scheduler Get()
        {
            if (m_instance == null)
            {
                m_instance = new Scheduler();
            }
            return m_instance;
        }

        /// <summary>
        /// Adds a task to the execution queue. The task will not be executed right away.
        /// </summary>
        /// <param name="taskToSchedule"></param>
        /// <param name="onExecutionDone"></param>
        /// <param name="shouldPrioritize"></param>
        public partial void Schedule(ITask taskToSchedule, util.types.Callback onExecutionDone, bool shouldPrioritize)
        {
            QueueItem newItem = new() { task = taskToSchedule, additionalCallback = onExecutionDone };
            if (shouldPrioritize)
            {

                m_queuedTasks.AddFirst(newItem);
            }
            else
            {
                m_queuedTasks.AddLast(newItem);
            }
        }

        private partial void OnFrame()
        {
            // QUESTION: [8693rcq4f] Should there be fps management here???
            if (m_queuedTasks.Count > 0 && !m_isCurrentlyExecutingTask)
            {
                ExecuteNextTask();
            }
        }

        private partial void ExecuteNextTask()
        {
            QueueItem itemToExecute = m_queuedTasks.First.Value;
            m_queuedTasks.RemoveFirst();

            m_isCurrentlyExecutingTask = true;
            itemToExecute.additionalCallback += () => { m_isCurrentlyExecutingTask = false; };
            itemToExecute.task.Execute(itemToExecute.additionalCallback);
        }
    }
}