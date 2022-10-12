using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_2.Data;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ApplicationDbContext _context;

        List<GoodsAllocation> goodsAlllo = new List<GoodsAllocation>();
        List<DiasterAllocation> disasterAllo = new List<DiasterAllocation>();
        List<DisasterType> disasterTypes = new List<DisasterType>();
        List<BudgetAllocation> budgets = new List<BudgetAllocation>();
        List<double> disasterTypesTotal = new List<double>();
        List<double> goodsTotalAllocation = new List<double>();
        List<double> remainingBudget = new List<double>();

        public BudgetController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            disasterAllo = _context.DiasterAllocation.ToList();
            goodsAlllo = _context.GoodsAllocation.ToList();
            disasterTypes = _context.DisasterType.ToList();

            double allotedMoney = 0;
            double allotedGoodsMoney = 0;

            for (int x = 0; x <= disasterTypes.Count-1; x++)
            {
                string disaster = disasterTypes[x].disasterType;


                for (int y = 0; y <= disasterAllo.Count-1; y++)
                {
                    if (disasterAllo[y].disasterType.Equals(x+2))
                    {
                        allotedMoney += disasterAllo[y].amountAllotted;
                    }
                }

                disasterTypesTotal.Add(allotedMoney);
            }


            for (int x = 0; x <= disasterTypes.Count-1; x++)
            {
                string disaster = disasterTypes[x].disasterType;


                for (int y = 0; y <= goodsAlllo.Count-1; y++)
                {
                    if (goodsAlllo[y].disasterType.Equals(x+2))
                    {
                        allotedGoodsMoney += (goodsAlllo[y].pricePerItem * goodsAlllo[y].quantity);
                    }
                }

                goodsTotalAllocation.Add(allotedGoodsMoney);
            }


            for (int x = 0; x <= disasterTypes.Count-1; x++)
            {
                double budgetRemaining = disasterTypesTotal[x] - goodsTotalAllocation[x];
                remainingBudget.Add(budgetRemaining);

                disasterTypes[x].disasterType = budgets[x].disaterType;
                disasterTypesTotal[x] = budgets[x].disasterBudget;
                goodsTotalAllocation[x] =budgets[x].totalGoodsPurchase;
                remainingBudget[x] = budgets[x].budgetRemaining;

                budgets.Add(budgets[x]);
            }

            





            return View(budgets);
        }
    }
}
