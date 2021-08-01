using CustomerOrderDetail.Models;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace CustomerOrderDetail.Repository
{
    class CustomerOrderDetailCommand
    {
        private string _connectionString;

        //public OracleConnection _con =
        //    new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString.ToString());

        public CustomerOrderDetailCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<CustomerOrderDetailModel> GetList()
        {
            List<CustomerOrderDetailModel> customerOrderDetailModels = new List<CustomerOrderDetailModel>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("select t.customerorderid,t.customerid,t.itemid,t.firstname,t.lastname,t.description,t.price from  customerorderdetail t order by t.customerorderid", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CustomerOrderDetailModel customerOrderDetailModel = new CustomerOrderDetailModel()
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["customerorderid"]),
                                    CustomerId = Convert.ToInt32(reader["customerid"]),
                                    ItemId = Convert.ToInt32(reader["itemid"]),
                                    FirstNmae = reader["firstname"].ToString(),
                                    LastName=reader["lastname"].ToString(),
                                    Description=reader["description"].ToString(),
                                    Price=Convert.ToDecimal(reader["price"])
                                };

                                customerOrderDetailModels.Add(customerOrderDetailModel);

                            //    string firstNmae = reader["firstname"].ToString();
                            //    string firstNmae = reader["firstname"].ToString();
                            //Console.WriteLine("first Name:",firstNmae.ToString());
                            }
                        }
                }
            }

            return customerOrderDetailModels;
        }
    }
}
