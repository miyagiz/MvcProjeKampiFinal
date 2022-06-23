namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addedSkillCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillCards",
                c => new
                    {
                        SkillCardID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Surname = c.String(maxLength: 50),
                        SchoolName = c.String(maxLength: 100),
                        SkillName1 = c.String(maxLength: 30),
                        SkillPoint1 = c.Int(nullable: false),
                        SkillName2 = c.String(maxLength: 30),
                        SkillPoint2 = c.Int(nullable: false),
                        SkillName3 = c.String(maxLength: 30),
                        SkillPoint3 = c.Int(nullable: false),
                        SkillName4 = c.String(maxLength: 30),
                        SkillPoint4 = c.Int(nullable: false),
                        SkillName5 = c.String(maxLength: 30),
                        SkillPoint5 = c.Int(nullable: false),
                        SkillName6 = c.String(maxLength: 30),
                        SkillPoint6 = c.Int(nullable: false),
                        SkillName7 = c.String(maxLength: 30),
                        SkillPoint7 = c.Int(nullable: false),
                        SkillName8 = c.String(maxLength: 30),
                        SkillPoint8 = c.Int(nullable: false),
                        SkillName9 = c.String(maxLength: 30),
                        SkillPoint9 = c.Int(nullable: false),
                        SkillName10 = c.String(maxLength: 30),
                        SkillPoint10 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillCardID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SkillCards");
        }
    }
}
