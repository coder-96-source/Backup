using System.Threading.Tasks;

namespace DotNetSurfer.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ITopicRepository TopicRepository { get; }
        IArticleRepository ArticleRepository { get; }
        IAnnouncementRepository AnnouncementRepository { get; }
        IUserRepository UserRepository { get; }
        IFeatureRepository FeatureRepository { get; }
        IStatusRepository StatusRepository { get; }

        Task<int> SaveAllChangesAsync();
    }
}
