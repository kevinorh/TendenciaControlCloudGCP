namespace TendenciasControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(unicode: false),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        Foto = c.String(unicode: false),
                        DescripcionPedido = c.String(unicode: false),
                        Precio = c.Double(nullable: false),
                        Domicilio = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pedidoes");
        }
    }
}
