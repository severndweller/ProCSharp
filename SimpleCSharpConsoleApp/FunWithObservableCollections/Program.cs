using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FunWithGenericCollections;

namespace FunWithObservableCollections
{
    class Program
    {
        static void Main(string[] args)
        {

            // Make as Collection to add and observe a few Person Objects
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person { FirstName = "Peter", LastName = "Murphy", Age = 52},
                new Person { FirstName = "Kevin", LastName = "Key", Age = 48}
            };

            foreach (Person p in people)
            {
                Console.WriteLine("Started as {0}", p.FirstName);
            }

            people.CollectionChanged += people_CollectionChanged;

            people.Add(new Person { FirstName = "Stevey", LastName = "Watkins", Age = 9 });
            people.Add(new Person { FirstName = "Gemma", LastName = "Watkins", Age = 9 });
            Person deleteThis = people.ElementAt(1);
            people.Remove(deleteThis);


            foreach (Person p in people)
            {
                Console.WriteLine("Finally as {0}", p.FirstName);
            }

            Console.ReadLine();

        }
        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
//            throw new NotImplementedException();

            // What was the action that caused the event to fire
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                // Old Items
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine("Previous {0}", p.ToString());
                }


            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {

                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine("Now {0}", p.ToString());
                }

            }

        }
    }
}
