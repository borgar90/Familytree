
using Familytree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamilytreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAllFields()
        {
            var p = new Person
            {
                ID = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { ID = 23, FirstName = "Per" },
                Mother = new Person() { ID = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [TestMethod]
        public void TestNoFields()
        {
            var p = new Person
            {
                ID = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        
        [TestMethod]
        public void TestWithIdMotherAndFather()
        {
            var p = new Person
            {
                ID = 17,
                
                Father = new Person() { ID = 23, FirstName = "Per" },
                Mother = new Person() { ID = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=17) Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void FamilyAppTest()
        {
            var sverreMagnus = new Person { ID = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { ID = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { ID = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var harald = new Person { ID = 6, FirstName = "Harald", BirthYear = 1937 };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("vis 3");
            var expectedResponse = "Haakon Magnus (Id=3) Født: 1973 Far: Harald (Id=6)\n"
                                   + "  Barn:\n"
                                   + "    Sverre Magnus (Id=1) Født: 2005\n"
                                   + "    Ingrid Alexandra (Id=2) Født: 2004\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
        //Lag en test som sjekker at om en person ikke har noen barn, så listes det ikke opp noen 
        //personer som barn - og overskriften "Barn" vises heller ikke.Sørg så for at testen lykkes.

        [TestMethod]
        public void FindChilderen()
        {
            var p = new Person
            {
                ID = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { ID = 23, FirstName = "Per" },
                Mother = new Person() { ID = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}
