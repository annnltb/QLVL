using QLVL.DAL;
using QLVL.Entity;
using System.Collections.Generic;

namespace QLVL.BLL
{
    public class ReportBLL
    {
        private readonly ReportDAL reportDAL;

        public ReportBLL(string connectionString)
        {
            reportDAL = new ReportDAL(connectionString);
        }

        // Lấy tất cả báo cáo
        public List<Report> GetAllReports()
        {
            return reportDAL.GetAllReports();
        }

        // Thêm báo cáo mới
        public void AddReport(Report report)
        {
            reportDAL.AddReport(report);
        }
    }
}
