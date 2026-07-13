using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserArtStudio.Domain.Entities
{
    public class Customer
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string PhoneNumber { get; private set; } = string.Empty;

        public DateTime CreatedAt { get; private set; }

        public bool IsActive { get; private set; }

        private Customer()
        {
        }

        public Customer(
            string firstName,
            string lastName,
            string email,
            string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Update(
            string firstName,
            string lastName,
            string email,
            string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }
    }
}