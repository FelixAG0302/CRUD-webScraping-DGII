using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApiREDDE.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApiREDDE.DAL
{
    public class Company_DAL
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;

        public static IConfiguration Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }

        public List<Company> GetAll()
        {
            List<Company> companyList = new List<Company>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[Get_Companies]";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())
                {
                    Company company = new Company();
                    company.Id = Convert.ToInt32(dr["Id"]);
                    company.RNC = dr["RNC"].ToString();
                    company.Name = dr["Name"].ToString();
                    company.CommercialName = dr["CommercialName"].ToString();
                    company.Category = dr["Category"].ToString();
                    company.PaymentScheme = dr["PaymentScheme"].ToString();
                    company.State = dr["State"].ToString();
                    company.EconomicActivity = dr["EconomicActivity"].ToString();
                    company.GubernamentalBranch = dr["GubernamentalBranch"].ToString();
                    companyList.Add(company);
                }

            }
            return companyList;
        }

        public Company GetById(int id)
        {
            Company company = new Company();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[Get_Company_Id]";
                _command.Parameters.AddWithValue("@Id", id);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())
                {
                    company.Id = Convert.ToInt32(dr["Id"]);
                    company.RNC = dr["RNC"].ToString();
                    company.Name = dr["Name"].ToString();
                    company.CommercialName = dr["CommercialName"].ToString();
                    company.Category = dr["Category"].ToString();
                    company.PaymentScheme = dr["PaymentScheme"].ToString();
                    company.State = dr["State"].ToString();
                    company.EconomicActivity = dr["EconomicActivity"].ToString();
                    company.GubernamentalBranch = dr["GubernamentalBranch"].ToString();
                }

            }
            return company;
        }

        public void Create(Company company)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[Create_Company]";
                _command.Parameters.AddWithValue("@RNC", company.RNC);
                _command.Parameters.AddWithValue("@Name", company.Name);
                _command.Parameters.AddWithValue("@CommercialName", company.CommercialName);
                _command.Parameters.AddWithValue("@Category", company.Category);
                _command.Parameters.AddWithValue("@PaymentScheme", company.PaymentScheme);
                _command.Parameters.AddWithValue("@State", company.State);
                _command.Parameters.AddWithValue("@EconomicActivity", company.EconomicActivity);
                _command.Parameters.AddWithValue("@GubernamentalBranch", company.GubernamentalBranch);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
        }

        public void Update(int id, Company company)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[Update_Company]";
                _command.Parameters.AddWithValue("@Id", company.Id);
                _command.Parameters.AddWithValue("@RNC", company.RNC);
                _command.Parameters.AddWithValue("@Name", company.Name);
                _command.Parameters.AddWithValue("@CommercialName", company.CommercialName);
                _command.Parameters.AddWithValue("@Category", company.Category);
                _command.Parameters.AddWithValue("@PaymentScheme", company.PaymentScheme);
                _command.Parameters.AddWithValue("@State", company.State);
                _command.Parameters.AddWithValue("@EconomicActivity", company.EconomicActivity);
                _command.Parameters.AddWithValue("@GubernamentalBranch", company.GubernamentalBranch);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
        }

        public void Delete(int Id)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[Delete_Company]";
                _command.Parameters.AddWithValue("@Id", Id);

                _connection.Open();
                _command.ExecuteNonQuery();
            }
        }
    }
}
