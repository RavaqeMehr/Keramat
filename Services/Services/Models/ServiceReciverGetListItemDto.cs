﻿namespace Services.Services.Models {
    public class ServiceReciverGetListItemDto {
        public int Id { get; set; }
        public int FamilyId { get; set; }
        public string FamilyTitle { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
