namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DiscountRate,DurationMonths) values (0,0,0)");
            Sql("INSERT INTO MemberShipTypes (SignUpFee,DiscountRate,DurationMonths) values (50,40,4)");
        }

        public override void Down()
        {
        }
    }
}
