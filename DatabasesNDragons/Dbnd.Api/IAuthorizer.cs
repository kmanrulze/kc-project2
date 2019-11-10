using Dbnd.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dbnd.Api
{
    public interface IAuthorizer
    {
        Task<UserProfile> GetUserProfile(string bearerString);

        Task<bool> Authorized(IRepository context, string bearerString, string requesterId);
    }
}
