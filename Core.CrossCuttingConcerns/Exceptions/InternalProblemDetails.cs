﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class InternalProblemDetails : ProblemDetails
    {
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
