using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using DomingoRoofWorks.Models;
using System.Runtime.Remoting.Messaging;
using System.Data;

namespace DomingoRoofWorks.Respiratory
{
    public class InvoiceRespiratory
    {
        private SqlConnection conn;

        private void Connection()
        {
            String conStr = ConfigurationManager.ConnectionStrings["getConn"].ToString();
            conn = new SqlConnection(conStr);

        }
        // Retrieve all Invoices
        public List<InvoiceModel> GetAllInvoices()
        {
            Connection();
            List<InvoiceModel> InvoiceList = new List<InvoiceModel>();

            SqlCommand getCommand = new SqlCommand("GetAllInvoices", conn);
            getCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(getCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                InvoiceList.Add
                    (
                        new InvoiceModel
                        {

                            JobCardId = Convert.ToInt32(dr["JobCardId"]),
                            SubTotal = Convert.ToDouble(dr["SubTotal"]),
                            Vat = Convert.ToDouble(dr["Vat"]),
                            Total = Convert.ToDouble(dr["Total"]),

                        }
                    );
            }
            return InvoiceList;





        }
        //Add new Invoice
        public bool AddInvoice(InvoiceModel obj)
        {
            Connection();
            SqlCommand AddCommand = new SqlCommand("AddInvoice");
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.Parameters.AddWithValue("JobCardId", obj.JobCardId);
            AddCommand.Parameters.AddWithValue("@SubTotal", obj.SubTotal);
            AddCommand.Parameters.AddWithValue("@Vat", obj.Vat);
            AddCommand.Parameters.AddWithValue("@Total", obj.Total);


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

        internal bool DeleteInvoice(int id)
        {
            throw new NotImplementedException();
        }


        //Updating Invoice 
        public bool UpdateInvoice(InvoiceModel obj)
        {
            Connection();
            SqlCommand UpdateCommand = new SqlCommand("UpdateInvoice");
            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.AddWithValue("JobCardId", obj.JobCardId);
            UpdateCommand.Parameters.AddWithValue("@SubTotal", obj.SubTotal);
            UpdateCommand.Parameters.AddWithValue("@Vat", obj.Vat);
            UpdateCommand.Parameters.AddWithValue("@Total", obj.Total);
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

        //Deleting from Invoice
        public bool DeleteInvoice(InvoiceModel obj)
        {
            Connection();
            SqlCommand DeleteCommand = new SqlCommand("DeleteInvoice");
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