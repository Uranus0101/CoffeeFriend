using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFriend
{
    internal class CoffeeQueue
    {
        private Queue<Person> coffeeQue = new Queue<Person>();

        public void Enqueue(Person person)
        {
            coffeeQue.Enqueue(person);
        }

        public Person Dequeue()
        {
            return coffeeQue.Dequeue();
        }

        public void Rotate()
        {
            if(coffeeQue.Count > 1)
            {
                var firstPerson = coffeeQue.Dequeue();
                coffeeQue.Enqueue(firstPerson);
            }
        }

        public override string ToString()
        {
            return string.Join(", ", coffeeQue);
        }
    }
}
