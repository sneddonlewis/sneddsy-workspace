using SneddsyWorkspace.Apps.KratoApi.KratoApiIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiIdentity.Models;

public class KratoIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public KratoIdentityDbContext() {}

    public KratoIdentityDbContext(DbContextOptions<KratoIdentityDbContext> options) : base(options) {}
}