using System.Collections.Generic;

namespace Domain.Responses
{
    public class AuthenticationFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}