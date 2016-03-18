using System;

namespace ResxTranslator.ResourceOperations
{
    public sealed class ResourceLoadProgressEventArgs : EventArgs
    {
        public ResourceLoadProgressEventArgs(string currentProcess, string currentlyProcessedItem, int progress,
            int progressTop)
        {
            Progress = progress;
            ProgressTop = progressTop;
            CurrentProcess = currentProcess;
            CurrentlyProcessedItem = currentlyProcessedItem;
        }

        public ResourceLoadProgressEventArgs(string currentProcess)
        {
            CurrentProcess = currentProcess;
        }

        /// <summary>
        ///     0 - 100
        /// </summary>
        public int Progress { get; }

        public int ProgressTop { get; }

        public string CurrentProcess { get; }
        public string CurrentlyProcessedItem { get; }
    }
}