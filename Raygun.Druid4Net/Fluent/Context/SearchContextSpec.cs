namespace Raygun.Druid4Net
{
	public class SearchContextSpec : ContextSpec
	{
		/// <summary>
		/// The search strategy that wil be used when performing Search Queries.
		/// </summary>
		public SearchStrategy? SearchStrategy { get; set; }
	}
}
