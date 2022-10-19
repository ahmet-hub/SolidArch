using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public IEnumerable<string> Errors { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
