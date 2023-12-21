using Microsoft.EntityFrameworkCore;

namespace crudMongo.DataBase
{
    public class Repository(Context context)
    {
        public async Task<T> Save<T>(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
		}

        public async Task Update<T>(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get<T>(Func<T, bool> predicate) where T : class
        {
			return await Task.FromResult(context.Set<T>().Where(predicate).ToList());
        }

		public async Task<T> GetFirst<T>(Func<T, bool> predicate) where T : class
		{
			return await Task.FromResult(context.Set<T>().Where(predicate).AsQueryable().FirstOrDefault());
		}

		public async Task<IEnumerable<T>> Get<T>() where T : class
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
