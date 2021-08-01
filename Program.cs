using CustomerOrderDetail.Models;
using CustomerOrderDetail.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace CustomerOrderDetail
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                string constr = "user id=ritinhouse;password=rit;data source=SampleDataSource";
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(constr);
                IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach (CustomerOrderDetailModel customerOrderDetailModel in customerOrderDetailModels)
                    {
                        Console.WriteLine("{0}: FullName: {1} {2} (Cust Id: {3}) - purchased {4} for {5} (ItemId: {6})",
                            customerOrderDetailModel.CustomerOrderId,
                            customerOrderDetailModel.FirstNmae,
                            customerOrderDetailModel.LastName,
                            customerOrderDetailModel.CustomerId,
                            customerOrderDetailModel.Description,
                            customerOrderDetailModel.Price,
                            customerOrderDetailModel.ItemId
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong {0}", ex.Message);
            }
            //foreach (var item in customerList)
            //{
            //    Console.WriteLine("Description: "+item.Description);
            //}
            //Console.ReadLine();


            //try
            //{
            //    // Please replace the connection string attribute settings
            //    string constr = "user id=ritinhouse;password=rit;data source=SampleDataSource";

            //    OracleConnection con = new OracleConnection(constr);
            //    con.Open();
            //    Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);
            //    con.Dispose();

            //    Console.WriteLine("Press RETURN to exit.");
            //    Console.ReadLine();
            //}
            //catch (OracleException ex)
            //{
            //    Console.WriteLine("Error : {0}", ex.Message);
            //    Console.ReadLine();
            //}
        }
    }
}
