using System.Text.Json.Serialization;

namespace Aira.Core.Repository
{
    public class RequestContext
    {
        //[JsonIgnore]
        //public Guid? UserId { get; } = string.IsNullOrEmpty(HttpManager.GetHeaderValue("UserId")) ?
        //    null : Guid.Parse(HttpManager.GetHeaderValue("UserId"));
    }
}
