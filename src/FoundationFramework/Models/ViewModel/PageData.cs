using System.Linq;

namespace FoundationFramework.Models.ViewModel
{
    public class PageData<T>
    {
        public PagingInfo PagingInfo { get; set; }

        public IQueryable<T> PagingData { get; set; }
    }
}
