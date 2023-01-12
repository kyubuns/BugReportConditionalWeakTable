using System.Runtime.CompilerServices;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Person[] _people;
    private ConditionalWeakTable<Person, string> _locations;

    public void Start()
    {
        _people = new[]
        {
            new Person { Id = 1, Name = "Jurian Naul" },
            new Person { Id = 2, Name = "Thomas Bent" },
            new Person { Id = 3, Name = "Ellen Carson" },
            new Person { Id = 4, Name = "Katrina Lauran" },
            new Person { Id = 5, Name = "Monica Ausbach" },
        };

        _locations = new ConditionalWeakTable<Person, string>();

        _locations.Add(_people[0], "Shinon");
        _locations.Add(_people[1], "Lance");
        _locations.Add(_people[2], "Pidona");
        _locations.Add(_people[3], "Loanne");
        _locations.Add(_people[4], "Loanne");
    }

    void Update()
    {
        var a = new Person { Id = UnityEngine.Random.Range(0, 100000), Name = $"{UnityEngine.Random.Range(0, 100000)}" };
        _locations.Add(a, "Test");

        Debug.Log($"{Time.frameCount}");
        foreach (var p in _people)
        {
            if (_locations.TryGetValue(p, out var location))
            {
                Debug.Log(p.Name + " at " + location);
            }
        }
    }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}
