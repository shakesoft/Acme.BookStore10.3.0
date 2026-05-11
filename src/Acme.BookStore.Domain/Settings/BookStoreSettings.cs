namespace Acme.BookStore.Settings;

public static class BookStoreSettings
{
    private const string Prefix = "BookStore";

    //Add your own setting names here. Example:
    //public const string MySetting1 = Prefix + ".MySetting1";

    public const string SmtpHost = Prefix + ".SmtpHost";
    public const string MaxBooksCount = Prefix + ".MaxBooksCount";
    public const string MaxUploadSizeMb = Prefix + ".MaxUploadSizeMb";
    public const string MaxAuthorsCount = Prefix + ".MaxAuthorsCount";

}
