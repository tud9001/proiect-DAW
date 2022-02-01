using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using api.autorizare;
using Domain;
using api.Helpers;
using api.Models.Users;
using Persistance;
using System;

namespace api.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<user> GetAll();
        user GetById(Guid id);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var userboi = _context.User.SingleOrDefault(x => x.Name == model.Name);

            // validate
            if (userboi == null || !BCryptNet.Verify(model.Password, userboi.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(userboi);

            return new AuthenticateResponse(userboi, jwtToken);
        }

        public IEnumerable<user> GetAll()
        {
            return _context.User;
        }

        public user GetById(Guid id) 
        {
            var user = _context.User.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}