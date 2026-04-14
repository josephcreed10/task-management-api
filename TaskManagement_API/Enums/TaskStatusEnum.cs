using System.Text.Json.Serialization;

namespace TaskManagement_API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaskStatusEnum
    {
        Pending,
        InProgress,
        Completed
    }
}
