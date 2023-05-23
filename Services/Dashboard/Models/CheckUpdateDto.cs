namespace Services.Dashboard.Models {
    public class CheckUpdateDto {
        public string CurrentVersion { get; set; }
        public string LatestVersion { get; set; }
        public bool NeedUpdate { get; set; }
        public DateTime LatestVersionPublishDate { get; set; }
        public string ReleaseUrl { get; set; }
    }
}
