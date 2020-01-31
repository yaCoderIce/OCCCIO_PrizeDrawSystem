using PrizeDraw.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrizeDraw.DataLayer.Providers
{
    public abstract class Provider
    {
        protected PrizeDrawDatabaseContext DatabaseContext { get; private set; }
        /// <summary>
        /// Parameterized Constructor
        /// Connect to database
        /// </summary>
        /// <param name="connectionString"></param>
        protected Provider(string connectionString)
        {
            //Check if the connectionstirng is empty
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            DatabaseContext = new PrizeDrawDatabaseContext(connectionString);
        }

        protected Provider(PrizeDrawDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public void Add<T>(T modelObject) where T : class
        {
            DatabaseContext.Add(modelObject);
        }

        public void Save()
        {
            DatabaseContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await DatabaseContext.SaveChangesAsync(cancellationToken);
        }
    }
}
