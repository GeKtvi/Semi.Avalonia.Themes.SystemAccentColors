namespace Workflow.Domain.Enums;

/// <summary>
/// Defines the possible states of a workflow task
/// </summary>
public enum TaskStatus
{
    /// <summary>
    /// Task is waiting to be executed
    /// </summary>
    Pending = 0,
    
    /// <summary>
    /// Task is currently being executed
    /// </summary>
    Running = 1,
    
    /// <summary>
    /// Task completed successfully
    /// </summary>
    Completed = 2,
    
    /// <summary>
    /// Task failed with an error
    /// </summary>
    Failed = 3,
    
    /// <summary>
    /// Task was skipped
    /// </summary>
    Skipped = 4,
    
    /// <summary>
    /// Task was cancelled
    /// </summary>
    Cancelled = 5
}