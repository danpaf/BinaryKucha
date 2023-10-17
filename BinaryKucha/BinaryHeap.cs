using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> items;

    public BinaryHeap()
    {
        items = new List<T>();
    }

    public int Count => items.Count;

    public void Add(T item)
    {
        Console.WriteLine($"Добавлен {item}");
        items.Add(item);
        HeapifyUp(Count - 1);
    }

    public T ExtractMax()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Пусто.");
        }

        T minItem = items[0];
        Console.WriteLine($"Минимальный: {minItem}");
        items[0] = items[Count - 1];
        items.RemoveAt(Count - 1);
        HeapifyDown(0);

        return minItem;
    }

    public List<T> GetItems()
    {
        return new List<T>(items);
    }

    public void PrintItems()
    {
        List<T> itemsToPrint = GetItems();
        foreach (T item in itemsToPrint)
        {
            Console.WriteLine(item);
        }
    }

    public void PrintItemsLevels()
    {
        List<T> itemsToPrint = GetItems();
        int level = 0;
        int levelNodes = 1;
        int nodesPrinted = 0;

        for (int i = 0; i < itemsToPrint.Count; i++)
        {
            if (nodesPrinted == 0)
            {
                Console.Write("Level " + level + ": ");
            }

            Console.Write(itemsToPrint[i] + " ");

            nodesPrinted++;
            if (nodesPrinted == levelNodes)
            {
                Console.WriteLine();
                level++;
                levelNodes *= 2;
                nodesPrinted = 0;
            }
        }
    }

    private void HeapifyUp(int index)
    {
        int parentIndex = (index - 1) / 2;

        while (index > 0 && items[index].CompareTo(items[parentIndex]) < 0)
        {
            Console.WriteLine($"Заменяем {items[index]} на {items[parentIndex]}");
            Swap(index, parentIndex);
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int smallest = index;

        if (leftChild < Count && items[leftChild].CompareTo(items[smallest]) < 0)
        {
            smallest = leftChild;
        }

        if (rightChild < Count && items[rightChild].CompareTo(items[smallest]) < 0)
        {
            smallest = rightChild;
        }

        if (smallest != index)
        {
            Console.WriteLine($"Заменяем {items[index]} на {items[smallest]}");
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private void Swap(int i, int j)
    {
        T temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }
}
