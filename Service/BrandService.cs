using System;
using System.Text.RegularExpressions;
using Core;
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

namespace Service
{
	public class BrandService
	{
        private AppDbContext _context;

        public BrandService()
        {
            _context = new AppDbContext();
        }

        public void Create(Brand entity)
        {
            if (_context.Brands.Any(x => x.Name == entity.Name))
                throw new DublicateBrandException("Brand Already exists"+entity.Name);

            _context.Brands.Add(entity);
        }
        public Brand GetById(int id)
        {
            var entity = _context.Brands.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Brand not found");
            return entity;
        }
        public List<Brand> GetAll()
        {
            return _context.Brands.Include(x => x.Products).ToList();
        }
        public void Delete(int id)
        {
            var entity = _context.Brands.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("brand not found");

            _context.Brands.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(int id, Brand entity)
        {
            var existEntity = _context.Brands.FirstOrDefault(x => x.Id == id);

            if (existEntity == null) throw new EntityNotFoundException("Brand not found");

            existEntity.Name = entity.Name;
            existEntity.CreatorName = entity.CreatorName;
           
            _context.SaveChanges();
        }


    }
}

