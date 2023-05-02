namespace Services.ValiNematan.Models {
    public class GetFamilyByIdDto {
        public string Title { get; set; } = "";
        public string Address { get; set; } = "";
        public int LevelId { get; set; } = 1;
        public string Description { get; set; } = "";

        public string ContactPersonName { get; set; } = "";
        public string ContactPersonPhone { get; set; } = "";
        public string ContactPersonDescription { get; set; } = "";

        public int? ConnectorId { get; set; }
        public bool Finished { get; set; } = false;
    }
}
