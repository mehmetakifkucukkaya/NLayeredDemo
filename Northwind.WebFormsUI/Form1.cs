using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAcces.Abstract;
using Northwind.DataAcces.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        //* Burada ProductManager'ı newlerken hangi veri tabanı kullanılacaksa onu parametre olarak göndermemiz gerekiyor.
        private IProductService _productService= new ProductManager(new EfProductDal());
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();

        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            //* Ürün Ekleme Kısmı için
            cbxCategoryID.DataSource = _categoryService.GetAll();
            cbxCategoryID.DisplayMember = "CategoryName";
            cbxCategoryID.ValueMember = "CategoryId";

            //* Ürün Güncelleme Kısmı için
            cbxCategoryIDUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryIDUpdate.DisplayMember = "CategoryName";
            cbxCategoryIDUpdate.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

            }
            
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            //* TbxProductName'de herhangi bir değer yoksa tüm elemanları listeler
            if (!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxProductName.Text);
            }
            else
            {
                LoadProducts();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cbxCategoryID.SelectedValue),
                    ProductName = tbxProductName2.Text,
                    QuantityPerUnit = tbxQuantityPerUnits.Text,
                    UnitsInStock = Convert.ToInt16(tbxStock.Text),
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                });
                MessageBox.Show("Ürün Eklendi !");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {
                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    CategoryId = Convert.ToInt32(cbxCategoryIDUpdate.SelectedValue),
                    ProductName = tbxProductName2Update.Text,
                    QuantityPerUnit = tbxQuantityPerUnitsUpdate.Text,
                    UnitsInStock = Convert.ToInt16(tbxStockUpdate.Text),
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                }); ;
                MessageBox.Show("Ürün Güncellendi !");
                LoadProducts();
            }
            catch (Exception exception)
            { 
                MessageBox.Show(exception.Message);
            }


        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;
            tbxProductName2Update.Text =row.Cells[1].Value.ToString();
            cbxCategoryIDUpdate.SelectedValue= row.Cells[2].Value;
            tbxUnitPriceUpdate.Text= row.Cells[3].Value.ToString();
            tbxQuantityPerUnitsUpdate.Text = row.Cells[4].Value.ToString();
            tbxStockUpdate.Text = row.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgwProduct.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                    });

                    MessageBox.Show("Ürün Silindi !");
                    LoadProducts();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }
    }
}
