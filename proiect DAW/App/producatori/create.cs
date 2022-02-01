using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace App.producatori
{
    public class create
    {
        public class Command : IRequest
        {
            public int Id{get; set;}
            public string Name{get; set; }
            
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
                var prodnou=new producator{
                    Id=request.Id,
                    Name=request.Name
                };
                _context.Producator.Add(prodnou);
                var success = await _context.SaveChangesAsync() > 0;
                
                if(success)return Unit.Value;
                throw new Exception("Changes could not go through");
            }
        }
    }
}