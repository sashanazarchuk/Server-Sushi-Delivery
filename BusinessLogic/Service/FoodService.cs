using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Service
{
    public class FoodService : IFoodService
    {
        private readonly DeliveryDbContext context;
        private readonly IMapper mapper;
        public FoodService(DeliveryDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Create(FoodDto food)
        {
            context.Foods.Add(mapper.Map<Food>(food));
            context.SaveChanges();
        }

        public IEnumerable<FoodDto> Decrease()
        {
            var foods = context.Foods.OrderByDescending(f => f.Price).ToList();
            if (foods == null) return null;
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }

        public void Delete(int id)
        {
            var foods = context.Foods.Find(id);

            if (foods == null) return;

            context.Foods.Remove(foods);
            context.SaveChanges();
        }

        public void Edit(FoodDto food)
        {
            var data = context.Foods.AsNoTracking().FirstOrDefault(w => w.Id == food.Id);

            if (data == null) return;

            context.Foods.Update(mapper.Map<Food>(food));
            context.SaveChanges();
        }

        public IEnumerable<FoodDto> GetAll()
        {
            var foods = context.Foods.ToList();
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }

        public IEnumerable<FoodDto> Category1()
        {
            var foods = context.Foods.OrderBy(x => x.Category).Where(x => x.Category.Equals("Дракони")).ToList();
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }
        public IEnumerable<FoodDto> Category2()
        {
            var foods = context.Foods.OrderBy(x => x.Category).Where(x => x.Category.Equals("Філадельфії")).ToList();
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }
        public IEnumerable<FoodDto> Category3()
        {
            var foods = context.Foods.OrderBy(x => x.Category).Where(x => x.Category.Equals("Хосомакі")).ToList();
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }
        public IEnumerable<FoodDto> Category4()
        {
            var foods = context.Foods.OrderBy(x => x.Category).Where(x => x.Category.Equals("Сети")).ToList();
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }
        public IEnumerable<FoodDto> Category5()
        {
            var foods = context.Foods.OrderBy(x => x.Category).Where(x => x.Category.Equals("Сирні")).ToList();
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }
        public FoodDto? GetById(int id)
        {
            var foods = context.Foods.Find(id);

            if (foods == null) return null;
            return mapper.Map<FoodDto>(foods);
        }

        public IEnumerable<FoodDto> Increase()
        {
            var foods = context.Foods.OrderBy(f => f.Price).ToList();
            if (foods == null) return null;
            return mapper.Map<IEnumerable<FoodDto>>(foods);
        }

       
    }
}
