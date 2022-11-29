namespace Course_Homework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genreupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "ProducedBy", c => c.String(maxLength: 100));
            DropColumn("dbo.Genres", "WrittenBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "WrittenBy", c => c.String(maxLength: 100));
            DropColumn("dbo.Genres", "ProducedBy");
        }
    }
}
