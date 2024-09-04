namespace ola_sq_a1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Test CreateTask
        TaskFacade taskFacade = new TaskFacade();
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now, false, "Test");
        Assert.Equal("Test", task.Description);
        Assert.Equal(now, task.Deadline);
        Assert.False(task.IsFinished);
        Assert.Equal("Test", task.Category);
    }

    [Fact]
    public void Test2()
    {
        //Test UpdateTask
        TaskFacade taskFacade = new TaskFacade();
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now, false, "Test");
        task = taskFacade.UpdateTask(task, "Test2", now, true, "Test2");
        Assert.Equal("Test2", task.Description);
        Assert.Equal(now, task.Deadline);
        Assert.True(task.IsFinished);
        Assert.Equal("Test2", task.Category);
    }

    [Fact]
    public void Test3()
    {
        //Test MarkAsFinished
        TaskFacade taskFacade = new TaskFacade();
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now, false, "Test");
        task = taskFacade.MarkAsFinished(task);
        Assert.True(task.IsFinished);
    }

    [Fact]
    public void Test4()
    {
        //Test MarkAsUnfinished
        TaskFacade taskFacade = new TaskFacade();
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now, true, "Test");
        task = taskFacade.MarkAsUnfinished(task);
        Assert.False(task.IsFinished);
    }




}