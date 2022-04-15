using Microsoft.EntityFrameworkCore;
using MultipleDbContext.Data;
using MultipleDbContext.Models;

namespace MultipleDbContext.Repository
{
    public class BookRepository : IBookRepository
    {
        ICollection<BaseContext> _contexts;

        public BookRepository(ICollection<BaseContext> contexts)
        {
            _contexts = contexts;
        }

        private BaseContext GetContext(string contextName)
        {
            BaseContext context = null;

            switch (contextName)
            {
                case "DbOneContext":
                    context = _contexts.FirstOrDefault(x => x is DbOneContext) as DbOneContext;
                    break;
                case "DbTwoContext":
                    context = _contexts.FirstOrDefault(x => x is DbTwoContext) as DbTwoContext;
                    break;
            }

            return context;
        }

        public void Add(Book entity, string contextName)
        {
            var context = GetContext(contextName);
            var addedEntity = context.Attach(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(Book entity, string contextName)
        {
            var context = GetContext(contextName);
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Book> Get(string contextName)
        {
            var context = GetContext(contextName);
            return context.Books.ToList();
        }
    }
}
