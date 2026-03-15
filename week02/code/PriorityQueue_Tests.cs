using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: create a priority queue with the following items: purple (7), green (2), yellow (5), orange (3), pink (5)
    // run until the queue is empty
    // Expected Result: purple, yellow, pink, orange, green
    // Defect(s) Found: PriorityQueue.Dequeue() does not remove item from list. inaccurate for loop and if statement condition in PriorityQueue.Dequeue()
    public void TestPriorityQueue_1()
    {
        
        var purple = new PriorityItem("purple", 7);
        var green = new PriorityItem("green", 2);
        var yellow = new PriorityItem("yellow", 5);
        var orange = new PriorityItem("orange", 3);
        var pink = new PriorityItem("pink", 5);

        PriorityItem[] expectedResult = [purple, yellow, pink, orange, green];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(purple.Value, purple.Priority);
        priorityQueue.Enqueue(green.Value, green.Priority);
        priorityQueue.Enqueue(yellow.Value, yellow.Priority);
        priorityQueue.Enqueue(orange.Value, orange.Priority);
        priorityQueue.Enqueue(pink.Value, pink.Priority);

        foreach (var expectedItem in expectedResult)
        {
            var nextItem = priorityQueue.Dequeue();
            Assert.AreEqual(expectedItem.Value, nextItem);
        }
    }

    [TestMethod]
    // Scenario: Try get the next item from an empty queue
    // Expected Result: InvalidOperationException should be thrown with a message of "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        try 
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown");
        }
        catch (InvalidOperationException e) 
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}