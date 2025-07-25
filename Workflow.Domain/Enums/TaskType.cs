namespace Workflow.Domain.Enums;

/// <summary>
/// Defines the different types of workflow tasks
/// </summary>
public enum TaskType
{
    /// <summary>
    /// Manual task requiring user interaction
    /// </summary>
    Manual = 0,
    
    /// <summary>
    /// Automated system task
    /// </summary>
    Automated = 1,
    
    /// <summary>
    /// Decision point with conditional logic
    /// </summary>
    Decision = 2,
    
    /// <summary>
    /// Start point of the workflow
    /// </summary>
    StartEvent = 3,
    
    /// <summary>
    /// End point of the workflow
    /// </summary>
    EndEvent = 4,
    
    /// <summary>
    /// Timer-based task
    /// </summary>
    Timer = 5,
    
    /// <summary>
    /// Email notification task
    /// </summary>
    EmailNotification = 6,
    
    /// <summary>
    /// Approval task
    /// </summary>
    Approval = 7,
    
    /// <summary>
    /// Data transformation task
    /// </summary>
    DataTransformation = 8,
    
    /// <summary>
    /// Integration with external systems
    /// </summary>
    Integration = 9
}