using System.ComponentModel.DataAnnotations;
using Workflow.Domain.Enums;

namespace Workflow.Domain.Entities;

/// <summary>
/// Represents an approval request within a workflow
/// </summary>
public class ApprovalRequest : BaseEntity
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
    /// Approval request title
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Approval request description
    /// </summary>
    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// User who requested the approval
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string RequestedBy { get; set; } = string.Empty;

    /// <summary>
    /// User(s) who can approve (comma-separated)
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string Approvers { get; set; } = string.Empty;

    /// <summary>
    /// Current status of the approval request
    /// </summary>
    public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;

    /// <summary>
    /// Priority of the approval request
    /// </summary>
    public Priority Priority { get; set; } = Priority.Normal;

    /// <summary>
    /// Request due date
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// User who approved/rejected the request
    /// </summary>
    [MaxLength(100)]
    public string? ProcessedBy { get; set; }

    /// <summary>
    /// When the request was processed
    /// </summary>
    public DateTime? ProcessedAt { get; set; }

    /// <summary>
    /// Approval/rejection comments
    /// </summary>
    [MaxLength(2000)]
    public string? Comments { get; set; }

    /// <summary>
    /// Additional data for the approval (JSON)
    /// </summary>
    public string? ApprovalDataJson { get; set; }

    /// <summary>
    /// Indicates if multiple approvers are required
    /// </summary>
    public bool RequiresAllApprovers { get; set; }

    /// <summary>
    /// Number of approvers required (if not all)
    /// </summary>
    public int? RequiredApproverCount { get; set; }

    /// <summary>
    /// Current approval count
    /// </summary>
    public int CurrentApprovalCount { get; set; }
}

/// <summary>
/// Approval status enumeration
/// </summary>
public enum ApprovalStatus
{
    Pending = 0,
    Approved = 1,
    Rejected = 2,
    Cancelled = 3,
    Expired = 4
}