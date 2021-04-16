namespace CompositePattern.ToDo
{
    public record PurchaseItem(string Name, string Description, decimal Cost, string Supplier) : IToDoItem
    {
        public double Hours => 0;

        public override string ToString() => $"{Name} will take {Hours} hours and cost {Cost:C}.";
    }
}
