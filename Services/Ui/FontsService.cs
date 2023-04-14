﻿using Common;
using Entities.AppSettings;
using Services.AppLayer;
using Services.Ui.Models;
using System.Drawing;
using System.Drawing.Text;

namespace Services.Ui {
    public interface IFontsService : ISingletonDependency {
        Task<GetFontDto> Get();
    }

    public class FontsService : IFontsService {
        private readonly IAppSettingsService appSettingsService;

        public FontsService(
            IAppSettingsService appSettingsService
            ) {
            this.appSettingsService = appSettingsService;
        }

        private PrivateFontCollection? _collection { get; set; }
        private GetFontDto? _dto { get; set; }
        public async Task<GetFontDto> Get() {
#pragma warning disable CA1416 // Validate platform compatibility // Just in windows
            if (_dto is null) {
                if (_collection is null) {
                    _collection = new PrivateFontCollection();
                    var fontFiles = Directory.GetFiles("assets/fonts/");
                    foreach (var item in fontFiles) {
                        _collection.AddFontFile(item);
                    }
                }

                var defaultFontFamilyName = await appSettingsService.Get(AppSettingsKeys.Ui_Fonts_Defaults_Family);
                var DefaultFontFamily = _collection.Families.First(x => x.Name == defaultFontFamilyName) ?? _collection.Families.First();
                var DefaultFontSize = float.Parse(await appSettingsService.Get(AppSettingsKeys.Ui_Fonts_Defaults_Size));
                _dto = new GetFontDto {
                    Collection = _collection,
                    DefaultFont = new Font(DefaultFontFamily, DefaultFontSize),
                    DefaultFontFamily = DefaultFontFamily,
                    DefaultFontSize = DefaultFontSize
                };
            }

            return _dto;
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}