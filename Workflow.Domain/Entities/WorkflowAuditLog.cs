using System.ComponentModel.DataAnnotations;

namespace Workflow.Domain.Entities;

/// <summary>
/// Represents an audit log entry for workflow activities
/// </summary>
public class WorkflowAuditLog : BaseEntity
{
    /// <summary>
    /// Reference to the workflow instance
    /// </summary>
    public Guid WorkflowInstanceId { get; set; }

    /// <summary>
    /// Workflow instance
    /// </summary>
    public virtual WorkflowInstance WorkflowInstance { get; set; } = null!;

    /// <summary>
    /// Reference to the task instance (if applicable)
    /// </summary>
    public Guid? TaskInstanceId { get; set; }

    /// <summary>
    /// Task instance
    /// </summary>
    public virtual TaskInstance? TaskInstance { get; set; }

    /// <summary>
    /// Action performed (Started, Completed, Failed, Approved, etc.)
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Action { get; set; } = string.Empty;

    /// <summary>
    /// User who performed the action
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string PerformedBy { get; set; } = string.Empty;

    /// <summary>
    /// Description of the action
    /// </summary>
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Previous state/value
    /// </summary>
    [MaxLength(500)]
    public string? PreviousState { get; set; }

    /// <summary>
    /// New state/value
    /// </summary>
    [MaxLength(500)]
    public string? NewState { get; set; }

    /// <summary>
    /// Additional data related to the action (JSON)
    /// </summary>
    public string? ActionDataJson { get; set; }

    /// <summary>
    /// Error details if action failed
    /// </summary>
    [MaxLength(2000)]
    public string? ErrorDetails { get; set; }

    /// <summary>
    /// Source of the action (System, User, API, etc.)
    /// </summary>
    [MaxLength(50)]
    public string ActionSource { get; set; } = "System";

    /// <summary>
    /// IP address of the action source
    /// </summary>
    [MaxLength(45)]
    public string? SourceIpAddress { get; set; }

    /// <summary>
    /// User agent if action came from web
    /// </summary>
    [MaxLength(500)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Duration of the action in milliseconds
    /// </summary>
    public long? DurationMs { get; set; }
}