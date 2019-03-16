using System.Collections.Generic;
using System.Linq;
using NetWorth.Web.Models;

namespace NetWorth.Web.Data
{
    public class DataContext: IDataContext
    {
        private List<Country> _countries;
        private List<User> _users;
        private List<RosterItem> _rosterItems;

        public DataContext(List<Country> countries, List<User> users, List<RosterItem> rosterItems)
        {
            _countries = countries;
            _users = users;
            _rosterItems = rosterItems;
        }

        public IQueryable<Country> Counties
        {
            get
            {
                return _countries.AsQueryable();
            }
        }

        public IQueryable<User> Users
        {
            get
            {
                return _users.AsQueryable();
            }
        }

        public IQueryable<RosterItem> RosterItems
        {
            get
            {
                return _rosterItems.AsQueryable();
            }
        }
    }
}
