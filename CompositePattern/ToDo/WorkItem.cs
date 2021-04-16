namespace CompositePattern.ToDo
{
    public record WorkItem(string Name, string Description, double Hours, double EstimatedHours) : IToDoItem
    {
        public const decimal PayRate = 35;

        public decimal Cost => (decimal)Hours * PayRate;

        public override string ToString() => $"{Name} will take {Hours} hours and cost {Cost:C}.";
    }
}
