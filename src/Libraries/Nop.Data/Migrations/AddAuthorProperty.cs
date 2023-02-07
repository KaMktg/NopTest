using FluentMigrator;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Migrations
{
    [NopMigration("2023/02/07 12:00:00:2551770", "Product. Add Author property", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class AddAuthorProperty : AutoReversingMigration
    {
        /// <summary>Collect the UP migration expressions</summary>
        public override void Up()
        {
            Create.Column(nameof(Product.Author))
                .OnTable(nameof(Product))
                .AsString(255)
                .Nullable();
        }
    }
}
