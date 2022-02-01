using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace App.gamez
{
    public class create
    {
        public class Command : IRequest
        {
            public Guid Id{get; set;}
            public string Name{get; set; }

            public float Cost{get;set;}
            public int Idprod{get;set;}
            
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
                var jocnou=new games{
                    Id=request.Id,
                    Name=request.Name,
                    Cost=request.Cost,
                    Idprod=request.Idprod
                    
                };
                _context.Games.Add(jocnou);
                var success = await _context.SaveChangesAsync() > 0;
                
                if(success)return Unit.Value;
                throw new Exception("Changes could not go through");
            }
        }
    }
}