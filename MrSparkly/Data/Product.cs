using DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrSparkly.Data
{
    public class Product
    {
        #region vars

        //const strings are for lazy SQL
        public const string TABLE_NAME = "tblProducts";
        public const string PRIMARY_KEY = "ProductID";

        // dbconn/dataset/datarow are for our actual data
        dbConn _connection = new dbConn(Meta.Utilities.DB_FILE);
        DataSet _dataSet = new DataSet();
        DataRow _dataRow = null;

        #endregion vars


        #region properties
        
        //these properties represent the fields in our access database
        //our table has an autonumber primary key (which maps to int or long)
        //it also has a text field (description) which maps to a string
        //lastly we have a currency field - in C#, currency maps to the decimal type

        public long ID {get; set;}
        public string Description {get; set;}
        public decimal Price {get; set;}

        #endregion properties


        #region constructors

        public Product()
        {
            // this construtor is used for a new record
            LoadDataSet();
        }

        public Product(long primary_key)
        {
            // this constructor is used for an existing record
            ID = primary_key;
            LoadDataSet();
            AssignProperties();
        }

        #endregion constructors

        #region accessors

        private void LoadDataSet()
        {
            // this method loads all the data from a table into our dataset
            // if we have an ID, it just loads tht record with the IF statement
            string query = "SELECT * FROM " + TABLE_NAME;

            if (ID > 0)
            {
                query += " WHERE " + PRIMARY_KEY + " = " + ID;
            }

            _connection.fillDataSet(_dataSet, query, TABLE_NAME);
        }

        private void AssignProperties()
        {
            // this method pulls data out of the data set and sets it in our object
            // this allows us to word directly with strongly typed pieces of data
            // ie, it changes the name from (string)_dataSet etc. into Description
            Description = (string)_dataSet.Tables[TABLE_NAME].Rows[0]["Description"];
            Price = (decimal)_dataSet.Tables[TABLE_NAME].Rows[0]["ProductPrice"];
        }
        #endregion accessors


        #region mutators

        public void SaveData()
        {
            // if the ID is 0, we add a new record
            //if it is not 0, we update the existing record
            if (ID == 0)
            {
                AddNewRecord();
            }
            else 
            {
                UpdateRecord();
            }

            _connection.saveData(_dataSet, TABLE_NAME);
        }

        public void DeleteRecord()
        {
            if (ID > 0)
            {
                //deletes the record if the ID is above 0
                // an ID of 0 or less indicates that the object it's a real data record yet
                _dataSet.Tables[TABLE_NAME].Rows.Find(ID).Delete();
                _connection.saveData(_dataSet, TABLE_NAME);
            }
        }


        public void AddNewRecord()
        {
            // creates a new data row, and inserts our properties into it
            // another way of explaining this method is converting our data object into
            // a real record
            _dataRow = _dataSet.Tables[TABLE_NAME].NewRow();
            _dataRow.BeginEdit();

            _dataRow["Description"] = Description;
            _dataRow["ProductPrice"] = Price;

            _dataRow.EndEdit();
            _dataSet.Tables[TABLE_NAME].Rows.Add(_dataRow);
        }

        private void UpdateRecord()
        {
            // finds an existing row in the dataset
            // updates that row
            //pushes the update back to the database
            _dataRow = _dataSet.Tables[TABLE_NAME].Rows.Find(ID);
            _dataRow.BeginEdit();

            _dataRow["Description"] = Description;
            _dataRow["ProductPrice"] = Price;

            _dataRow.EndEdit();
        }

        #endregion mutators

    }
}