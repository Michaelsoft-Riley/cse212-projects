using System.Diagnostics;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: User tries to give a max Customer Service Queue size <= 0
        // Expected Result: Queue size defaults to 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        Trace.Assert(cs._maxSize == 10, "_maxSize should be 10");
        cs = new CustomerService(-1);
        Trace.Assert(cs._maxSize == 10, "_maxSize should be 10");

        // Defect(s) Found: None
        Console.WriteLine("=================");

        // Test 2
        // Scenario: AddNewCustomer is called
        // Expected Result: A new customer is enqueued
        Console.WriteLine("Test 2");
        cs = new CustomerService(1);
        cs.AddNewCustomer();
        Trace.Assert(cs._queue.Count == 1, "Customer was not added to queue");

        // Defect(s) Found: None
        Console.WriteLine("=================");

        // Test 3
        // Scenario: Queue is full and user attempts to add a customer
        // Expected Result: An error message is displayed at the second new customer
        Console.WriteLine("Test 3");
        cs = new CustomerService(1);
        cs.AddNewCustomer();
        cs.AddNewCustomer();

        // Defect(s) Found: changed > to >= so that it doesn't cause an index range error
        Console.WriteLine("=================");

        // Test 4
        // Scenario: ServeCustomer is called
        // Expected Result: ServeCustomer dequeues the next customer and displays details
        Console.WriteLine("Test 4");
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.ServeCustomer();
        cs.ServeCustomer();
        Trace.Assert(cs._queue.Count == 0, "Queue is not empty. Something went wrong.");

        // Defect(s) Found: customer was being removed from queue before being used
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Queue is empty and ServeCustomer is called
        // Expected Result: Error message is displayed
        Console.WriteLine("Test 5");
        cs = new CustomerService(1);
        cs.ServeCustomer();

        // Defect(s) Found: ServeCustomer was not checking whether queue was empty
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("Queue is empty");
        }
        else
        {
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}