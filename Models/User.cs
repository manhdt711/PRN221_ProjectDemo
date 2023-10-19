using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models;

    public partial class User
    {
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public int? Permission { get; set; }

        public virtual Employee Employee { get; set; }
    }

