using Microsoft.EntityFrameworkCore;

namespace ola_sq_a1;

public class SpecificationTests
{
    private TaskFacade taskFacade;

    public SpecificationTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var context = new ApplicationDbContext(options);
        taskFacade = new TaskFacade(context);
    }
    
    //Specification based test for IsOverdue
    [Fact]
    public void ShouldReturnTrueIfTaskIsOverdue()
    {
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now.AddMinutes(-1), false, "Test");
        Assert.True(taskFacade.IsOverdue(task));
    }
    
    [Fact]
    public void ShouldReturnFalseIfTaskIsNotOverdue()
    {
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now.AddMinutes(1), false, "Test");
        Assert.False(taskFacade.IsOverdue(task));
    }
    
    [Fact]
    public void ShouldReturnFalseIfTaskIsFinished()
    {
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now.AddMinutes(-1), true, "Test");
        Assert.False(taskFacade.IsOverdue(task));
    }
    
}