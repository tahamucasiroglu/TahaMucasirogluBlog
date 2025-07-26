using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Context;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Base
{
    public class P2PMessageRepository<TEntity> : Repository<TEntity>, IP2PMessageRepository<TEntity>
        where TEntity : class, IP2PMessageEntity
    {
        public P2PMessageRepository(P2PMessageTahaMucasirogluContext context, ILogger<Repository<TEntity>> logger) : base(context, logger)
        {
        }
    }
}
