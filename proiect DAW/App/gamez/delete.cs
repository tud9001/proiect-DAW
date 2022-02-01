using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance;

namespace App.gamez
{
    public class delete
    {
        public class Command : IRequest
        {
            public Guid Id {get; set;}
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
                var joc = await _context.Games.FindAsync(request.Id);

                if(joc == null)
                    throw new Exception("Nu am gasit id de sters");

                _context.Remove(joc);

                var success = await _context.SaveChangesAsync()>0;
                
                if(success)return Unit.Value;

                throw new Exception("Problema la salvare");
            }
        }
    }
}