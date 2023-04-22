﻿using Microsoft.EntityFrameworkCore;

namespace Services.ComonModels {
    public class WithPagination<TList> {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public List<TList>? Items { get; set; }

        //public WithPagination() { }
        //public WithPagination(IQueryable<object> listAllQueryable, int page, int itemsPerPage = 100) {
        //    async void asyncer() {
        //        this.ItemsPerPage = itemsPerPage;
        //        this.TotalItems = await listAllQueryable.CountAsync();
        //        this.CurrentPage = page;
        //        this.TotalPages = (int)Math.Ceiling(this.TotalItems / (decimal)this.ItemsPerPage);
        //    }

        //    asyncer();
        //}

        public async Task Fill(IQueryable<object> listAllQueryable, int page, int itemsPerPage = 100) {
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = await listAllQueryable.CountAsync();
            this.CurrentPage = page;
            this.TotalPages = (int)Math.Ceiling(this.TotalItems / (decimal)this.ItemsPerPage);
        }
    }
}
