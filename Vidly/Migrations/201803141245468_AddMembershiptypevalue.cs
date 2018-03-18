namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddMembershiptypevalue : DbMigration
    {
        public override void Up()
        {
            Sql("update MemberShipTypes set Name = 'pay as you go' where id = 1");
            Sql("update MemberShipTypes set Name = 'silver' where id = 2");
        }

        public override void Down()
        {
        }
    }
}
