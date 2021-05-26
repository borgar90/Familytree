namespace Familytree
{

    public class Person
    {
        //private static int IdCounter = 0;

        public int ID
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public int BirthYear
        {
            get;
            set;
        }

        public int DeathYear
        {
            get;
            set;
        }


        public Person Mother
        {
            get;
            set;
        }


        public Person Father
        {
            get;
            set;
        }

        //Father = new Person() { Id = 23, FirstName = "Per" },
        //var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };

        public Person()
        { }

        public Person(int id)
        {
            this.ID = id;
        }

        public Person(int id, string firstname, string lastname, int birthyear, int deathyear, Person father, Person mother)
        {
            this.Father = father;
            this.Mother = mother;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.ID = id;
            this.BirthYear = birthyear;
            this.DeathYear = deathyear;
        }

        public Person(int id, string firstname)
        {
            this.FirstName = firstname;
            this.ID = id;
        }


        private string FindFather()
        {
            var output = "";
            if (Father != null)
            {
                if (Father.FirstName != null) output += $" Far: {Father.FirstName}";
                if (Father.ID != 0) output += $" (Id={Father.ID})";
            }

            return output;
        }

        private string FindMother()
        {
            var output = "";
            if (Mother != null)
            {
                if (Mother.FirstName != null) output += $" Mor: {Mother.FirstName}";
                if (Mother.ID != 0) output += $" (Id={Mother.ID})";
            }

            return output;
        }

        public string GetDescription()
        {
            string output = "";
            if (FirstName != null) output += $" {FirstName}";
            if (LastName != null) output += $" {LastName}";
            output += $" (Id={ID})";
            if (BirthYear != 0) output += $" Født: {BirthYear}";
            if (DeathYear != 0) output+=$" Død: {DeathYear}";
            output += FindFather();
            output += FindMother();
            output = GetSpaces(output);
            return output;
        }

        private string GetSpaces(string output)
        {
            //if first word - no space
            //if second word add space
            char[] spaceChar = {' '};
            if (output[0] == ' ')
            {
               string nyString = output.Substring(1);
               return nyString;
            }

            return output;
        }

    }
}
