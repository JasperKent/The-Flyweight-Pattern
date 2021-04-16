using CompositePattern.ToDo;
using System.Text;

namespace VisitorPattern.Visitors
{
    public class ToStringVisitor : IItemVisitor
    {
        private readonly int _indent;
        private readonly StringBuilder _builder;

        private void ShowString(IToDoItem item)
            => _builder.Append(new string(' ', 4 * _indent))
                       .AppendLine(item.ToString());

        public ToStringVisitor()
        {
            _builder = new();
        }

        private ToStringVisitor(int indent, StringBuilder builder)
        {
            _indent = indent;
            _builder = builder;
        }

        public void Visit(PurchaseItem item) => ShowString(item);
        public void Visit(CommunicationItem item) => ShowString(item);
        public void Visit(WorkItem item) => ShowString(item);
        public void Visit(CompositeItem item) => ShowString(item);

        public override string ToString()
        {
            return _builder.ToString();
        }

        public IItemVisitor GetChild() => new ToStringVisitor(_indent + 1, _builder);
    }
}
