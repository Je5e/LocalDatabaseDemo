using SQLite;
using System.Collections.Generic;

namespace LocalDatabaseDemo
{
    public class Database
    {

        SQLiteConnection DbContext; // Base de datos.

        public Database(string dbFilePath)
        {
            DbContext = new SQLiteConnection(dbFilePath);

            DbContext.CreateTable<Category>(); // Crear la tabla.
        }

        // CRUD
        // Leer todos los registros de table Categories.
        public List<Category> GetCategories()
        {
            List<Category> ListCategories = new List<Category>();

            ListCategories = DbContext.Table<Category>().ToList();

            return ListCategories; // SELECT * FROM Categories
        }

        public int InsertCategory(Category newCategory)
        {
            return DbContext.Insert(newCategory); // INSERT INTO Categories (CategoryName) VALUES('Name')
        }

        public int UpdateCategory(Category updatedCategory)
        {
            return DbContext.Update(updatedCategory);
        }


        public int DeleteCategory(Category deleteCategory)
        {
            return DbContext.Delete(deleteCategory); 
            // DELETE FROM Categories WHERE CategoryID = delete.ID

        }

        public Category GetCategoryByID(int ID)
        {
            return DbContext.Table<Category>().Where(c => c.CategoryID == ID)
                .FirstOrDefault();
            // SELECT * FROM categories WHERE categoryid = 1
        }

    }

}
