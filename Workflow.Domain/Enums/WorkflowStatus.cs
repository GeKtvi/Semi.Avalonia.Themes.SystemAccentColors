namespace Workflow.Domain.Enums;

/// <summary>
/// Defines the possible states of a workflow
/// </summary>
public enum WorkflowStatus
{
    /// <summary>
    /// Workflow is being drafted and not yet active
    /// </summary>
    Draft = 0,
    
    /// <summary>
    /// Workflow is active and can process instances
    /// </summary>
    Active = 1,
    
    /// <summary>
    /// Workflow is paused and not processing new instances
    /// </summary>
    Paused = 2,
    
    /// <summary>
    /// Workflow is archived and no longer in use
    /// </summary>
    Archived = 3,
    
    /// <summary>
    /// Workflow has been deleted
    /// </summary>
    Deleted = 4
}