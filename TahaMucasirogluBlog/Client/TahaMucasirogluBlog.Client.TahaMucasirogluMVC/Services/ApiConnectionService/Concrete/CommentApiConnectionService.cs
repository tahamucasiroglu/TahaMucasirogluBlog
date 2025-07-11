using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Base;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Concrete
{
    public class CommentApiConnectionService : Base.ApiConnectionService, ICommentApiConnectionService
    {
        public CommentApiConnectionService(IUrlManager urlManager, HttpClient httpClient, ILogger<CommentApiConnectionService> logger) : base("Comment", urlManager, httpClient, logger)
        {
        }
    }
}
