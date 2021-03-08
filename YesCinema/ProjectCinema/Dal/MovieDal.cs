﻿using System;
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
    public class MovieDal : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("tblMovie");
        }

        public DbSet<Movie> MOVIES { get; set; }

    }
}