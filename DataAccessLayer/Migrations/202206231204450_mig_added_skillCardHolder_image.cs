namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_skillCardHolder_image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SkillCards", "imageOfSkillCardHolder", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SkillCards", "imageOfSkillCardHolder");
        }
    }
}
