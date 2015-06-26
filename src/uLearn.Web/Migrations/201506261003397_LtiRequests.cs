namespace uLearn.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LtiRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LtiRequestModels",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 64),
                        CourseId = c.String(nullable: false, maxLength: 64),
                        SlideId = c.String(nullable: false, maxLength: 64),
                        Request = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LtiRequestModels");
        }
    }
}
