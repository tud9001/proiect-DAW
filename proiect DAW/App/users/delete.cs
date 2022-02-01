using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance;

namespace App.users
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
                var userboi = await _context.User.FindAsync(request.Id);

                if(userboi == null)
                    throw new Exception("Nu am gasit id de sters");

                _context.Remove(userboi);

                var success = await _context.SaveChangesAsync()>0;
                
                if(success)return Unit.Value;

                throw new Exception("Problema la salvare");
            }
        }
    }
}