using System.Collections.Generic;
using QLVL.DAL;
using QLVL.Entity;

namespace QLVL.BLL
{
    public class MaterialBLL
    {
        private MaterialDAL materialDal;

        public MaterialBLL()
        {
            materialDal = new MaterialDAL();
        }

        public List<Material> GetAllMaterials()
        {
            return materialDal.GetAllMaterials();
        }

        public Material GetMaterialById(int materialId)
        {
            return materialDal.GetMaterialById(materialId);
        }

        public void AddMaterial(Material material)
        {
            materialDal.AddMaterial(material);
        }

        public void UpdateMaterial(Material material)
        {
            materialDal.UpdateMaterial(material);
        }

        public void DeleteMaterial(int materialId)
        {
            materialDal.DeleteMaterial(materialId);
        }
    }
}
