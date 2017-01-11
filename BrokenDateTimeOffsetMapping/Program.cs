using AutoMapper;
using AutoMapper.QueryableExtensions;
using BrokenDateTimeOffsetMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var db = CreateDbContext();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Foo, FooModel>();
        });

        // fails on this next line when automapper tries to stuff the DateTimeOffset value for 
        // Foo.MyDate into the string property in FooModel.MyDate

        var model = db.Foos.ProjectTo<FooModel>(config).First();
    }
    /// <summary>
    /// Setup the inmemory context
    /// </summary>
    static FooContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder();

        optionsBuilder.UseInMemoryDatabase();

        var db = new FooContext(optionsBuilder.Options);

        db.Foos.Add(new Foo { MyDate = DateTimeOffset.Now });

        db.SaveChanges();

        return db;
    }
}