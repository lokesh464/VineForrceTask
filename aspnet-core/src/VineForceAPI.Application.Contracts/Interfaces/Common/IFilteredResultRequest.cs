namespace VineForceAPI.Interfaces.Common
{
    public interface IFilteredResultRequest
    {
        /// <summary>
        /// Filter information.
        /// Must include the value used to filter by.
        /// </summary>
        public string Filter { get; set; }
    }
}
