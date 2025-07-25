using System.ComponentModel.DataAnnotations;
using Workflow.Domain.Enums;
using Workflow.Domain.ValueObjects;

namespace Workflow.Domain.Entities;

/// <summary>
/// Represents a running instance of a workflow
/// </summary>
public class WorkflowInstance : BaseEntity
{
    /// <summary>
    /// Reference to the workflow definition
    /// </summary>
    public Guid WorkflowDefinitionId { get; set; }

    /// <summary>
    /// Workflow definition
    /// </summary>
    public virtual WorkflowDefinition WorkflowDefinition { get; set; } = null!;

    /// <summary>
    /// Instance name/title
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Current status of the workflow instance
    /// </summary>
    public WorkflowInstanceStatus Status { get; set; } = WorkflowInstanceStatus.Pending;

    /// <summary>
    /// Instance priority
    /// </summary>
    public Priority Priority { get; set; } = Priority.Normal;

    /// <summary>
    /// User who initiated the workflow
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string InitiatedBy { get; set; } = string.Empty;

    /// <summary>
    /// When the workflow was started
    /// </summary>
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// When the workflow was completed
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Expected completion date
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Current step/task in the workflow
    /// </summary>
    [MaxLength(100)]
    public string CurrentStep { get; set; } = string.Empty;

    /// <summary>
    /// Workflow instance data (JSON)
    /// </summary>
    public string DataJson { get; set; } = "{}";

    /// <summary>
    /// Error message if failed
    /// </summary>
    [MaxLength(2000)]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Stack trace if failed
    /// </summary>
    public string? ErrorStackTrace { get; set; }

    /// <summary>
    /// Number of retry attempts
    /// </summary>
    public int RetryCount { get; set; }

    /// <summary>
    /// Progress percentage (0-100)
    /// </summary>
    public int ProgressPercentage { get; set; }

    /// <summary>
    /// External reference ID
    /// </summary>
    [MaxLength(100)]
    public string? ExternalReferenceId { get; set; }

    /// <summary>
    /// Comments or notes about the instance
    /// </summary>
    [MaxLength(2000)]
    public string? Comments { get; set; }

    /// <summary>
    /// Task instances for this workflow instance
    /// </summary>
    public virtual ICollection<TaskInstance> TaskInstances { get; set; } = new List<TaskInstance>();

    /// <summary>
    /// Audit log entries for this instance
    /// </summary>
    public virtual ICollection<WorkflowAuditLog> AuditLogs { get; set; } = new List<WorkflowAuditLog>();

    /// <summary>
    /// Approval requests for this instance
    /// </summary>
    public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();

    /// <summary>
    /// Gets workflow data as strongly typed object
    /// </summary>
    public WorkflowData GetWorkflowData()
    {
        return WorkflowData.FromJson(DataJson);
    }

    /// <summary>
    /// Sets workflow data from strongly typed object
    /// </summary>
    public void SetWorkflowData(WorkflowData data)
    {
        DataJson = data.ToJson();
        UpdatedAt = DateTime.UtcNow;
    }
}