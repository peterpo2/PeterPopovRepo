
using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using static Dealership.Validator;

namespace Dealership.Models
{
    public class User : IUser
    {
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";
        private const string InvalidUsernameLengthError = "Username must be between 2 and 20 characters long!";

        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const string InvalidNameError = "name must be between 2 and 20 characters long!";

        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const string InvalidPasswordFormatError = "Username contains invalid symbols!";
        private const string InvalidPasswordLengthError = "Password must be between 5 and 30 characters long!";

        private const int MaxVehiclesToAdd = 5;

        private const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";

        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private readonly IList<IVehicle> vehicles = new List<IVehicle>();

        public User(string usrename, string firstName, string lastName, string password, Role role)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Role = role;
        }

        public string Username
        {
            get
            {
                return username;
            }
            private set
            {
                ValidateIntRange(
                    value.Length,
                    NameMinLength,
                    NameMaxLength,
                    InvalidUsernameLengthError);
                ValidateSymbols(value, UsernamePattern, InvalidUsernameFormatError);

                username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                ValidateIntRange(
                    value.Length,
                    NameMinLength,
                    NameMaxLength,
                    $"First {InvalidNameError}");

                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                ValidateIntRange(
                    value.Length,
                    NameMinLength,
                    NameMaxLength,
                    $"Last {InvalidNameError}");

                lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            private set
            {
                ValidateIntRange(value.Length, PasswordMinLength, PasswordMaxLength, InvalidPasswordLengthError);
                ValidateSymbols(value, PasswordPattern, InvalidPasswordFormatError);

                password = value;
            }
        }

        public Role Role { get; }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return new List<IVehicle>(this.vehicles);
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.AddComment(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (Role == Role.Normal && Vehicles.Count >= MaxVehiclesToAdd)
            {
                throw new ArgumentException(string.Format(NotAnVipUserVehiclesAdd, MaxVehiclesToAdd));
            }

            if (Role == Role.Admin)
            {
                throw new ArgumentException(AdminCannotAddVehicles);
            }

            vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"--USER {Username}--");

            var count = 1;
            if (Vehicles.Count <= 0)
            {
                sb.AppendLine(NoVehiclesHeader);
            }
            else
            {
                foreach (var vehicle in Vehicles)
                {
                    sb.AppendLine($"{count++}. {vehicle.ToString()}");
                }
            }

            return sb.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (Username != commentToRemove.Author)
            {
                throw new ArgumentException(YouAreNotTheAuthor);
            }

            vehicleToRemoveComment.RemoveComment(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            return $"Username: {Username}, FullName: {FirstName} {LastName}, Role: {Role}";
        }
    }
}
