using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Concrete.Main;
using TahaMucasiroglu.Infrastructure.Repository.Context;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.Repository.Repository.Concrete
{
    public class SocialLinkRepository : Repository<SocialLink>, ISocialLinkRepository
    {
        public SocialLinkRepository(MainTahaMucasirogluContext context, ILogger<SocialLinkRepository> logger) : base(context, logger)
        {
        }
    }
}
