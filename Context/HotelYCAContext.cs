using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using practicaV1.Models;

namespace practicaV1.Context
{
    public partial class HotelYCAContext : DbContext
    {
        public HotelYCAContext ()
        {
        }
        public  HotelYCAContext (DbContextOptions<HotelYCAContext> options)
            : base (options)
        {
        }
        public DbSet<cAlquiler> tAlquiler { get; set; }
        public DbSet<cCliente> tCliente { get; set; }
        public DbSet<cEstado> tEstado { get; set; }
        public DbSet<cHabitacion> tHabitacion { get; set; }
        public DbSet < cNacionalidad>  tNacionalidad { get; set; }
        public DbSet<cRegistrador> tRegistrador { get; set; }
        public DbSet<cTipoHabitacion> tTipoHabitacion { get; set; }

    }
}
