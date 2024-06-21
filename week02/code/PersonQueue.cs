/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue {
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person) {
        _queue.Insert(0, person);
    }

    public Person Dequeue() {
        var person = _queue[^1];
        _queue.RemoveAt(Length-1);

        // Enqueue if person gets infinite turns (represented as 0 or less turns)
        if (person.Turns <= 0) {
            Enqueue(person);
        }

        return person;
    }

    public bool IsEmpty() {
        return Length == 0;
    }

    public override string ToString() {
        return $"[{string.Join(", ", _queue)}]";
    }
}