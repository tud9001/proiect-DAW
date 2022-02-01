using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance;
using Domain;

namespace App.users
{
    public class edit
    {
        public class Command : IRequest
        {
            public Guid Id{get; set;}
            public string Name{get; set; }

            public string Tip{get;set;}
            public float? Balance{get;set;}
            public int? Idlogin{get; set;}
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
                if(userboi==null)
                    throw new Exception("Nu am gasit id-ul");

                userboi.Name=request.Name ?? userboi.Name;
                userboi.Tip=request.Tip ?? userboi.Tip;
                userboi.Balance=request.Balance ?? userboi.Balance;
                userboi.Idlogin=request.Idlogin ?? userboi.Idlogin;

                var success = await _context.SaveChangesAsync()>0;
                if(success)return Unit.Value;

                throw new Exception("Problema la salvare");
            }
        }
    }
}