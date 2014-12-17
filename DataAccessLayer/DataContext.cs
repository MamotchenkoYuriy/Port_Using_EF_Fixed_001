﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer.Mapping;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("Data Source=YURIY-PC;Initial Catalog=TestConn;Integrated Security=True")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Cargo> Carges { get; set; }
        public DbSet<CargoType> CargoTypes { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PortMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new TripMap());
            modelBuilder.Configurations.Add(new CargoTypeMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new ShipMap());
            modelBuilder.Configurations.Add(new CaptainMap());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
