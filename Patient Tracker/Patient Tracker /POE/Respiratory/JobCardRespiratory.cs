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
    public class JobCardRespiratory
    {
        private SqlConnection conn;

        private void Connection()
        {
            String conStr = ConfigurationManager.ConnectionStrings["getConn"].ToString();
            conn = new SqlConnection(conStr);

        }
        // Retrieve all Job cards
        public List<JobCardModel> GetAllJobCards()
        {
            Connection();
            List<JobCardModel> cardList = new List<JobCardModel>();

            SqlCommand getCommand = new SqlCommand("GetAllJobCards", conn);
            getCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(getCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                cardList.Add
                    (
                        new JobCardModel
                        {
                            JobCardId = Convert.ToInt32(dr["JobCardId"]),
                            JobType = Convert.ToString(dr["JobType"]),
                            DailyRate = Convert.ToDouble(dr["DailyRate"]),
                            NumOfDays = Convert.ToInt32(dr["NumberOfDays"])
                        }
                    );
            }
            return cardList;





        }
        //Add new Job Card
        public bool AddJobCard(JobCardModel obj)
        {
            Connection();
            SqlCommand AddCommand = new SqlCommand("AddJobCard");
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.Parameters.AddWithValue("@JobCardId", obj.JobCardId);
            AddCommand.Parameters.AddWithValue("@JobType", obj.JobType);
            AddCommand.Parameters.AddWithValue("@DailyRate", obj.DailyRate);
            AddCommand.Parameters.AddWithValue("@NumberOfDays", obj.NumOfDays);

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

        internal bool DeleteJobCard(int id)
        {
            throw new NotImplementedException();
        }


        //Updating a Job card
        public bool UpdateJobCard(JobCardModel obj)
        {
            Connection();
            SqlCommand UpdateCommand = new SqlCommand("UpdateJobCards");
            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.AddWithValue("@JobCardId", obj.JobCardId);
            UpdateCommand.Parameters.AddWithValue("@JobType", obj.JobType);
            UpdateCommand.Parameters.AddWithValue("@DailyRate", obj.DailyRate);
            UpdateCommand.Parameters.AddWithValue("@NumberOfDays", obj.NumOfDays);

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

        //Updating a Job card
        public bool DeleteJobCard(JobCardModel obj)
        {
            Connection();
            SqlCommand DeleteCommand = new SqlCommand("DeleteJobCard");
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