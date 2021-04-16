using VisitorPattern.Visitors;

namespace CompositePattern.ToDo
{
    public interface IToDoItem
    {
       string Name { get; }
       string Description { get;  }
       double Hours { get;  }
       decimal Cost { get; }

        IToDoItem Find(string name) => name == Name ? this : null;
        void Accept(IItemVisitor visitor) => visitor.Visit((dynamic)this);
    }
}
