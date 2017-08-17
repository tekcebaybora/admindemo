using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace AdminPseudoscops.Models.UserModel
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
                : base("name=DefaultConnection")
        {

        }



        #region[ DbSets ]
        public virtual DbSet<User> Users { get; set; }
        #endregion

        #region[Mapping]
        #endregion
    }
}

