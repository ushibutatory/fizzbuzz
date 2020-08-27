namespace NabeAtsu.Web.Models.Abstracts
{
    public interface ILayoutViewModel
    {
        AppSettings AppSettings { get; set; }

        string Title { get; set; }
    }
}
