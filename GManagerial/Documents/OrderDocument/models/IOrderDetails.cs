﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Documents.OrderDocument.models
{
    internal interface IOrderDetails
    {
        int Id { get; set; }
        int FkOrder { get; set; }
        int FkProduct { get; set; }
    }
}
