using System;
using System.Collections.Generic;

namespace Familytree
{
    public class FamilyApp
    {
        private List<Person> _people;
        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
        }

       

        public string WelcomeMessage = "Velkommen til familieappen";
        public string CommandPrompt = "Skriv vis og id for å søke... Eks: vis 1: \n";



        private int CommandIsRight(string command)
        {
            var commandArray = command.Split(' ');
            int id;
            if (commandArray.Length == 2)
            {
                var IsInt = int.TryParse(commandArray[1], out id);
                if (IsInt && commandArray[0] == "vis")
                {
                    return id;
                }
            }
            
            Console.WriteLine("feil Kommando: " + CommandPrompt);
            return 0;
        }



        public string HandleCommand(string command)
        {
            int id = CommandIsRight(command);
            if (id != 0)
            {
                   foreach (var person in _people)
                   {
                      Person personFound = findPerson(id, person);
                      if (personFound != null)
                      {
                        return  ListOutPersonWithChildren(personFound, id);
                      }

                   }
            }
           
            return $"Fant ingen ved id = {id}...";
        }

        private string ListOutPersonWithChildren(Person person, int id)
        {
            string personWithRightIdReturn = person.GetDescription();
            
            personWithRightIdReturn += ReturnChildren(id);

            return personWithRightIdReturn;
        }


       private Person findPerson(int id, Person person)
        {
            if (person.ID == id)
            {
                return person;
            }
            else
            {
                return null;
            }
        }

       private String ReturnChildren(int id)
       {
           string personWithRightIdReturn = "";
           bool firstTime = true;
           foreach (var child in _people)
           {
               if (child.Father != null)
               {
                   if (child.Father.ID == id)
                   {
                       if (firstTime)
                       {
                           personWithRightIdReturn += $"\n";
                           personWithRightIdReturn += $"  Barn:\n";
                           firstTime = false;
                       }
                       
                        personWithRightIdReturn +=
                           $"    {child.FirstName} {child.LastName}(Id={child.ID}) Født: {child.BirthYear}\n";
                   }
               }

           }

           return personWithRightIdReturn;
       }
    }
}
