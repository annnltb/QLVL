using System;

namespace QLVL.Entity
{
    public class Report
    {
        // Constructor mặc định
        public Report()
        {
            CreatedAt = DateTime.Now; // Gán giá trị mặc định cho CreatedAt
        }

        // Constructor đầy đủ
        public Report(int reportId, int userId, string reportType, DateTime createdAt)
        {
            ReportId = reportId;
            UserId = userId;
            ReportType = reportType;
            CreatedAt = createdAt;
        }

        // Properties
        public int ReportId { get; set; } // PK
        public int UserId { get; set; } // FK to User
        public string ReportType { get; set; } // Sửa kiểu dữ liệu thành string
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Giá trị mặc định
    }
}
