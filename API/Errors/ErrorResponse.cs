using System.Collections.Generic;

namespace API.Errors
{
    public class ErrorResponse
    {
        
        public List<ApiExceptions> Errors { get; set; }
    }
}