namespace Domain
{
    public abstract class Human
    {
        public Human(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            GeneratePESEL();
        }

        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected DateTime DateOfBirth { get; set; }
        protected string PESEL { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} | {PESEL}";
        }

        protected abstract void GeneratePESEL();

        public virtual void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public virtual void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }
    }
}