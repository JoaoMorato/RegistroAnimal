using Microsoft.EntityFrameworkCore.Metadata;
using RepositoryUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.DI;

namespace AuthRepository.Context;
public class AuthRepository<T> : Repository<AuthContext, T>, IAuthRepository<T> 
    where T : class, TEntity
{
    public AuthRepository(AuthContext db) : base(db)
    {
    }
}
