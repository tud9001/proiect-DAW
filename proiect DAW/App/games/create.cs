using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace App.games
{
    public class create
    {
        public class Command : IRequest
        {
            public Guid Id{get; set;}
            public string Name{get; set; }

            public string Tip{get;set;}
            public float Balance{get;set;}
            public string Parola{get; set;}
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
                var usernou=new user(request.Parola){
                    Id=request.Id,
                    Name=request.Name,
                    Tip=request.Tip,
                    Balance=request.Balance
                    
                };
                _context.User.Add(usernou);
                var success = await _context.SaveChangesAsync() > 0;
                
                if(success)return Unit.Value;
                throw new Exception("Changes could not go through");
            }
        }
    }
}