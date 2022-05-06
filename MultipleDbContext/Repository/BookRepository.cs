using Microsoft.EntityFrameworkCore;
using MultipleDbContext.Data;
using MultipleDbContext.Models;

namespace MultipleDbContext.Repository
{
    public class BookRepository : IBookRepository
    {
        DbContextFactory _contexts;

        public BookRepository(DbContextFactory contexts)
        {
            _contexts = contexts;
        }
        public void Add(Book entity, string contextName)
        {
            var context = _contexts.GetContext(contextName);
            var addedEntity = context.Attach(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(Book entity, string contextName)
        {
            var context = _contexts.GetContext(contextName);
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Book> Get(string contextName)
        {
            var context = _contexts.GetContext(contextName);
            return context.Books.ToList();
        }
    }
}
