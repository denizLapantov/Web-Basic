using SoftUniStore.Data.Contracts;

namespace SoftUniStore.Service
{
    public class BaseService
    {
        protected ISoftUniStoreData data;

        public BaseService(ISoftUniStoreData data)
        {
            this.data = data;
        }
    }
}
