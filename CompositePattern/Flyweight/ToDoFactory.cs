using CompositePattern.ToDo;
using System.Collections.Generic;

namespace FlyweightPattern.Flyweight
{
    public class ToDoFactory
    {
        private readonly HashSet<IToDoItem> _flyweightPool = new();

        public int ObjectCount { get; private set; }

        private IToDoItem GetOldOrNew(IToDoItem newItem)
        {
            if (_flyweightPool.TryGetValue(newItem, out var foundItem))
                return foundItem;
            else
            {
                _flyweightPool.Add(newItem);

                ++ObjectCount;

                return newItem;
            }
        }

        public IToDoItem WorkItem(string name, string description, double hours, double estimatedHours)
        {
            return GetOldOrNew(new WorkItem(name, description, hours, estimatedHours));
        }
     
        public IToDoItem CommunicationItem(string name, string description, double hours)
        {
            return GetOldOrNew(new CommunicationItem(name, description, hours));
        }

        public IToDoItem PurchaseItem(string name, string description, decimal cost, string supplier)
        {
            return GetOldOrNew(new PurchaseItem(name, description, cost, supplier));
        }
    }
}
