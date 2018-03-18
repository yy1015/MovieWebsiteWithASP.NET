namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddBirthdayValuetoCustomer : DbMigration
    {
        public override void Up()
        {
            Sql(

            "update Customers set Birthday = '1991-10-15' where id =3");
        }

        public override void Down()
        {
        }
    }
}
