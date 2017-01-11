using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokenDateTimeOffsetMapping
{
    public class FooContext : DbContext
    {
        public FooContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Foo> Foos { get; set; }
    }

    [Table("Foos")]
    public class Foo
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset MyDate { get; set; }
    }
}
