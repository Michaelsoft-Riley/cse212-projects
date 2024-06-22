using System.Diagnostics;

public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();

        // Test Cases

        // Test 1
        // Scenario: Enqueue should add an item to the back of the queue
        // Expected Result: priorityQueue.ToString should return the values in queue in the same order that they were added from left to right.
        Console.WriteLine("Test 1");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 0);
        var queueString = priorityQueue.ToString();
        Console.WriteLine(queueString);
        Trace.Assert(queueString == "[First (Pri:10), Second (Pri:5), Third (Pri:0)]", "_queue string doesn't match");

        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Dequeue should remove the item with the highest priority and return its value
        // Expected Result: Regardless of its position in the queue, "First" should be returned and removed first due to its high priority (10)
        Console.WriteLine("Test 2");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 0);
        var result = priorityQueue.Dequeue();
        // Check that "First" is returned first
        Console.WriteLine(result);
        Trace.Assert(result == "First", "The item with the highest priority ('First': 10) was not returned first" );
        // Check that "First" is removed first
        queueString = priorityQueue.ToString();
        Console.WriteLine(queueString);
        Trace.Assert(queueString == "[Second (Pri:5), Third (Pri:0)]", "_queue string should be [Second (Pri:5), Third (Pri:0)]");

        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 0);
        priorityQueue.Enqueue("First", 10);
        result = priorityQueue.Dequeue();
        // Check that "First" is returned first
        Console.WriteLine(result);
        Trace.Assert(result == "First", "The item with the highest priority ('First': 10) was not returned first" );
        // Check that "First" is removed first
        queueString = priorityQueue.ToString();
        Console.WriteLine(queueString);
        Trace.Assert(queueString == "[Second (Pri:5), Third (Pri:0)]", "_queue string doesn't match");

        // Defect(s) Found: Dequeue(): Changed starting index to 0, Removed -1 after _queue.Count that was preventing the loop from reaching
        // the end of the queue, Added a line of code to remove the highest priority item after saving its value to a variable.

        Console.WriteLine("---------");

        // Test 3
        // Scenario: If two items have the same entry, the one that was added to the queue first should be removed first
        // Expected Result: 
        Console.WriteLine("Test 3");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        result = priorityQueue.Dequeue();
        Console.WriteLine($"Returned: {result}");
        Trace.Assert(result == "First", "With two entries of the same priority, the first entry added was not returned first.");

        // Defect(s) Found: Dequeue(): Changed >= to > so that the highValueIndex of numbers closer to the front of the queue will not be overwritten by those of the same priority

        Console.WriteLine("---------");

        // Test 4
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 4");
        priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();

        // Defect(s) Found: None
    }
}