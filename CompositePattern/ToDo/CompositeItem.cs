using System.Collections.Generic;
using System.Linq;
using VisitorPattern.Visitors;

namespace CompositePattern.ToDo
{
    public class CompositeItem : IToDoItem
    {
        private readonly List<IToDoItem> _items = new();

        public CompositeItem(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Add(IToDoItem item) => _items.Add(item);

        public override string ToString() => Name;

        public decimal Cost => _items.Sum(i => i.Cost);
        public double Hours => _items.Sum(i => i.Hours);

        public string Name { get; }

        public string Description { get; }

        public IToDoItem Find(string name)
        {
            IToDoItem found = name == Name ? this : null;

            if (found != null)
                return found;
            else
            {
                foreach (var item in _items)
                {
                    found = item.Find(name);

                    if (found != null)
                        return found;
                }

                return null;
            }
        }

        public void Accept(IItemVisitor visitor)
        {
            visitor.Visit(this);

            var childVisitor = visitor.GetChild();

            foreach (var item in _items)
                item.Accept(childVisitor);
        }
    }
}
