using System.ComponentModel.DataAnnotations;
using Workflow.Domain.Enums;
using Workflow.Domain.ValueObjects;

namespace Workflow.Domain.Entities;

/// <summary>
/// Represents a running instance of a task within a workflow instance
/// </summary>
public class TaskInstance : BaseEntity
{
    /// <summary>
    /// Reference to the workflow task definition
    /// </summary>
    public Guid WorkflowTaskId { get; set; }

    /// <summary>
    /// Workflow task definition
    /// </summary>
    public virtual WorkflowTask WorkflowTask { get; set; } = null!;

    /// <summary>
    /// Reference to the workflow instance
    /// </summary>
    public Guid WorkflowInstanceId { get; set; }

    /// <summary>
    /// Workflow instance
    /// </summary>
    public virtual WorkflowInstance WorkflowInstance { get; set; } = null!;

    /// <summary>
    /// Task instance name
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Current status of the task instance
    /// </summary>
    public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.Pending;

    /// <summary>
    /// Task priority
    /// </summary>
    public Priority Priority { get; set; } = Priority.Normal;

    /// <summary>
    /// User assigned to this task instance
    /// </summary>
    [MaxLength(100)]
    public string? AssignedTo { get; set; }

    /// <summary>
    /// When the task was started
    /// </summary>
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// When the task was completed
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Task due date
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Task input data (JSON)
    /// </summary>
    public string InputDataJson { get; set; } = "{}";

    /// <summary>
    /// Task output data (JSON)
    /// </summary>
    public string OutputDataJson { get; set; } = "{}";

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
    /// Comments or notes about the task
    /// </summary>
    [MaxLength(2000)]
    public string? Comments { get; set; }

    /// <summary>
    /// External reference or correlation ID
    /// </summary>
    [MaxLength(100)]
    public string? ExternalReferenceId { get; set; }

    /// <summary>
    /// Gets input data as strongly typed object
    /// </summary>
    public WorkflowData GetInputData()
    {
        return WorkflowData.FromJson(InputDataJson);
    }

    /// <summary>
    /// Sets input data from strongly typed object
    /// </summary>
    public void SetInputData(WorkflowData data)
    {
        InputDataJson = data.ToJson();
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Gets output data as strongly typed object
    /// </summary>
    public WorkflowData GetOutputData()
    {
        return WorkflowData.FromJson(OutputDataJson);
    }

    /// <summary>
    /// Sets output data from strongly typed object
    /// </summary>
    public void SetOutputData(WorkflowData data)
    {
        OutputDataJson = data.ToJson();
        UpdatedAt = DateTime.UtcNow;
    }
}