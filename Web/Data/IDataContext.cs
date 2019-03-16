using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetWorth.Web.Models;

namespace NetWorth.Web.Data
{
    public interface IDataContext
    {
        IQueryable<Country> Counties { get; }
        IQueryable<User> Users { get; }
        IQueryable<RosterItem> RosterItems { get; }
    }
}
