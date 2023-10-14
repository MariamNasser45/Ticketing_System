﻿using Ticketing_System.Data;
using Ticketing_System.Models;

namespace Ticketing_System.Interfaces.Implemintation
{
    public class StatusImp : IStatus
    {
        private readonly ApplicationDbContext Context;
        public StatusImp(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<Status> GetAll()
        {
            return Context.Statuses.Where(s=>s.StatusName!="New").ToList();
        }

        public List<Status> GetAllForMan()
        {
            return Context.Statuses.Where(s => s.StatusName == "New" || s.StatusName== "Assigned").ToList();
        }
    }
}
