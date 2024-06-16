using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.DBConnectors;
using GManagerial.Products;

namespace GManagerial.WareHouse.models.Movements
{
    internal class DAOMovement:IDAOMovement
    {
        private IDBConnector _dBConnector;

        public DAOMovement(IDBConnector dBConnector)
        {
            this._dBConnector = dBConnector;
        }

        public Dictionary<int, Movement> GetAll(Warehouse warehouse)
        {
            string query = "SELECT * FROM WAREHOUSE_MOVEMENTTBL WHERE WAREHOUSE_ID = @WAREHOUSE_ID";
            Dictionary<int, Movement> movements = new Dictionary<int, Movement>();

            try
            {
                _dBConnector.Open();
                using (SqlCommand command = new SqlCommand(query,_dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", warehouse.ID);
                    using (SqlDataReader reader = _dBConnector.Load(command))
                    {
                        while(reader.Read())
                        {
                            Movement movement = new Movement();
                            movement.ID = Convert.ToInt32(reader["MOVEMENT_ID"]);
                            movement.MovementType = Convert.ToString(reader["TYPE"]);
                            movement.DateMovement = Convert.ToDateTime(reader["DATE"]);
                            movement.Causal = Convert.ToString(reader["CAUSAL"]);

                            movements.Add(movement.ID, movement);
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                if (_dBConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dBConnector.Close();
                }
                MessageBox.Show(ex.Message);
            }
            _dBConnector.Close();
            return movements;
        }

        public int Insert(Movement movement)
        {
            string query = "INSERT INTO WAREHOUSE_MOVEMENTTBL(TYPE,DATE,WAREHOUSE_ID,CAUSAL) VALUES (@TYPE,@DATE,@WAREHOUSE_ID,@CAUSAL);SELECT SCOPE_IDENTITY();";
            int id_movement = 0;
            try
            {
                _dBConnector.Open();

                using(SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@TYPE", movement.MovementType);
                    command.Parameters.AddWithValue("@DATE", DateTime.Now);
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", movement.WareHouseFK);
                    command.Parameters.AddWithValue("@CAUSAL", movement.Causal);

                    id_movement = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                if(_dBConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dBConnector.Close();
                }
                return id_movement;
            }
            _dBConnector.Close();
            return id_movement;
        }       
        
        public void Delete(int idMovement)
        {
            string query = "DELETE FROM WAREHOUSE_MOVEMENTTBL WHERE MOVEMENT_ID = @MOVEMENT_ID";

            try
            {
                _dBConnector.Open();
                using (SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@MOVEMENT_ID", idMovement);
                    _dBConnector.Delete(command);
                }
            }

            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);                
            }
            _dBConnector.Close();
        }
    }
}
