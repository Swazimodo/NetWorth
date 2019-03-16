using System.Linq;
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
