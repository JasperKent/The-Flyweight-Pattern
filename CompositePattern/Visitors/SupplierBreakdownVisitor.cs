using CompositePattern.ToDo;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern.Visitors
{
    public class SupplierBreakdownVisitor : IItemVisitor
    {
        private readonly Dictionary<string, decimal> _breakdown = new();

        public void Visit(PurchaseItem item)
        {
            _breakdown[item.Supplier] = _breakdown.GetValueOrDefault(item.Supplier) + item.Cost;
        }

        public override string ToString()
        {
            StringBuilder bob = new();

            foreach (var kvp in _breakdown)
                bob.AppendLine($"{kvp.Key}: {kvp.Value:C}");

            return bob.ToString();
        }
    }
}
