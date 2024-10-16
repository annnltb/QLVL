using QLVL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLVL.DAL
{
    public class ReportDAL
    {
        private readonly string connectionString;

        public ReportDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Lấy tất cả báo cáo
        public List<Report> GetAllReports()
        {
            var reports = new List<Report>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Reports", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reports.Add(new Report
                        {
                            ReportId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            ReportType = reader.GetString(2),
                            CreatedAt = reader.GetDateTime(3)
                        });
                    }
                }
            }
            return reports;
        }

        // Thêm báo cáo mới
        public void AddReport(Report report)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Reports (UserId, ReportType, CreatedAt) VALUES (@UserId, @ReportType, @CreatedAt)", connection);
                command.Parameters.AddWithValue("@UserId", report.UserId);
                command.Parameters.AddWithValue("@ReportType", report.ReportType);
                command.Parameters.AddWithValue("@CreatedAt", report.CreatedAt);
                command.ExecuteNonQuery();
            }
        }
    }
}
