using System.Collections.Generic;

namespace BlogApplication.Helpers
{
    public class Paging<T> where T : class
    {
        public Paging(int pageIndex, int pageSize, int count, IReadOnlyList<T> blogList)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            BlogList = blogList;
        }

        
        public int PageIndex { get; set; }
        
        public int PageSize { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> BlogList { get; set; }
    }
}