using Microsoft.EntityFrameworkCore;
using RepositoryUtil;

namespace AuthRepository.Context;
public interface IAuthRepository<T> : IRepository<T> where T : class, TEntity
{
}
