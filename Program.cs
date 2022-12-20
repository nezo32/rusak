using queues;

Console.WriteLine("Creating queue");
MyQueue queue = new MyQueue();

Console.WriteLine("Pushing some values");
queue.Push(5);
queue.Push(99);
queue.Push(555);

queue.Print();

Console.WriteLine("Pop element");
queue.Pop();

queue.Print();

Console.WriteLine("Push another element");
queue.Push(111);

queue.Print();

Console.WriteLine("Clear all queue");
queue.Clear();

queue.Print();

Console.WriteLine("Push elements for test");
queue.Push(5);
queue.Push(99);
queue.Push(555);
queue.Push(111);
queue.Push(1);

queue.Print();

Console.WriteLine("Get element with id 2");
Console.WriteLine($"\n{queue.Get(2)}\n");

Console.WriteLine("Change element with id 2 to 9999");
queue.Set(2, 9999);

Console.WriteLine("Get element with id 2");
Console.WriteLine($"\n{queue.Get(2)}\n");

queue.Print();

Console.WriteLine("Quicksorting queue");
int? count = queue.Count();
int temp = 0;
if (count != null)
    temp = (int)count;
QuickSort(queue, 0, temp - 1);

queue.Print();


queue.Clear();


static int Partition(MyQueue queue, int start, int end)
{
    var pivot = queue.Get((start + end) / 2);
    var l = start;
    var r = end;

    while (l <= r)
    {
        while (queue.Get(l) < pivot)
            l++;
        while (queue.Get(r) > pivot)
            r--;
        if (l >= r)
            break;
        queue.Swap(l++, r--);
    }

    return r;
}

static void QuickSort(MyQueue queue, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex)
    {
        return;
    }
    int pivot = Partition(queue, minIndex, maxIndex);
    QuickSort(queue, minIndex, pivot);
    QuickSort(queue, pivot + 1, maxIndex);
}
