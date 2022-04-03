using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Woman : Human
    {
        public Woman(string firstName, string lastName, DateTime dateOfBirth) : base(firstName, lastName, dateOfBirth) { }

        protected override void GeneratePESEL()
        {
            PESEL = DateOfBirth.ToString("yyyy-MM-dd").Replace("-", "") + EvenNumbers();
        }

        private string EvenNumbers()
        {
            Random random = new();
            int digits = random.Next(100, 201);
            while (digits % 2 != 0)
            {
                digits = random.Next(100, 201);
            }

            return digits.ToString();
        }
    }
}
