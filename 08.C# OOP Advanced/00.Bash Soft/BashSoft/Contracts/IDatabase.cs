namespace BashSoft.Contracts
{
    public interface IDatabase : IFilteredTaker, IOrderedTaker, IRequester
    {
        void LoadData(string fileName);

        void UnloadData();
    }
}