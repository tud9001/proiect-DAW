using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace App.producatori
{
    public class edit
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
                var prod = await _context.Producator.FindAsync(request.Id);
                if(prod==null)
                    throw new Exception("Nu am gasit id-ul");

                prod.Name=request.Name ?? prod.Name;

                var success = await _context.SaveChangesAsync()>0;
                if(success)return Unit.Value;

                throw new Exception("Problema la salvare");
            }
        }
    }
}