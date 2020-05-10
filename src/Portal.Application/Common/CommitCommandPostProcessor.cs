using MediatR;
using MediatR.Pipeline;
using Portal.Persisatance;
using Portal.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.Common
{
    public class CommitCommandPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly PortalDbContext _db;

        public CommitCommandPostProcessor(PortalDbContext db)
        {
            _db = db;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            if (request is ICommittableRequest)
            {
                await _db.SaveChangesAsync();
            }
            //return await next();
            
        }
    }
}
