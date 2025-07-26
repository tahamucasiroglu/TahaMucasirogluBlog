namespace TahaMucasiroglu.Client.MVC.Managers.UrlManager
{
    public interface IUrlManager
    {
        public string BaseUrl { get; }

        public string CheckLastSlash(string url);

        public string Build(string controller, string action, string route);
        public string Build(string controller, string action);
        public string Build(string endpoint);




    }
}
