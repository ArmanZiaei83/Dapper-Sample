using FluentMigrator;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Migration
{
    [Migration(202111152203)]
    public class _202111152203_InitializedDb : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .NotNullable()
                .WithColumn("Name").AsString().NotNullable();
            Create.Table("Products")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Products");
            Delete.Table("Users");
        }
    }
}