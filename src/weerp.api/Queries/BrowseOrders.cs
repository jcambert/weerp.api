using System;

namespace weerp.api.Queries
{
    public class BrowseOrders : PagedQuery
    {
        public Guid CustomerId { get; set; }
    }
}
