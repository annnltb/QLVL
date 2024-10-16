using QLVL.DAL;
using QLVL.Entity;
using System.Collections.Generic;

namespace QLVL.BLL
{
    public class InventoryPlanBLL
    {
        private readonly InventoryPlanDAL inventoryPlanDAL;

        public InventoryPlanBLL(string connectionString)
        {
            inventoryPlanDAL = new InventoryPlanDAL(connectionString);
        }

        // Lấy tất cả kế hoạch nhập kho
        public List<InventoryPlan> GetAllPlans()
        {
            return inventoryPlanDAL.GetAllPlans();
        }

        // Thêm kế hoạch nhập kho mới
        public void AddPlan(InventoryPlan plan)
        {
            inventoryPlanDAL.AddPlan(plan);
        }
    }
}
