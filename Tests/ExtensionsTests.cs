using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Xelareip;

public class ExtensionsTests
{
    [Test]
    public void IsNullOrEmpty()
    {
        string emptyString = "";
        string nullString = null;
        const string normalString = "Foo";

        Assert.That(string.IsNullOrEmpty(emptyString) == emptyString.IsNullOrEmpty());
        Assert.That(string.IsNullOrEmpty(nullString) == nullString.IsNullOrEmpty());
        Assert.That(string.IsNullOrEmpty(normalString) == normalString.IsNullOrEmpty());
    }
    
    [Test]
    public void RandomizeList()
    {
        const int testCount = 100; 
        List<int> List0 = new List<int>();
        List<int> List1 = new List<int>();
        List<int> List2 = new List<int>();
        
        for (int i = 0; i < testCount; ++i)
        {
            List0.Add(i);
            List1.Add(i);
            List2.Add(i);
        }
        
        List0.Randomize();
        List1.Randomize();
        List2.Randomize();

        Assert.AreEqual(List0.Count, testCount);
        Assert.AreEqual(List1.Count, testCount);
        Assert.AreEqual(List2.Count, testCount);

        float result = 0f;
        for (int i = 0; i < testCount; ++i)
        {
            if (List0[i] == i)
            {
                ++result;
            }
            if (List1[i] == i)
            {
                ++result;
            }
            if (List2[i] == i)
            {
                ++result;
            }
        }

        result /= testCount * 3f;
        
        Assert.That(result < 0.05f);
    }
}
