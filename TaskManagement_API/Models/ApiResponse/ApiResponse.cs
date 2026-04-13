namespace TaskManagement_API.Models.ApiResponse
{
    public class ApiResponse<TData>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public TData? Data { get; set; }
        public object? Errors { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public static ApiResponse<TData> Create(bool success, int statusCode, string message, TData? data = default, object? errors = default)
        {
            return new ApiResponse<TData>
            {
                Success = success,
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Errors = errors
            };
        }
        public static ApiResponse<TData> Ok(TData? data, string message) => Create(true, StatusCodes.Status200OK, message, data);
        public static ApiResponse<TData> CreatedAt(TData? data, string message) => Create(true, StatusCodes.Status201Created, message, data);
        public static ApiResponse<TData> NotFound(string message) => Create(false, StatusCodes.Status404NotFound, message);
        public static ApiResponse<TData> BadRequest(string message) => Create(false, StatusCodes.Status400BadRequest, message);
        public static ApiResponse<TData> Conflict(string message) => Create(false, StatusCodes.Status409Conflict, message);

    }
}
