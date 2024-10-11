namespace sbojWebApp.Models
{
	public class Sorter
	{
        public string SortingParameter { get; set; }

		public Sorter()
		{

		}

		public Sorter(string sortingParameter)
		{
			SortingParameter = sortingParameter;
		}
    }
}
