﻿using FinalProject.DAL.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.DAL.EF;
using FinalProject.DAL.Interfaces;

namespace FinalProject.DAL.Repositories
{
    class DiveMeasurementRepository : IRepository<DiveMeasurement>
    {
        private readonly NixDatabaseContext db;
        public DiveMeasurementRepository(NixDatabaseContext context)
        {
            this.db = context;
        }
        public IEnumerable<DiveMeasurement> GetAll()
        {
            return db.DiveMeasurements;
        }

        public DiveMeasurement Get(int id)
        {
            return db.DiveMeasurements.Find(id);
        }

        public void Create(DiveMeasurement item)
        {
            db.DiveMeasurements.Add(item);
        }

        public void Update(DiveMeasurement item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<DiveMeasurement> Find(Func<DiveMeasurement, Boolean> predicate)
        {
            return db.DiveMeasurements.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            DiveMeasurement diveMeasurement = db.DiveMeasurements.Find(id);
            if (diveMeasurement != null)
                db.DiveMeasurements.Remove(diveMeasurement);
        }
    }
}
