﻿namespace Core.Specifications
{
    public class BlogSpecificationParameters
    {
        //Filter the data
        public int? AuthorId { get; set; }

        public int? CategoryId { get; set; }
        
        public int? TagId { get; set; }
        
        //Search
        private string _search { get; set; }
        
        public string Search
        {
            get => _search; 
            set => _search = value.ToLower();
        }
        
        //Order by name or date
        public string Sort { get; set; }
        
        //Paging Settings
        public const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 3;

        public int PageSize
        {
            get => _pageSize; 
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}