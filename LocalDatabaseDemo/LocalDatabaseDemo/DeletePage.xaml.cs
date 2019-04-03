using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalDatabaseDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeletePage : ContentPage
	{
		public DeletePage ()
		{
			InitializeComponent ();
		}

        Category categoryFinded= new Category();

        private void BtnFind_Clicked(object sender, EventArgs e)
        {
            
            int categoryID =int.Parse( CategoryIDEntry.Text);
            categoryFinded = App.DatabaseNorthWind.GetCategoryByID(categoryID);

            lblCategoryID.Text = categoryFinded.CategoryID.ToString();
            lblCategoryName.Text = categoryFinded.CategoryName;
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            int Result = App.DatabaseNorthWind.DeleteCategory(categoryFinded);
            if (Result > 0)
            {
                DisplayAlert("Delete", "Categoria eliminada exitosamente", "Ok");
            }
        }
    }
}