using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace App.users
{
    public class create
    {
        public class Command : IRequest
        {
            public Guid Id{get; set;}
            public string Name{get; set; }

            public string Tip{get;set;}
            public float Balance{get;set;}
            public int Idlogin{get; set;}
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var usernou=new user{
                    Id=request.Id,
                    Name=request.Name,
                    Tip=request.Tip,
                    Balance=request.Balance,
                    Idlogin=request.Idlogin
                };
                
            }
        }
    }
}