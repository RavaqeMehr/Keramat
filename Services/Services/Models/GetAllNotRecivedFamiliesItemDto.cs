namespace Services.Services.Models {
    public class GetAllNotRecivedFamiliesItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MembersCount { get; set; }
        public bool Serviced { get; set; }
    }
}
