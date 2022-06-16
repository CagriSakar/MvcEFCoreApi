using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Data
{
    public class GenericRepository<T> where T : class
    {
        //private readonly AppDbContext _context; //context i constructor dan direk olarak kullanabiliriz buna gerek kalmadı.

        private readonly DbSet<T> _dbset;

        public GenericRepository(AppDbContext context)
        {
            //_context = context;
            _dbset = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbset.AddAsync(entity);
            //context.SaveChange(); //generic rep. de savechanges çağırılmaz. Productservice e bak.
        }
        
    }
}
