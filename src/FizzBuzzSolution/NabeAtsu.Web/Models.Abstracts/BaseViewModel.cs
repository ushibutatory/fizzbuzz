namespace NabeAtsu.Web.Models.Abstracts
{
    public abstract class BaseViewModel : ILayoutViewModel
    {
        public AppSettings AppSettings { get; set; }

        public string Title { get; set; }
    }
}
