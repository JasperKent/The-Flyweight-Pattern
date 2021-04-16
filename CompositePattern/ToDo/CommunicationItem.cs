namespace CompositePattern.ToDo
{
    public record CommunicationItem(string Name, string Description, double Hours) : IToDoItem
    {
        public const decimal CallRate = 2;

        public decimal Cost => (decimal)Hours * CallRate;

        public override string ToString() => $"{Name} will take {Hours} hours and cost {Cost:C}.";
    }
}
