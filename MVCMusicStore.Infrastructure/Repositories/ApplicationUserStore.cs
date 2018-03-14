using Microsoft.AspNet.Identity.EntityFramework;
using MVCMusicStore.Core.Models;
using MVCMusicStore.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Repositories
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(MVCMusicStoreDBContext context)
            : base(context)
        {
        }
    }

}
