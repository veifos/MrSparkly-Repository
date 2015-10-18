using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace DbConnection
{
    public class dbConn
    {
        #region Class Variables

        OleDbConnection _dbConn;
        string _strDBFile = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Pre-condition:  The database file specified in the parameter exists.
        /// 
        /// Post-condition: The connection to the database will be established.
        /// 
        /// Description:    This class constructor will establish a connection to the specified database.
        /// </summary>
        /// <param name="pStrDBFile">Path for database to connect to.</param>
        public dbConn(string pStrDBFile)
        {
            if (_strDBFile == pStrDBFile) return;

            _strDBFile = pStrDBFile;

            string strConnection = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = "
                                   + _strDBFile;
            _dbConn = new OleDbConnection(strConnection);
        }

        #endregion

        #region Accessors

        /// <summary>
        /// Pre-condition:  None
        /// Post-condition: The records specified in the sql query will be 
        ///                 loaded in the table specified.
        /// Description:    This method will return a data table loaded with
        ///                 records specified in the SQL query for display
        ///                 purposes.
        /// </summary>
        /// <param name="pStrQuery">The SQL query that will select the records to be loaded.</param>
        /// <returns>The data table that contains the selected records.</returns>
        public DataTable executeSelectionQuery(string pStrQuery)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // create an OleDbDataAdapter object to fill the DataTable
                OleDbDataAdapter dbDA = new OleDbDataAdapter();
                // create an OleDbCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();
                // set the command to the SQL string
                dbCmd.CommandText = pStrQuery;
                // set the OleDbCommand connection
                dbCmd.Connection = _dbConn;
                // set the OleDbDataAdapter SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the DataTable using the OleDbDataAdapter fill method
                dbDA.Fill(dataTable);

                // close the connection after the fill
                _dbConn.Close();
            }
            catch (Exception e)
            {
                _dbConn.Close();
                MessageBox.Show("An error occurred. Contact your system administrator.");
                //FileLogger fw = new FileLogger("ErrorLog", "Text");
                //fw.write(e.ToString());
            }

            return dataTable;
        }

        /// <summary>
        /// Pre-condition:  None
        /// Post-condition: The records specified in the sql query will be 
        ///                 loaded in the table specified.
        /// Description:    This method will return a data table loaded with
        ///                 records from the table specified.
        /// </summary>
        /// <param name="pStrTableName">The name of the table.</param>
        /// <returns>The data table that contains the selected records.</returns>
        public DataTable getDataTable(string pStrTableName)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // create an OleDbDataAdapter object to fill the DataTable
                OleDbDataAdapter dbDA = new OleDbDataAdapter();
                // create an OleDbCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();
                // set the command to the SQL string
                dbCmd.CommandText = "SELECT * FROM " + pStrTableName;
                // set the OleDbCommand connection
                dbCmd.Connection = _dbConn;
                // set the OleDbDataAdapter SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the DataTable using the OleDbDataAdapter fill method
                dbDA.Fill(dataTable);

                // close the connection after the fill
                _dbConn.Close();
            }
            catch (Exception e)
            {
                _dbConn.Close();
                MessageBox.Show("An error occurred. Contact your system administrator.");
                //FileLogger fw = new FileLogger("ErrorLog", "Text");
                //fw.write(e.ToString());
            }

            return dataTable;
        }

        public void fillDataSet(DataSet pDataSet, string pStrQuery, string pStrTableName)
        {
            DataTable dtb = new DataTable();

            try
            {
                // create an OleDbDataAdapter object to fill the DataTable
                OleDbDataAdapter dbDA = new OleDbDataAdapter();
                // create an OleDbCommand to hold the SQL statement
                OleDbCommand dbCmd = new OleDbCommand();
                // set the command to the SQL string
                dbCmd.CommandText = pStrQuery;
                // set the OleDbCommand connection
                dbCmd.Connection = _dbConn;
                // set the OleDbDataAdapter SelectCommand
                dbDA.SelectCommand = dbCmd;

                // only open the connection as short time as possible
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

                // fill the DataTable using the OleDbDataAdapter fill method
                dbDA.Fill(dtb);

                // close the connection after the fill
                _dbConn.Close();

                // name the data table
                dtb.TableName = pStrTableName;

                // add the table to the dataset
                pDataSet.Tables.Add(dtb);

                // set the primary key constraints of the table
                pDataSet.Tables[pStrTableName].PrimaryKey = new DataColumn[] { pDataSet.Tables[pStrTableName].Columns[0] };
                // set the primary key to auto-increment
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrement = true;
                // set the starting value of the primary key auto-number
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrementSeed = -1;
                // set the increment step
                pDataSet.Tables[pStrTableName].Columns[0].AutoIncrementStep = 10;
            }
            catch (Exception e)
            {
                _dbConn.Close();
                MessageBox.Show("An error occurred. Contact your system administrator.");
                //FileLogger fw = new FileLogger("ErrorLog", "Text");
                //fw.write(e.ToString());
            }
        }

        #endregion

        #region Mutators

        /// <summary>
        /// Pre-condition:  The parameters will be in the order of dataset and string.
        /// Post-condition: The update dataset will be persisted in the database.
        /// Description:    This method will update the database based on the updated 
        ///                 records in the dataset for the specified table.
        /// </summary>
        /// <param name="pDataSet">The dataset that contains the updated records.</param>
        /// <param name="pStrTableName">The table name that will be updated.</param>
        public void saveData(DataSet pDataSet, string pStrTableName)
        {
            //specify select statement for our data adapter
            string strSQL = "SELECT * FROM " + pStrTableName;

            // create an instance of the data adapter
            OleDbDataAdapter dbDA = new OleDbDataAdapter(strSQL, _dbConn);

            try
            {
                // setup the command builder - not suitable for large databases
                OleDbCommandBuilder dbBLD = new OleDbCommandBuilder(dbDA);
                dbDA.InsertCommand = dbBLD.GetInsertCommand();
                dbDA.UpdateCommand = dbBLD.GetUpdateCommand();
                dbDA.DeleteCommand = dbBLD.GetDeleteCommand();

                // subscribe to the OleDbRowUpdateEventHandler
                dbDA.RowUpdated += new OleDbRowUpdatedEventHandler(dbDA_RowUpdated);

                // update the database using the Update method of the data adapter
                if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();
                // update the database
                dbDA.Update(pDataSet, pStrTableName);
                // close the connection
                _dbConn.Close();
                // refresh the dataset
                pDataSet.Tables[pStrTableName].AcceptChanges();
            }
            catch (Exception e)
            {
                _dbConn.Close();
                MessageBox.Show("An error occurred. Contact your system administrator.");
                //FileLogger fw = new FileLogger("ErrorLog", "Text");
                //fw.write(e.ToString());
            }
        }

        /// <summary>
        /// Pre-condition:  true
        /// Post-condition: Child record will be persisted in the database consistent
        ///                 with the primary key of the parent record.
        /// Description:    This method will synchronize the primary and foreign key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dbDA_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            int intID = 0;

            if (_dbConn.State == ConnectionState.Closed) _dbConn.Open();

            OleDbCommand dbCMD = new OleDbCommand("SELECT @@IDENTITY", _dbConn);

            if (e.StatementType == StatementType.Insert)
            {
                intID = (int)dbCMD.ExecuteScalar();
                e.Row[0] = intID;
            }
        }

        #endregion

    }
}
