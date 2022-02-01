using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace App.gamez
{
    public class search
    {
        public class Query : IRequest<games>
        {
            public Guid Id {get;set;}
        }
        public class Handler : IRequestHandler<Query, games>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }
            
            public async Task<games> Handle(Query request, CancellationToken cancellationToken)
            {
                var joc = await _context.Games.FindAsync(request.Id);
                return joc;
            }
        }
        
    }
}