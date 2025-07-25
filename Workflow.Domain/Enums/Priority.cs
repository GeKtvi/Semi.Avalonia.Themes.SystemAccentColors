namespace Workflow.Domain.Enums;

/// <summary>
/// Defines priority levels for workflows and tasks
/// </summary>
public enum Priority
{
    /// <summary>
    /// Low priority
    /// </summary>
    Low = 0,
    
    /// <summary>
    /// Normal priority
    /// </summary>
    Normal = 1,
    
    /// <summary>
    /// High priority
    /// </summary>
    High = 2,
    
    /// <summary>
    /// Critical priority
    /// </summary>
    Critical = 3,
    
    /// <summary>
    /// Emergency priority
    /// </summary>
    Emergency = 4
}