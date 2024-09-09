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
    
    [Fact]
    public void ShouldReturnTrueIfTaskIsOverdueAndNotFinished()
    {
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now.AddMinutes(-1), false, "Test");
        Assert.True(taskFacade.IsOverdue(task));
    }
    
    [Fact]
    public void ShouldReturnFalseIfTaskIsNotOverdueAndNotFinished()
    {
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now.AddMinutes(1), false, "Test");
        Assert.False(taskFacade.IsOverdue(task));
    }
    
    [Fact]
    public void ShouldReturnFalseIfTaskIsOverdueAndFinished()
    {
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now.AddMinutes(-1), true, "Test");
        Assert.False(taskFacade.IsOverdue(task));
    }
    
    [Fact]
    public void ShouldReturnFalseIfNotOverdueAndFinished()
    {
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now.AddMinutes(1), true, "Test");
        Assert.False(taskFacade.IsOverdue(task));
    }
    
}