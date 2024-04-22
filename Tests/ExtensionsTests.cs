using System.Collections.Generic;
using NUnit.Framework;
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
        // ReSharper disable once ExpressionIsAlwaysNull
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        Assert.That(string.IsNullOrEmpty(nullString) == nullString.IsNullOrEmpty());
        Assert.That(string.IsNullOrEmpty(normalString) == normalString.IsNullOrEmpty());
    }
    
    [Test]
    public void RandomizeList()
    {
        const int testCount = 100; 
        List<int> list0 = new List<int>();
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        
        for (int i = 0; i < testCount; ++i)
        {
            list0.Add(i);
            list1.Add(i);
            list2.Add(i);
        }
        
        list0.Randomize();
        list1.Randomize();
        list2.Randomize();

        Assert.AreEqual(list0.Count, testCount);
        Assert.AreEqual(list1.Count, testCount);
        Assert.AreEqual(list2.Count, testCount);

        float result = 0f;
        for (int i = 0; i < testCount; ++i)
        {
            if (list0[i] == i)
            {
                ++result;
            }
            if (list1[i] == i)
            {
                ++result;
            }
            if (list2[i] == i)
            {
                ++result;
            }
        }

        result /= testCount * 3f;
        
        Assert.That(result < 0.05f);
    }
}
