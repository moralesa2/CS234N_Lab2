﻿using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class CustomerDB
    {

        public static Customer GetCustomer(int customerID)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT CustomerID, Name, Address, City, State, ZipCode "
                + "FROM Customers "
                + "WHERE CustomerID = @CustomerID";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);

            try
            {
                connection.Open();
                MySqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.Name = custReader["Name"].ToString();
                    customer.Address = custReader["Address"].ToString();
                    customer.City = custReader["City"].ToString();
                    customer.State = custReader["State"].ToString();
                    customer.ZipCode = custReader["ZipCode"].ToString();
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static int AddCustomer(Customer customer)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(Name, Address, City, State, ZipCode) " +
                "VALUES (@Name, @Address, @City, @State, @ZipCode)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            insertCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            insertCommand.Parameters.AddWithValue(
                "@City", customer.City);
            insertCommand.Parameters.AddWithValue(
                "@State", customer.State);
            insertCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                // MySQL specific code for getting last pk value
                string selectStatement =
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteCustomer(Customer customer)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            // get a connection to the database
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE CustomerID = @CustomerID " +
                "AND Name = @Name " +
                "AND Address = @Address " +
                "AND City = @City " +
                "AND State = @State " +
                "AND ZipCode = @ZipCode";
            MySqlCommand deleteCommand = 
                new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@CustomerID", customer.CustomerID);
            deleteCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            deleteCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            deleteCommand.Parameters.AddWithValue(
                "@City", customer.City);
            deleteCommand.Parameters.AddWithValue(
                "@State", customer.State);
            deleteCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);
            // set up the command object

            try
            {
                connection.Open();
                // open the connection
                int recordsReturned = deleteCommand.ExecuteNonQuery();
                // execute the command
                if (recordsReturned == 1)
                    return true;
                // if the number of records returned = 1, return true otherwise return false
            }
            catch (MySqlException ex)
            {
                throw ex;
                // throw the exception
            }
            finally
            {
                connection.Close();
                // close the connection
            }
            return false;
        }

        public static bool UpdateCustomer(Customer oldCustomer,
            Customer newCustomer)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            // create a connection
            string updateStatement =
                "UPDATE Customers SET " +
                "Name = @NewName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE CustomerID = @OldCustomerID " +
                "AND Name = @OldName " +
                "AND Address = @OldAddress " +
                "AND City = @OldCity " +
                "AND State = @OldState " +
                "AND ZipCode = @OldZipCode";
            MySqlCommand updateCommand =
                new MySqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewName", newCustomer.Name);
            updateCommand.Parameters.AddWithValue(
                "@NewAddress", newCustomer.Address);
            updateCommand.Parameters.AddWithValue(
                "@NewCity", newCustomer.City);
            updateCommand.Parameters.AddWithValue(
                "@NewState", newCustomer.State);
            updateCommand.Parameters.AddWithValue(
                "@NewZipcode", newCustomer.ZipCode);
            updateCommand.Parameters.AddWithValue(
                "@OldCustomerID", oldCustomer.CustomerID);
            updateCommand.Parameters.AddWithValue(
                "@OldName", oldCustomer.Name);
            updateCommand.Parameters.AddWithValue(
               "@OldAddress", oldCustomer.Address);
            updateCommand.Parameters.AddWithValue(
               "@OldCity", oldCustomer.City);
            updateCommand.Parameters.AddWithValue(
               "@OldState", oldCustomer.State);
            updateCommand.Parameters.AddWithValue(
               "@OldZipcode", oldCustomer.ZipCode);
            // setup the command object
            try
            {
                connection.Open();
                // open the connection
                int recordsReturned = updateCommand.ExecuteNonQuery();
                // execute the command
                if (recordsReturned == 1)
                    return true;
                // if the number of records returned = 1, return true otherwise return false
            }
            catch (MySqlException ex)
            {
                throw ex;
                // throw the exception
            }
            finally
            {
                connection.Close();
                // close the connection
            }

            return false;
        }
    }
}
