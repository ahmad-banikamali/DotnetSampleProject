namespace Application.Infrastructure;

public record Response(string Message = "", bool IsSuccess = true);

public record Response<T>(T? Data = default, string Message = "", bool IsSuccess = true);