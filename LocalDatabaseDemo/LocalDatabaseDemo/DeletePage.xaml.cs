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

        private void BtnFind_Clicked(object sender, EventArgs e)
        {
            string DBFilePath =
                Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData),
                "NewDB.db3");

            Database database = new Database(DBFilePath);

            Category categoryFinded = new Category();
            int categoryID =int.Parse( CategoryIDEntry.Text);
            categoryFinded = database.GetCategoryByID(categoryID);

            lblCategoryID.Text = categoryFinded.CategoryID.ToString();
            lblCategoryName.Text = categoryFinded.CategoryName;
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {

        }
    }
}