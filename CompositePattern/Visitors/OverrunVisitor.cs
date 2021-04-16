using CompositePattern.ToDo;

namespace VisitorPattern.Visitors
{
    public class OverrunVisitor : IItemVisitor
    {
        public double Overrun { get; private set; }

        public void Visit(WorkItem item) 
        {
            Overrun += item.Hours - item.EstimatedHours;
        }
    }
}
