using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    // Allows creation of a transaction
    public class TransactionHandler
    {
        // Constructor
        public TransactionHandler()
        { }

        // Create transaction
        public int create(int orderID, int custID, int bankID)
        {
            // Establishes transaction model
            TransactionModel transModel = new TransactionModel();

            // Holds the new transaction
            Transaction newTrans = new Transaction();

            // Stored details for the transaction
            newTrans.DateOfOrder = DateTime.Now;
            newTrans.OrderID = orderID;
            newTrans.CustomerID = custID;
            newTrans.BankID = bankID;

            // Adds object to the database
            int transactionID = transModel.CreateTransaction(newTrans);

            // Returns the transactionID
            return transactionID;
        }
    }
}