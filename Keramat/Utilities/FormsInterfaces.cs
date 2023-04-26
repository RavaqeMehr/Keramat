namespace Keramat.Utilities {
    public interface ISavableForm {
        bool HasChanges { get; set; }
        Task SaveChanges();
        Task CloseAfterUserSubmit();
    }
}
