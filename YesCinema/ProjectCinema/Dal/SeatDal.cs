using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjectCinema.Models;
using ProjectCinema.Dal;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjectCinema.Dal
{
    public class SeatDal : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Seat>().ToTable("tblSeat");
        }

        public DbSet<Seat> Seats { get; set; }

    }
}