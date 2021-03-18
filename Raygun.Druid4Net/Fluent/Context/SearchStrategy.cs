namespace Raygun.Druid4Net
{
	public enum SearchStrategy
	{
		/// <summary>
		/// First categorizes search dimensions into two groups according to their support for bitmap indexes. And then, it applies index-only and cursor-based execution plans to the group of dimensions supporting bitmaps and others, respectively
		/// </summary>
		useIndexes,
		
		/// <summary>
		/// Generates a cursor-based execution plan. This plan creates a cursor which reads a row from a queryableIndexSegment, and then evaluates search predicates. If some filters support bitmap indexes, the cursor can read only the rows which satisfy those filters, thereby saving I/O cost
		/// </summary>
		cursorOnly,
		
		/// <summary>
		/// Uses a cost-based planner for choosing an optimal search strategy. It estimates the cost of index-only and cursor-based execution plans, and chooses the optimal one.
		/// </summary>
		auto
	}
}
