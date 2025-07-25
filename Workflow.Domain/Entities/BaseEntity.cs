using System.ComponentModel.DataAnnotations;

namespace Workflow.Domain.Entities;

/// <summary>
/// Base entity class with common properties
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Last update timestamp
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// User who created the entity
    /// </summary>
    public string CreatedBy { get; set; } = string.Empty;

    /// <summary>
    /// User who last updated the entity
    /// </summary>
    public string UpdatedBy { get; set; } = string.Empty;

    /// <summary>
    /// Version for optimistic concurrency control
    /// </summary>
    [Timestamp]
    public byte[] Version { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// Soft delete flag
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Deletion timestamp
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// User who deleted the entity
    /// </summary>
    public string? DeletedBy { get; set; }
}