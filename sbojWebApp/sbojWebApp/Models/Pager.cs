namespace sbojWebApp.Models
{
    public class Pager
    {
        private const int ShowPages = 7;
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int StartItemsShowing { get; set; }
        public int EndItemsShowing { get; set; }

        public Pager()
        {
            
        }

        public Pager(int startItemsShowing, int endItemsShowing, int totalItems, int page, int pageSize)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - ShowPages / 2;
            int endPage = startPage + ShowPages - 1;

            if (startPage < 1)
            {
                endPage = endPage - startPage + 1;
                startPage = 1;
            }

            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > ShowPages)
                {
                    startPage = endPage - ShowPages + 1;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            StartItemsShowing = startItemsShowing;
            EndItemsShowing = Math.Min(endItemsShowing, TotalItems);
        }
    }
}
