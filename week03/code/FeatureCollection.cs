using System.ComponentModel.DataAnnotations;

public class FeatureCollection {
    // Todo Earthquake Problem - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> Features { get; set; }
    public void Display() {
        foreach (var feature in Features) {
            feature.properties.Display();
        }
    }
}

public class Feature {
    public Properties properties { get; set; }
}

public class Properties {
    public string Place { get; set; }
    public double Mag { get; set; }

    public void Display() {
        Console.WriteLine($"{Place} - Mag {Mag}");
    }
}