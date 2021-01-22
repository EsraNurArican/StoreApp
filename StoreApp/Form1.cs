using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreApp.Data;
using StoreApp.Models;

namespace StoreApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void GetCategories()
        {
            //db objesini her metodda tek tek oluşturmak yerine global olarak da oluşturabilirsin.
            var db = new MiniShopDbContext();
            dataGridView1Kategoriler.DataSource = db.Categories.ToList();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Category category = new Category { Id = 1, Name = "Kırtasiye ofis malzemeleri" };
            Product product = new Product { Id = 9, Name = "Fabook", Description = "Çiçekli Defter" };

            GetCategories();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
           
            var db = new MiniShopDbContext();

            Category newCategory = new Category();
            newCategory.Name = CategoryName.Text;
            newCategory.Description = CategoryDefn.Text;

            //kategori ekler
            db.Categories.Add(newCategory);
            int effectedRow=db.SaveChanges(); //SaveChanges int döndürür, eklenen satır sayısı

            if (effectedRow > 0)
            {
                MessageBox.Show("Eklendi!");
                GetCategories();
                GetProducts();
            }

            else
                MessageBox.Show("Ekleme Başarısız!");
        }

        private void GetProducts()
        {
            var db = new MiniShopDbContext();
            comboBox1.DataSource = db.Products.Select(p => new { p.Id, p.Name }).ToList();
            comboBox1.DisplayMember = "Name"; //gösterecegi deger
            comboBox1.ValueMember = "Id";     //arkada saklayacagı deger
            //cünkü idyi ekrana basması kullanıcı icin saçma olur.



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //amacımız secilen ürünün ayrıntılarını göstermek
            var db = new MiniShopDbContext();
            var selectedProductId = (int)comboBox1.SelectedValue;

            //find sadece primary key icin kullanılıyor
            var product = db.Products.Find(selectedProductId);
            MessageBox.Show($"{product.Name} isimli ürünün fiyatı:{product.Price} , ve puanı: {product.Rating}");
        }
    }
}
