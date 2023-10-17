BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
binaryHeap.Add(8);
binaryHeap.Add(5);
binaryHeap.Add(12);
binaryHeap.Add(3);
binaryHeap.Add(2);
binaryHeap.Add(1);
binaryHeap.Add(7);
binaryHeap.Add(6);
binaryHeap.Add(4);
binaryHeap.Add(9);

binaryHeap.PrintItems();
Console.WriteLine("HERE IS THE HEAP MAP:");
binaryHeap.PrintItemsLevels();

List <int> sortedItems = new List<int>();
while (binaryHeap.Count > 0)
{
    sortedItems.Add(binaryHeap.ExtractMax());
}

foreach (var item in sortedItems)
{
    Console.WriteLine(item);
}