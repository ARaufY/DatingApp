using System.Collections.Generic;

namespace API.Errors
{
    public class ErrorResp
    {
        public string Code { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}