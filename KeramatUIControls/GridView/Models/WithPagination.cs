using System.Dynamic;

namespace KeramatUIControls.GridView.Models {
    public class WithPagination {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public List<DynamicObject>? Items { get; set; }
    }
}
