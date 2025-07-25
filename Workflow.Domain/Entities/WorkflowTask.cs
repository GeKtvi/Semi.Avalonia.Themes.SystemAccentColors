using System.ComponentModel.DataAnnotations;
using Workflow.Domain.Enums;

namespace Workflow.Domain.Entities;

/// <summary>
/// Represents a task definition within a workflow
/// </summary>
public class WorkflowTask : BaseEntity
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
    /// Task name
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Task description
    /// </summary>
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Type of task
    /// </summary>
    public TaskType TaskType { get; set; } = TaskType.Manual;

    /// <summary>
    /// Unique identifier within the workflow
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string TaskKey { get; set; } = string.Empty;

    /// <summary>
    /// Order/sequence in the workflow
    /// </summary>
    public int SequenceOrder { get; set; }

    /// <summary>
    /// Task priority
    /// </summary>
    public Priority Priority { get; set; } = Priority.Normal;

    /// <summary>
    /// Indicates if this task is required
    /// </summary>
    public bool IsRequired { get; set; } = true;

    /// <summary>
    /// Task configuration (JSON)
    /// </summary>
    public string ConfigurationJson { get; set; } = "{}";

    /// <summary>
    /// Conditions for task execution (JSON)
    /// </summary>
    public string? ExecutionConditions { get; set; }

    /// <summary>
    /// Task timeout in minutes
    /// </summary>
    public int? TimeoutMinutes { get; set; }

    /// <summary>
    /// Number of retry attempts for this task
    /// </summary>
    public int MaxRetries { get; set; } = 3;

    /// <summary>
    /// Assigned user or role
    /// </summary>
    [MaxLength(100)]
    public string? AssignedTo { get; set; }

    /// <summary>
    /// Form definition for manual tasks (JSON)
    /// </summary>
    public string? FormDefinition { get; set; }

    /// <summary>
    /// Previous task dependencies
    /// </summary>
    [MaxLength(500)]
    public string? PreviousTasks { get; set; }

    /// <summary>
    /// Next task references
    /// </summary>
    [MaxLength(500)]
    public string? NextTasks { get; set; }

    /// <summary>
    /// Task instances created from this definition
    /// </summary>
    public virtual ICollection<TaskInstance> TaskInstances { get; set; } = new List<TaskInstance>();
}