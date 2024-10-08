﻿using Microsoft.EntityFrameworkCore;

namespace ola_sq_a1;

public class IntegrationTests
{
    
    //Mocking the database
    
    public IntegrationTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var context = new ApplicationDbContext(options);
        taskMapper = new TaskMapper(context);
        taskFacade = new TaskFacade(context);
    }
    
    private TaskMapper taskMapper;
    private TaskFacade taskFacade;
    
    [Fact]
    public void ShouldCreateAndPersistTask()
    {
        //Test CreateTask
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now, false, "Test");
        taskMapper.AddTask(task);
        Task taskFromDb = taskMapper.GetTaskById(task.Id);
        Assert.Equal("Test", taskFromDb.Description);
        Assert.Equal(now, taskFromDb.Deadline);
        Assert.False(taskFromDb.IsFinished);
        Assert.Equal("Test", taskFromDb.Category);
    }
    
    [Fact]
    public void ShouldUpdateAndPersistTask()
    {
        //Test UpdateTask
        DateTime now = DateTime.Now;
        Task task = taskFacade.CreateTask("Test", now, false, "Test");
        taskMapper.AddTask(task);
        Task taskFromDb = taskMapper.GetTaskById(task.Id);
        task = taskFacade.UpdateTask(taskFromDb, "Test2", now, true, "Test2");
        taskMapper.UpdateTask(task);
        Task updatedTask = taskMapper.GetTaskById(task.Id);
        Assert.Equal("Test2", updatedTask.Description);
        Assert.Equal(now, updatedTask.Deadline);
        Assert.True(updatedTask.IsFinished);
        Assert.Equal("Test2", updatedTask.Category);
    }
    
}