using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace App.producatori
{
    public class list
    {
        public class Query : IRequest<List<producator>> {}
        public class Handler : IRequestHandler<Query, List<producator>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }

            public async Task<List<producator>> Handle(Query request, 
            CancellationToken cancellationToken)
            {
                var prods= await _context.Producator.ToListAsync();
                return prods;
            }
        }
    }
}