using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Citizen
    {
        public Citizen(string firstName, string lastName, DateTime dateOfBirth, int sex)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Sex = sex;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PESEL { get; set; }
        public int Sex { get; set; }

        public string FullName => $"{LastName} {FirstName}";
        public string DisplayDateOfBirth => DateOfBirth.ToString("yyyy-MM-dd");

        public void GeneratePESEL(int currentIndex)
        {
            var datePart = PeselLogic.GenererateDatePart(DateOfBirth);
            if (datePart == null) PESEL = null;
            var pesel = $"{datePart}{PeselLogic.GenererateOrderPart(currentIndex)}{SexNumber(Sex)}";
            PESEL = $"{pesel}{PeselLogic.GenererateControlDigit(pesel)}";
        }

        private static string SexNumber(int sex)
        {
            return sex == 1 ? EvenNumber() : OddNumber();
        }


        private static string EvenNumber()
        {
            Random random = new();
            int digits = random.Next(1, 10);
            while (digits % 2 != 0)
            {
                digits = random.Next(1, 10);
            }

            return digits.ToString();
        }

        private static string OddNumber()
        {
            Random random = new();
            int digits = random.Next(1, 10);
            while (digits % 2 == 0)
            {
                digits = random.Next(1, 10);
            }

            return digits.ToString();
        }

    }
}
