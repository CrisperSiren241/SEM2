using Lab_4_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_5.ModelView
{
    public interface IMemento
    {
        void Restore();
    }

    public class ProductMemento : IMemento
    {
        private readonly Products _product;
        private readonly string _name;
        private readonly string _description;
        private readonly decimal _price;
        private readonly string _imageUrl;

        public ProductMemento(Products product)
        {
            _product = product;
            _name = product.Name;
            _description = product.Description;
            _price = product.Price;
            _imageUrl = product.Url;
        }

        public void Restore()
        {
            _product.Name = _name;
            _product.Description = _description;
            _product.Price = _price;
            _product.Url = _imageUrl;
        }
    }
}
