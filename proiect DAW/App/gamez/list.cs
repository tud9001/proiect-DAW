using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace App.gamez
{
    public class list
    {
        public class Query : IRequest<List<games>> {}
        public class Handler : IRequestHandler<Query, List<games>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }

            public async Task<List<games>> Handle(Query request, 
            CancellationToken cancellationToken)
            {
                var jocuri= await _context.Games.ToListAsync();
                return jocuri;
            }
        }
    }
}