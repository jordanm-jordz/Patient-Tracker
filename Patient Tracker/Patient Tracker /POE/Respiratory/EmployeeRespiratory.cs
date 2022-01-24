using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Configuration;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using DomingoRoofWorks.Models;
using System.Runtime.Remoting.Messaging;
using System.Data;

namespace DomingoRoofWorks.Respiratory
{
    public class EmployeeRespiratory
    {
        private SqlConnection conn;

        private void Connection()
        {
            String conStr = ConfigurationManager.ConnectionStrings["getConn"].ToString();
            conn = new SqlConnection(conStr);

        }
        // Retrieve all Employee Information 
        public List<EmployeeModel> GetAllEmployees()
        {
            Connection();
            List<EmployeeModel> EmployeeList = new List<EmployeeModel>();

            SqlCommand getCommand = new SqlCommand("GetAllEmployees", conn);
            getCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(getCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                EmployeeList.Add
                    (
                        new EmployeeModel
                        {
                            EmpId = Convert.ToString(dr["EmployeeId"]),
                            JobCardId = Convert.ToInt32(dr["JobCardId"]),
                            EmpNames = Convert.ToString(dr["EmployeeNames"]),

                        }
                    );
            }
            return EmployeeList;





        }
        //Add new Employee
        public bool AddEmployee(EmployeeModel obj)
        {
            Connection();
            SqlCommand AddCommand = new SqlCommand("AddEmployee");
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.Parameters.AddWithValue("@EmployeeId", obj.EmpId);
            AddCommand.Parameters.AddWithValue("@JobCardId", obj.JobCardId);
            AddCommand.Parameters.AddWithValue("@EmployeeNames", obj.EmpNames);

            conn.Open();
            int i = AddCommand.ExecuteNonQuery();
            conn.Close();
            if (i < 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        internal bool DeleteEmployee(string id)
        {
            throw new NotImplementedException();
        }

        internal bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }


        //Updating Employee 
        public bool UpdateEmployee(EmployeeModel obj)
        {
            Connection();
            SqlCommand UpdateCommand = new SqlCommand("UpdateEmployee");
            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.AddWithValue("@EmployeeId", obj.EmpId);
            UpdateCommand.Parameters.AddWithValue("JobCardId", obj.JobCardId);
            UpdateCommand.Parameters.AddWithValue("@EmployeeNames", obj.EmpNames);

            conn.Open();
            int i = UpdateCommand.ExecuteNonQuery();
            conn.Close();
            if (i < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Deleting from Employee
        public bool DeleteEmployee(EmployeeModel obj)
        {
            Connection();
            SqlCommand DeleteCommand = new SqlCommand("DeleteEmployee");
            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.AddWithValue("@JobCardId", obj.JobCardId);

            conn.Open();
            int i = DeleteCommand.ExecuteNonQuery();
            conn.Close();
            if (i < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}