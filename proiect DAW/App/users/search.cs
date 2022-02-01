using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace App.users
{
    public class search
    {
        public class Query : IRequest<user>
        {
            public Guid Id {get;set;}
        }
        public class Handler : IRequestHandler<Query, user>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }
            
            public async Task<user> Handle(Query request, CancellationToken cancellationToken)
            {
                var userboi = await _context.User.FindAsync(request.Id);
                return userboi;
            }
        }
        
    }
}