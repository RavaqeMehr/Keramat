namespace Services.ValiNematan.Models {
    public class GetFamiliesListQuery {
        public string? Search { get; set; }
        public int? Page { get; set; } = 1;
    }
}
