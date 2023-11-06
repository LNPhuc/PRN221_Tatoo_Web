using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
            Studios = new HashSet<Studio>();
        }

        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Studio> Studios { get; set; }
    }
}