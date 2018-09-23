namespace TravelAgency.Models
{
    public class Customer
    {
        private string _id;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;

        public Customer() { }

        public Customer(string id, string firstName, string lastName, string email, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }
    }
}