using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace App.users
{
    public class list
    {
        public class Query : IRequest<List<user>> {}
        public class Handler : IRequestHandler<Query, List<user>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }

            public async Task<List<user>> Handle(Query request, 
            CancellationToken cancellationToken)
            {
                var users= await _context.User.ToListAsync();
                return users;
            }
        }
    }
}