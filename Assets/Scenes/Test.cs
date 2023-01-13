using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Test : MonoBehaviour
{
    private readonly List<int[]> _keys = new List<int[]>();
    private readonly ConditionalWeakTable<int[], object> _test = new ConditionalWeakTable<int[], object>();

    public void Update()
    {
        Debug.Log($"== {Time.frameCount}");

        for (var k = 0; k < 1000; ++k)
        {
            var i = Random.Range(0, 10000000);
            Add(new[] { i }, new TypeA { Name = $"Test{i}" });
        }

        for (var k = 0; k < 10; ++k)
        {
            var i = _keys[Random.Range(0, _keys.Count)];
            var b = (TypeA) _test.GetValue(i, _ => null);
            Debug.Log($"{b?.Name}");
        }
    }

    private void Add(int[] i, object o)
    {
        _test.Add(i, o);
        _keys.Add(i);
    }
}

public class TypeA
{
    public string Name { get; set; }
}

