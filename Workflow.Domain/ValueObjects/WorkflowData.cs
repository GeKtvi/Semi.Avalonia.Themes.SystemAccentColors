using System.Text.Json;

namespace Workflow.Domain.ValueObjects;

/// <summary>
/// Value object representing workflow data and variables
/// </summary>
public class WorkflowData
{
    private readonly Dictionary<string, object> _data;

    public WorkflowData() : this(new Dictionary<string, object>()) { }

    public WorkflowData(Dictionary<string, object> data)
    {
        _data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public IReadOnlyDictionary<string, object> Data => _data.AsReadOnly();

    public T? GetValue<T>(string key)
    {
        if (!_data.ContainsKey(key))
            return default;

        var value = _data[key];
        if (value is T directValue)
            return directValue;

        if (value is JsonElement jsonElement)
            return JsonSerializer.Deserialize<T>(jsonElement.GetRawText());

        try
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        catch
        {
            return default;
        }
    }

    public void SetValue(string key, object value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        _data[key] = value;
    }

    public bool HasValue(string key)
    {
        return _data.ContainsKey(key);
    }

    public void RemoveValue(string key)
    {
        _data.Remove(key);
    }

    public WorkflowData Clone()
    {
        var clonedData = new Dictionary<string, object>(_data);
        return new WorkflowData(clonedData);
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(_data, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }

    public static WorkflowData FromJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return new WorkflowData();

        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json) 
                   ?? new Dictionary<string, object>();
        return new WorkflowData(data);
    }
}