using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalDatabaseDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private void BtnFind_Clicked(object sender, EventArgs e)
        {
            // Acceder a la base de datos.
           
            // Uso de los methods de la clase Database.
            int categoryID = int.Parse(CategoryIDEntry.Text);
            Category category;

            category = App.DatabaseNorthWind.GetCategoryByID(categoryID);
            if (category == null)
            {
                DisplayAlert("Message", $"No existe el ID:{categoryID}", "OK");
            }
            else
            {
                CategoryIDFindedEntry.Text = category.CategoryID.ToString();
                CategoryNameFindedEntry.Text = category.CategoryName;
                CategoryDesFindedEntry.Text = category.Description;
            }
        }

        private void BtnUpdateCategory_Clicked(object sender, EventArgs e)
        {
            Category categoryUpdated = new Category
            {
                CategoryID =int.Parse( CategoryIDFindedEntry.Text),
                CategoryName = CategoryNameFindedEntry.Text,
                Description = CategoryDesFindedEntry.Text
            };
            // Acceder a la base de datos.
          
            int Result = App.DatabaseNorthWind.UpdateCategory(categoryUpdated);
            if (Result > 0)
                DisplayAlert("Message", "Category Updated!", "Ok");
        }
    }
}