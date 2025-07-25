namespace Workflow.Domain.Enums;

/// <summary>
/// Defines the possible states of a workflow instance
/// </summary>
public enum WorkflowInstanceStatus
{
    /// <summary>
    /// Instance has been created but not yet started
    /// </summary>
    Pending = 0,
    
    /// <summary>
    /// Instance is currently running
    /// </summary>
    Running = 1,
    
    /// <summary>
    /// Instance is waiting for user input or external event
    /// </summary>
    Waiting = 2,
    
    /// <summary>
    /// Instance has been paused
    /// </summary>
    Paused = 3,
    
    /// <summary>
    /// Instance completed successfully
    /// </summary>
    Completed = 4,
    
    /// <summary>
    /// Instance failed with an error
    /// </summary>
    Failed = 5,
    
    /// <summary>
    /// Instance was cancelled
    /// </summary>
    Cancelled = 6,
    
    /// <summary>
    /// Instance timed out
    /// </summary>
    TimedOut = 7
}