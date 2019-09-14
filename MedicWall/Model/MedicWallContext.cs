using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicWall.Model
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Client { get; set; }

        public ClientContext(DbContextOptions<ClientContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client
            {
                name = "Bob",
                cellPhone = 48991028830,
                email = "Drama",


            }, new Client
            {
                AuthorId = Guid.NewGuid(),
                FirstName = "David",
                LastName = "Miller",
                Genre = "Fantasy"
            });
        }
    }
}
