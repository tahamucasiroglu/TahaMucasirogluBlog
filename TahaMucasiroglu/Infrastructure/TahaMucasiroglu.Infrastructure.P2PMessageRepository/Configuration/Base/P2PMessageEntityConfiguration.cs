using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.P2PMessageRepository.Configuration.Base
{
    public class P2PMessageEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : class, IP2PMessageEntity
    {
    }
}
