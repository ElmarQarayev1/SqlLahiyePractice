using System;
using Core;
using Core.Entites;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

namespace Service
{
	public class OrderService
	{
		private AppDbContext _context;

		public OrderService()
		{
			_context = new AppDbContext();
		}
        public void Create(Order entity)
        {
          
            _context.Orders.Add(entity);
        }
        public Order GetById(int id)
        {
            var entity = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Order not found");
            return entity;
        }
        public List<Order> GetAll()
        {
            return _context.Orders.Include(x=>x.Product).ToList();
        }
        public void Delete(int id)
        {
            var entity = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Order not found");

            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(int id, Order entity)
        {
            var existEntity = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (existEntity == null) throw new EntityNotFoundException("Order not found");

            existEntity.Count = entity.Count;
            _context.SaveChanges();
        }
    }
}

