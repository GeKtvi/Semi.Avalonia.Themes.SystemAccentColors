using System.ComponentModel.DataAnnotations;

namespace Workflow.Domain.Entities;

/// <summary>
/// Represents a variable definition for a workflow
/// </summary>
public class WorkflowVariable : BaseEntity
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
    /// Variable name/key
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Display name for UI
    /// </summary>
    [MaxLength(200)]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Variable description
    /// </summary>
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Data type (string, number, boolean, date, object, array)
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string DataType { get; set; } = "string";

    /// <summary>
    /// Default value (JSON)
    /// </summary>
    public string? DefaultValue { get; set; }

    /// <summary>
    /// Indicates if the variable is required
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    /// Indicates if the variable is input (provided at workflow start)
    /// </summary>
    public bool IsInput { get; set; }

    /// <summary>
    /// Indicates if the variable is output (returned at workflow end)
    /// </summary>
    public bool IsOutput { get; set; }

    /// <summary>
    /// Validation rules (JSON)
    /// </summary>
    public string? ValidationRules { get; set; }

    /// <summary>
    /// Display order in forms
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Variable category/group
    /// </summary>
    [MaxLength(100)]
    public string? Category { get; set; }
}