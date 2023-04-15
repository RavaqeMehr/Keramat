using Common;
using Microsoft.Extensions.DependencyInjection;

namespace Keramat.Utilities {
    public interface IFormManager : ISingletonDependency {
        T Create<T>() where T : Form;
    }

    public class FormManager : IFormManager {
        private readonly IServiceProvider serviceProvider;

        public FormManager(
            IServiceProvider serviceProvider
            ) {
            this.serviceProvider = serviceProvider;
        }

        public T Create<T>() where T : Form {
            var form = serviceProvider.GetRequiredService<T>();
            return form;
        }
    }
}
