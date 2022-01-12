using MySQL.Identity;
using MySQL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace MySQL.API.IntegrationTests.Base
{
    public class DbFixture : IDisposable
    {
        private readonly  ApplicationDbContext _applicationDbContext;
        private readonly IdentityDbContext _identityDbContext;
        public readonly string ApplicationDbName = $"Application-{Guid.NewGuid()}";
        public readonly string IdentityDbName = $"Identity-{Guid.NewGuid()}";
        public readonly string HealthCheckDbName = $"HealthCheck";
        public readonly string HealthCheckConnString;
        public readonly string ApplicationConnString;
        public readonly string IdentityConnString;

        private bool _disposed;

        public DbFixture()
        {
            var applicationBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var identityBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            ApplicationConnString = $"Server=localhost;Port=3309;Database={ApplicationDbName};Userid=root;Password=root;";
                    IdentityConnString = $"Server=localhost;Port=3309;Database={IdentityDbName};Userid=root;Password=root;";
                    HealthCheckConnString = $"Server=localhost=3309;Database={HealthCheckDbName};Userid=root;Password=root;";
                    applicationBuilder.UseMySql(ApplicationConnString, new MySqlServerVersion(new Version(8, 0, 11)),options=>options.EnableRetryOnFailure());
                    identityBuilder.UseMySql(IdentityConnString, new MySqlServerVersion(new Version(8, 0, 11)),options=>options.EnableRetryOnFailure());
            _applicationDbContext = new ApplicationDbContext(applicationBuilder.Options);
            _applicationDbContext.Database.EnsureCreated();

            _identityDbContext = new IdentityDbContext(identityBuilder.Options);
            _identityDbContext.Database.EnsureCreated();

            SeedIdentity seed = new SeedIdentity(_identityDbContext);
            seed.SeedUsers();
            seed.SeedUserRoles();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // remove the temp db from the server once all tests are done
                    _applicationDbContext.Database.EnsureDeleted();
                    _identityDbContext.Database.EnsureDeleted();
                }
                _disposed = true;
            }
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
