using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IFoodService
    {
        IEnumerable<FoodDto> GetAll();
        FoodDto? GetById(int id);
        IEnumerable<FoodDto> Category1();
        IEnumerable<FoodDto> Category2();
        IEnumerable<FoodDto> Category3();
        IEnumerable<FoodDto> Category4();
        IEnumerable<FoodDto> Category5();
        void Create(FoodDto food);
        IEnumerable<FoodDto> Increase();
        IEnumerable<FoodDto> Decrease();
        void Edit(FoodDto food);
        void Delete(int id);
    }
}
