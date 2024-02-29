using System;
using Core;
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

namespace Service
{
	public class ProductService
	{
        private AppDbContext _context;

        public ProductService()
        {
            _context = new AppDbContext();
        }

        public void Create(Product entity)
        {
            if (_context.Products.Any(x => x.Id == entity.Id))
                throw new DublicateProductException("Product Already exists" + entity.Name);

            _context.Products.Add(entity);
        }
        public Product GetById(int id)
        {
            var entity = _context.Products.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("product not found");
            return entity;
        }
        public List<Product> GetAll()
        {
            return _context.Products.Include(x => x.Brand).ToList();
        }
        public void Delete(int id)
        {
            var entity = _context.Products.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("product not found");

            _context.Products.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(int id, Product entity)
        {
            var existEntity = _context.Products.FirstOrDefault(x => x.Id == id);

            if (existEntity == null) throw new EntityNotFoundException("product not found");

            existEntity.Name = entity.Name;
            existEntity.Startdate = entity.Startdate;
            _context.SaveChanges();
        }

    }
}

