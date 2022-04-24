using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Woman : Human
    {
        public Woman(string firstName, string lastName, DateTime dateOfBirth, int currentIndex) 
            : base(firstName, lastName, dateOfBirth, currentIndex) { }

        protected override void GeneratePESEL(int currentIndex)
        {
            var datePart = PeselLogic.GenererateDatePart(DateOfBirth);
            if (datePart == null) PESEL = null;
            var pesel = $"{datePart}{PeselLogic.GenererateOrderPart(currentIndex)}{EvenNumber()}";
            PESEL = $"{pesel}{PeselLogic.GenererateControlDigit(pesel)}";
        }

        private static string EvenNumber()
        {
            Random random = new();
            int digits = random.Next(1, 10);
            while (digits % 2 != 0)
            {
                digits = random.Next(1, 10);
            }

            // test
            return 2.ToString();
            
            return digits.ToString();
        }
    }
}
