﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Models
{
    public class LogEntry
    {
        public string  ErrorCode { get; set; }
        public string  Message { get; set; }
        public DateTime TimeOfEvent { get; set; }
    }
}
