using System;
using System.Collections.Generic;

namespace ola_sq_a1
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskFacade taskFacade = new TaskFacade();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Task Manager");
                Console.WriteLine("============");
                Console.WriteLine("1. Add a new Task");
                Console.WriteLine("2. View all Tasks");
                Console.WriteLine("3. Update a Task");
                Console.WriteLine("4. Mark a Task as Finished");
                Console.WriteLine("5. Mark a Task as Unfinished");
                Console.WriteLine("6. Delete a Task");
                Console.WriteLine("7. View a Task by ID");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Select an option: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewTask(taskFacade);
                        break;
                    case "2":
                        ViewAllTasks(taskFacade);
                        break;
                    case "3":
                        UpdateTask(taskFacade);
                        break;
                    case "4":
                        MarkTaskAsFinished(taskFacade);
                        break;
                    case "5":
                        MarkTaskAsUnfinished(taskFacade);
                        break;
                    case "6":
                        DeleteTask(taskFacade);
                        break;
                    case "7":
                        ViewTaskById(taskFacade);
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddNewTask(TaskFacade taskFacade)
        {
            Console.WriteLine("Enter description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter deadline (yyyy-mm-dd): ");
            DateTime deadline = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Is the task finished? (true/false): ");
            bool isFinished = bool.Parse(Console.ReadLine());
            Console.WriteLine("Enter category: ");
            string category = Console.ReadLine();

            Task task = taskFacade.AddTask(description, deadline, isFinished, category);
            Console.WriteLine("Task added successfully!");
        }

        static void ViewAllTasks(TaskFacade taskFacade)
        {
            List<Task> tasks = taskFacade.GetAllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Deadline: {task.Deadline}, Finished: {task.IsFinished}, Category: {task.Category}");
            }
        }

        static void UpdateTask(TaskFacade taskFacade)
        {
            Console.WriteLine("Enter the Task ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Task task = taskFacade.GetTaskById(id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine("Enter new description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter new deadline (yyyy-mm-dd): ");
            DateTime deadline = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Is the task finished? (true/false): ");
            bool isFinished = bool.Parse(Console.ReadLine());
            Console.WriteLine("Enter new category: ");
            string category = Console.ReadLine();

            taskFacade.UpdateTask(task, description, deadline, isFinished, category);
            taskFacade.SaveTask(task);
            Console.WriteLine("Task updated successfully!");
        }

        static void MarkTaskAsFinished(TaskFacade taskFacade)
        {
            Console.WriteLine("Enter the Task ID to mark as finished: ");
            int id = int.Parse(Console.ReadLine());

            Task task = taskFacade.GetTaskById(id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            taskFacade.MarkAsFinished(task);
            taskFacade.SaveTask(task);
            Console.WriteLine("Task marked as finished!");
        }

        static void MarkTaskAsUnfinished(TaskFacade taskFacade)
        {
            Console.WriteLine("Enter the Task ID to mark as unfinished: ");
            int id = int.Parse(Console.ReadLine());

            Task task = taskFacade.GetTaskById(id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            taskFacade.MarkAsUnfinished(task);
            taskFacade.SaveTask(task);
            Console.WriteLine("Task marked as unfinished!");
        }

        static void DeleteTask(TaskFacade taskFacade)
        {
            Console.WriteLine("Enter the Task ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Task task = taskFacade.GetTaskById(id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            taskFacade.DeleteTask(task);
            Console.WriteLine("Task deleted successfully!");
        }

        static void ViewTaskById(TaskFacade taskFacade)
        {
            Console.WriteLine("Enter the Task ID to view: ");
            int id = int.Parse(Console.ReadLine());

            Task task = taskFacade.GetTaskById(id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Deadline: {task.Deadline}, Finished: {task.IsFinished}, Category: {task.Category}");
        }
    }
}
