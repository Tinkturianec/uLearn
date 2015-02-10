namespace uLearn.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalStatisticIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserSolutions", new[] { "UserId" });
            CreateIndex("dbo.UserSolutions", new[] { "CourseId", "IsRightAnswer", "SlideId", "UserId" }, name: "TotalStatistic");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserSolutions", "TotalStatistic");
            CreateIndex("dbo.UserSolutions", "UserId");
        }
    }
}
