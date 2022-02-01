using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace App.producatori
{
    public class search
    {
        public class Query : IRequest<producator>
        {
            public Guid Id {get;set;}
        }
        public class Handler : IRequestHandler<Query, producator>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }
            
            public async Task<producator> Handle(Query request, CancellationToken cancellationToken)
            {
                var prod = await _context.Producator.FindAsync(request.Id);
                return prod;
            }
        }
        
    }
}