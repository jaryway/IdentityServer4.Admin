using System.Threading.Tasks;
using Jaryway.IdentityServer.Events;
using Jaryway.IdentityServer.Services;
using Microsoft.Extensions.Logging;

namespace Skoruba.IdentityServer4.STS.Identity.Services
{
    public class AuditEventSink : DefaultEventSink
    {
        public AuditEventSink(ILogger<DefaultEventService> logger) : base(logger)
        {
        }

        public override Task PersistAsync(Event evt)
        {
            return base.PersistAsync(evt);
        }
    }
}