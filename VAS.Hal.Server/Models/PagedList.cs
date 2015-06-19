using System.Collections.Generic;
using System.Linq;
using WebApi.Hal;
using WebApi.Hal.Interfaces;

namespace VAS.Hal.Server.Models
{
    public class PagedList<T> : SimpleListRepresentation<T>
        where T : IResource
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int KnownPagesAvailable { get; private set; }
        public int TotalItemsCount { get; private set; }

        public override sealed string Href { get; set; }

        public PagedList(int pageNumber, int pageSize, int knownPagesAvailable, IEnumerable<T> items, string href, int totalItemsCount = 0)
            : base(items.ToList())
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            KnownPagesAvailable = knownPagesAvailable;
            TotalItemsCount = totalItemsCount;
            Href = string.Format("{0}{3}pageNumber={1}&pageSize={2}", href, pageNumber, pageSize, href.Contains('?') ? "&" : "?");
        }

        protected override void CreateHypermedia()
        {

        }
    }
}