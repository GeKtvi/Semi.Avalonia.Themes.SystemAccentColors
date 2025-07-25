using System.ComponentModel.DataAnnotations;
using Workflow.Domain.Enums;

namespace Workflow.Domain.Entities;

/// <summary>
/// Represents a workflow definition/template
/// </summary>
public class WorkflowDefinition : BaseEntity
{
    /// <summary>
    /// Workflow name
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Workflow description
    /// </summary>
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Workflow category for organization
    /// </summary>
    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Current status of the workflow definition
    /// </summary>
    public WorkflowStatus Status { get; set; } = WorkflowStatus.Draft;

    /// <summary>
    /// Version number of the workflow
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string VersionNumber { get; set; } = "1.0.0";

    /// <summary>
    /// Indicates if this is the active version
    /// </summary>
    public bool IsActiveVersion { get; set; }

    /// <summary>
    /// JSON representation of the workflow definition
    /// </summary>
    public string DefinitionJson { get; set; } = string.Empty;

    /// <summary>
    /// Workflow priority
    /// </summary>
    public Priority Priority { get; set; } = Priority.Normal;

    /// <summary>
    /// Maximum execution time in minutes (null for unlimited)
    /// </summary>
    public int? TimeoutMinutes { get; set; }

    /// <summary>
    /// Maximum number of retries for failed instances
    /// </summary>
    public int MaxRetries { get; set; } = 3;

    /// <summary>
    /// Tags for categorization and search
    /// </summary>
    [MaxLength(500)]
    public string Tags { get; set; } = string.Empty;

    /// <summary>
    /// Workflow tasks
    /// </summary>
    public virtual ICollection<WorkflowTask> Tasks { get; set; } = new List<WorkflowTask>();

    /// <summary>
    /// Workflow instances created from this definition
    /// </summary>
    public virtual ICollection<WorkflowInstance> Instances { get; set; } = new List<WorkflowInstance>();

    /// <summary>
    /// Workflow variables schema
    /// </summary>
    public virtual ICollection<WorkflowVariable> Variables { get; set; } = new List<WorkflowVariable>();

    /// <summary>
    /// Approval settings for this workflow
    /// </summary>
    public virtual ICollection<ApprovalSetting> ApprovalSettings { get; set; } = new List<ApprovalSetting>();
}