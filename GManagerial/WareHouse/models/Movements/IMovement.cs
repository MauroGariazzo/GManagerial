using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.WareHouse.models
{
    internal interface IMovement
    {
        int ID
        {
            get;
            set;
        }

        string MovementType
        {
            get; set;
        }

        int WareHouseFK
        {
            get; set;
        }

        DateTime DateMovement { get; set; }

        string Causal
        {
            get;
            set;
        }
    }
}
