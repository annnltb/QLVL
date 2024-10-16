using QLVL.DAL;
using QLVL.Entity;
using System.Collections.Generic;

namespace QLVL.BLL
{
    public class SupplierBLL
    {
        private readonly SupplierDAL supplierDAL;

        public SupplierBLL(string connectionString)
        {
            supplierDAL = new SupplierDAL(connectionString);
        }

        // Lấy tất cả nhà cung cấp
        public List<Supplier> GetAllSuppliers()
        {
            return supplierDAL.GetAllSuppliers();
        }

        // Thêm nhà cung cấp mới
        public void AddSupplier(Supplier supplier)
        {
            supplierDAL.AddSupplier(supplier);
        }

        // Các phương thức khác như Update và Delete có thể thêm vào tương tự
    }
}
