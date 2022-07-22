using Adminservices.Models;
using Adminservices.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adminservices.Services
{
    public class JwtManagerRepository : IJwtManagerRepository
    {
        Dictionary<string, string> userRecords;

        private readonly IConfiguration configuration;

        private readonly FlightDBContext admindb;

        public JwtManagerRepository(IConfiguration _configuration, FlightDBContext _admindbdb)
        {
            configuration = _configuration;
            admindb = _admindbdb;
        }
        public Tokens Authenticate(AdminLoginViewModel users, bool IsRegister)
        {
            if (IsRegister)
            {
                if (admindb.AdminTbs.Any(x => x.UserName == users.UserName))
                {
                    return null;
                }

                AdminTb adminTb = new AdminTb();
                adminTb.UserName = users.UserName;
                adminTb.Password = users.Password;
                admindb.AdminTbs.Add(adminTb);
                admindb.SaveChanges();
            }
            userRecords = admindb.AdminTbs.ToList().ToDictionary(x => x.UserName, x => x.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (!userRecords.Any(x => x.Key == users.UserName && x.Value == users.Password))
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

        //public Tokens Authenticate(AdminLoginViewModel admin, bool IsRegister)
        //{
        //    throw new NotImplementedException();
        //}

        public List<AdminTb> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
