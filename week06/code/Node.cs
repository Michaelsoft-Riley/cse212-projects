public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        // Don't Insert if the value has already been added
        if (value == Data)
            return;
        if (value < Data) {
            // Insert to the left if Data hasn't been inserted yet
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else {
            // Insert to the right if Data hasn't been inserted yet
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) {
        // return true if value is found
        if (value == Data)
            return true;
        if (value < Data) {
            // return false if value is not found
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else {
            // return false if value is not found
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight() {
        // TODO Start Problem 4
        if (this is null) {
            return 0;
        }
        else {
            int left = Left?.GetHeight() ?? 0;
            int right = Right?.GetHeight() ?? 0;
            if (left > right)
                return left + 1;
            else
                return right + 1;
        }
    }
}