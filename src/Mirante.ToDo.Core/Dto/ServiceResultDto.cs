namespace Mirante.ToDo.Core.Dto
{
    public class ServiceResultDto<T>
    {
        public bool Success { get; init; }
        public T? Data { get; init; }
        public List<string> Errors { get; init; } = [];

        public static ServiceResultDto<T> Ok(T data)
            => new() { Success = true, Data = data };

        public static ServiceResultDto<T> Fail(IEnumerable<string> errors)
            => new() { Success = false, Errors = errors.ToList() };

        public static ServiceResultDto<T> Fail(string error)
            => new() { Success = false, Errors = [error] };
    }
}
