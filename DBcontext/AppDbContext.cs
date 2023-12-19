using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GokstadHageVenner.Models.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { 
    
    }




    public DbSet<Medlem> Medlemmer { get; set; }
    public DbSet<Arrangement> Arrangementer { get; set; }
    public DbSet<Påmelding> Påmeldinger { get; set; }
    public DbSet<KjopOgSalg> kjopOgSalg { get; set; }

   // protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{ 

    //}
    

    
}
