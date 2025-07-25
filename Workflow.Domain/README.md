# Workflow Domain Entities

A comprehensive set of domain entities for implementing workflow management in ASP.NET applications.

## Overview

This project provides a complete domain model for workflow management systems, including:

- **Workflow Definitions**: Templates that define the structure and behavior of workflows
- **Workflow Instances**: Running executions of workflow definitions
- **Tasks**: Individual steps within workflows
- **Approvals**: Approval mechanisms for workflow steps
- **Audit Logging**: Complete tracking of workflow activities
- **Variables**: Dynamic data management for workflows

## Core Entities

### WorkflowDefinition
Represents a workflow template/definition with:
- Basic metadata (name, description, category)
- Version control
- Status management (Draft, Active, Paused, Archived, Deleted)
- Priority and timeout settings
- JSON-based workflow definition
- Related tasks, variables, and approval settings

### WorkflowInstance
Represents a running instance of a workflow with:
- Reference to the workflow definition
- Current status and progress tracking
- User who initiated the workflow
- Start, completion, and due dates
- JSON-based instance data
- Error handling and retry mechanisms
- Related task instances and audit logs

### WorkflowTask
Represents a task definition within a workflow with:
- Task metadata and configuration
- Task type (Manual, Automated, Decision, etc.)
- Sequence ordering and dependencies
- Assignment and timeout settings
- Form definitions for manual tasks
- Execution conditions

### TaskInstance
Represents a running instance of a task with:
- Reference to task definition and workflow instance
- Status tracking and assignment
- Input/output data management
- Error handling and retry tracking
- Timing information

### Supporting Entities

- **WorkflowVariable**: Defines the schema for workflow variables
- **ApprovalRequest**: Manages approval requests within workflows
- **ApprovalSetting**: Configures approval rules for workflows
- **WorkflowAuditLog**: Tracks all workflow activities and changes

## Enums

### WorkflowStatus
- Draft, Active, Paused, Archived, Deleted

### WorkflowInstanceStatus
- Pending, Running, Waiting, Paused, Completed, Failed, Cancelled, TimedOut

### TaskStatus
- Pending, Running, Completed, Failed, Skipped, Cancelled

### TaskType
- Manual, Automated, Decision, StartEvent, EndEvent, Timer, EmailNotification, Approval, DataTransformation, Integration

### Priority
- Low, Normal, High, Critical, Emergency

### ApprovalStatus
- Pending, Approved, Rejected, Cancelled, Expired

## Value Objects

### WorkflowData
A strongly-typed container for workflow variables and data with:
- Dynamic key-value storage
- Type-safe value retrieval
- JSON serialization/deserialization
- Cloning capabilities

## Features

### Base Entity
All entities inherit from `BaseEntity` which provides:
- Unique identifier (Guid)
- Audit timestamps (CreatedAt, UpdatedAt)
- User tracking (CreatedBy, UpdatedBy)
- Soft delete support
- Optimistic concurrency control

### Data Management
- JSON-based flexible data storage
- Strongly-typed data access through value objects
- Comprehensive validation attributes
- Entity relationships with navigation properties

### Audit Trail
Complete audit logging with:
- Action tracking
- State change recording
- User and source identification
- Performance metrics
- Error details

## Usage Examples

### Creating a Workflow Definition
```csharp
var workflowDef = new WorkflowDefinition
{
    Name = "Document Approval Process",
    Description = "Multi-step document approval workflow",
    Category = "Document Management",
    Status = WorkflowStatus.Active,
    Priority = Priority.Normal,
    TimeoutMinutes = 1440, // 24 hours
    CreatedBy = "system@company.com"
};
```

### Starting a Workflow Instance
```csharp
var instance = new WorkflowInstance
{
    WorkflowDefinitionId = workflowDef.Id,
    Name = "Contract Review - ABC Corp",
    InitiatedBy = "user@company.com",
    Priority = Priority.High,
    DueDate = DateTime.UtcNow.AddDays(3)
};

var workflowData = new WorkflowData();
workflowData.SetValue("documentId", "DOC-12345");
workflowData.SetValue("requestedBy", "john.doe@company.com");
instance.SetWorkflowData(workflowData);
```

### Managing Task Instances
```csharp
var taskInstance = new TaskInstance
{
    WorkflowTaskId = task.Id,
    WorkflowInstanceId = instance.Id,
    Name = "Manager Review",
    Status = TaskStatus.Running,
    AssignedTo = "manager@company.com",
    DueDate = DateTime.UtcNow.AddHours(24)
};
```

## Integration with ASP.NET

These entities are designed to work seamlessly with:
- Entity Framework Core
- ASP.NET Core Web APIs
- ASP.NET Core MVC
- SignalR for real-time updates
- ASP.NET Core Identity for user management

## Database Considerations

The entities are designed with database optimization in mind:
- Indexed properties for common queries
- Appropriate string length limits
- Timestamp columns for audit trails
- Foreign key relationships
- Soft delete support

## Next Steps

To implement a complete workflow system, consider adding:
- Repository patterns
- Business logic services
- API controllers
- SignalR hubs for real-time updates
- Background services for workflow execution
- Notification services
- Reporting and analytics

This domain model provides a solid foundation for building robust workflow management systems in ASP.NET applications.