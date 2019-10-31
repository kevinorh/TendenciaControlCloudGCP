using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace TendenciasControl.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AppWebContext : DbContext
    {
        public DbSet<Pedido> Pedidos
        {
            get;
            set;
        }
       
        public AppWebContext()
            //Reference the name of your connection string ( WebAppCon )  
            : base("WebAppCon") { }
    }
}