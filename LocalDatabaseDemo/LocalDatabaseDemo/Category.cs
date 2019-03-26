using System;
using System.Collections.Generic;
using System.Text;

using SQLite;


namespace LocalDatabaseDemo
{
  [Table("Categories")]
  public class Category // Clase = Tabla
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryID { get; set; } // Propiedad = Columna

        [MaxLength(100)]
        public string CategoryName { get; set; } // Propiedad

        public string Description { get; set; }

       
    }
}
