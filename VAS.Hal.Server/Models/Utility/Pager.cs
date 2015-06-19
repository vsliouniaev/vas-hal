using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebApi.Hal.Interfaces;

namespace VAS.Hal.Server.Models.Utility
{
    public class Pager<T>
        where T : IResource
    {
        private readonly Func<IEnumerable<T>> _getter;
        private readonly Func<int> _counter;
        private readonly string _href;

        private const int DefaultPageSize = 10;
        private const int MaxPageSize = 500;

        public Pager(Func<IEnumerable<T>> getter, Func<int> counter, string href)
        {
            _counter = counter;
            _href = href;
            _getter = getter;
        }

        public PagedList<T> GetPage(Page page)
        {
            var pageNumber = 0;
            var pageSize = DefaultPageSize;

            if (page != null)
            {
                pageNumber = Math.Max(page.PageNumber, pageNumber);
                pageSize = Math.Min(page.PageSize, MaxPageSize);
                pageSize = pageSize <= 0 ? DefaultPageSize : pageSize;
            }

            var totalRecords = _counter();
            var totalPages = totalRecords / pageSize;
            if (totalRecords % pageSize > 0)
                totalPages += 1;

            var items =
                totalRecords == 0 || pageNumber > totalPages
                    ? Enumerable.Empty<T>()
                    : _getter().Skip(pageNumber * pageSize).Take(pageSize);
            return new PagedList<T>(pageNumber, pageSize, totalPages, items, _href, totalRecords);
        }
    }
}