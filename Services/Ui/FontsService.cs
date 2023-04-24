#pragma warning disable CA1416 // Validate platform compatibility // Just in windows

using Common;
using Common.Utilities;
using Entities.AppSettings;
using Services.AppLayer;
using Services.Ui.Models;
using System.Drawing;
using System.Drawing.Text;

namespace Services.Ui {
    public interface IFontsService : ISingletonDependency {
        GetFontDto? Get();
        Task Load();

        Font FontByRatio(double ratio);
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

        public async Task Load() {
            await appSettingsService.Load();

            _collection = new PrivateFontCollection();
            var fontFiles = Directory.GetFiles("assets/fonts/");
            foreach (var item in fontFiles) {
                _collection.AddFontFile(item);
            }

            var defaultFontFamilyName = appSettingsService.Get(AppSettingsKeys.Ui_Fonts_Defaults_Family) ?? "Tahoma";
            var DefaultFontFamily = _collection.Families.First(x => x.Name == defaultFontFamilyName) ?? _collection.Families.First();
            var DefaultFontSize = float.Parse(appSettingsService.Get(AppSettingsKeys.Ui_Fonts_Defaults_Size) ?? "14");
            _dto = new GetFontDto {
                Collection = _collection,
                DefaultFont = new Font(DefaultFontFamily, DefaultFontSize),
                DefaultFontFamily = DefaultFontFamily,
                DefaultFontSize = DefaultFontSize
            };
        }
        public GetFontDto? Get() {
            return _dto;
        }

        public Font FontByRatio(double ratio) {
            return _dto.DefaultFont.ByRatio(ratio);
        }
    }
}

#pragma warning restore CA1416 // Validate platform compatibility