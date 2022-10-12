using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_2.Models
{
    public class BudgetAllocation
    {
        public int ID { get; set; }
        public string disaterType { get; set; }
        public double disasterBudget { get; set; }
        public double totalGoodsPurchase { get; set; }
        public double budgetRemaining { get; set; }


        public BudgetAllocation() { 
        }

    }
}
