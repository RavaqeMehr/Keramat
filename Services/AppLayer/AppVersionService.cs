using Common;
using System.Reflection;

namespace Services.AppLayer {
    public interface IAppVersionService : ISingletonDependency {
        Version Version();
        int VersionNumber();
        string VersionString();
    }

    public class AppVersionService : IAppVersionService {
        public Version _Version { get; set; }
        public AppVersionService() {
            //_Version = Assembly.GetEntryAssembly().GetName().Version;
            var ver = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            _Version = new Version(ver);
        }

        public Version Version() {
            return _Version;
        }

        public int VersionNumber() {
            return _Version.Minor + (_Version.Major * 100);
        }

        public string VersionString() {
            return _Version.ToString();
        }
    }
}
