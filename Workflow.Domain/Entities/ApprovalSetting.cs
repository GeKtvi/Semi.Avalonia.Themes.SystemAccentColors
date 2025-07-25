using System.ComponentModel.DataAnnotations;
using Workflow.Domain.Enums;

namespace Workflow.Domain.Entities;

/// <summary>
/// Represents approval settings for a workflow
/// </summary>
public class ApprovalSetting : BaseEntity
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
    /// Setting name
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Setting description
    /// </summary>
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Task key this setting applies to (null for workflow-level)
    /// </summary>
    [MaxLength(100)]
    public string? TaskKey { get; set; }

    /// <summary>
    /// Approval level/stage
    /// </summary>
    public int ApprovalLevel { get; set; } = 1;

    /// <summary>
    /// Required approvers (comma-separated users/roles)
    /// </summary>
    [Required]
    [MaxLength(1000)]
    public string RequiredApprovers { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if all listed approvers are required
    /// </summary>
    public bool RequiresAllApprovers { get; set; }

    /// <summary>
    /// Minimum number of approvers required (if not all)
    /// </summary>
    public int? MinimumApprovers { get; set; }

    /// <summary>
    /// Auto-escalation timeout in hours
    /// </summary>
    public int? EscalationTimeoutHours { get; set; }

    /// <summary>
    /// Escalation approvers (comma-separated)
    /// </summary>
    [MaxLength(1000)]
    public string? EscalationApprovers { get; set; }

    /// <summary>
    /// Conditions for this approval (JSON)
    /// </summary>
    public string? ApprovalConditions { get; set; }

    /// <summary>
    /// Priority threshold for this approval
    /// </summary>
    public Priority? PriorityThreshold { get; set; }

    /// <summary>
    /// Indicates if this setting is active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Notification settings (JSON)
    /// </summary>
    public string? NotificationSettings { get; set; }
}