namespace Clean.Common.Specifications
{
    public interface IPaging
    {
        /// <summary>
        /// Number of items to take (i.e. page size)
        /// </summary>
        int Take { get; }

        /// <summary>
        /// Number of items to skip. This is typically PageNumber * PageSize.
        /// </summary>
        int Skip { get; }
    }
}