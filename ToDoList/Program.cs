namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ToDo = new List<string>();
            List<string> DoneTasks = new List<string>();
            while (true)
            {
                PrintMenuOptions();
                int intMenuOption;
                bool isInt;
                CheckIfMenuOptionIsValid(out intMenuOption, out isInt);
                if (isInt)
                {
                    ChooseAndExecuteMenuOption(ToDo, DoneTasks, intMenuOption);
                }
                else
                {
                    PrintInvalidOption();
                }
            }
        }

        private static void CheckIfMenuOptionIsValid(out int intMenuOption, out bool isInt)
        {
            string menuOption = Console.ReadLine();
            isInt = int.TryParse(menuOption, out intMenuOption);
        }

        private static void ChooseAndExecuteMenuOption(List<string> ToDo, List<string> DoneTasks, int intMenuOption)
        {
            switch (intMenuOption)
            {
                case 1:
                    AddTask(ToDo);
                    break;

                case 2:
                    MarkTaskAsDone(ToDo, DoneTasks);
                    break;

                case 3:
                    RemoveTask(ToDo);
                    break;

                case 4:
                    PrintDoneTasks(DoneTasks);
                    break;

                case 5:
                    PrintCurrentTasks(ToDo, DoneTasks);
                    break;

                case 6:
                    ClearTasksOrDont(ToDo);
                    break;

                case 7:
                    ExitProgramOrDont();
                    break;

                default:
                    PrintInvalidOption();
                    break;
            }
        }

        private static void PrintInvalidOption()
        {
            Console.WriteLine("Please enter a valid option!");
        }

        private static void ExitProgramOrDont()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Are you sure? All of your tasks will be lost! Y/N");
            string exitOption = Console.ReadLine();
            if (exitOption == "Y")
            {
                Console.WriteLine("OK, goodbye! :(");
                Console.ForegroundColor = ConsoleColor.White;
                System.Environment.Exit(0);
            }
            else if (exitOption == "N")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Action reversed! You are still here :)");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ClearTasksOrDont(List<string> ToDo)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Are you sure you want to do this? All of your tasks would be lost FOREVER! Y/N");
            string clearOption = Console.ReadLine();
            if (clearOption == "Y")
            {
                ToDo.Clear();
                Console.WriteLine("Your tasks have been cleared!");
                Console.ForegroundColor = ConsoleColor.White; ;
            }
            else if (clearOption == "N")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Your tasks are still safe!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void PrintCurrentTasks(List<string> ToDo, List<string> DoneTasks)
        {
            if (ToDo.Count == 0)
            {
                Console.WriteLine("No current tasks!");
            }
            else
            {
                Console.WriteLine("Current tasks:");
                for (int i = 0; i < ToDo.Count; i++)
                {
                    if (DoneTasks.Contains(ToDo[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{i + 1}. {ToDo[i]} (done)");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {ToDo[i]}");
                    }
                }
            }
        }

        private static void PrintDoneTasks(List<string> DoneTasks)
        {
            for (int i = 0; i < DoneTasks.Count; i++)
            {
                Console.WriteLine("Current done tasks:");
                Console.WriteLine(DoneTasks[i]);
            }
        }

        private static void RemoveTask(List<string> ToDo)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please insert the position of the task you would like to remove:");
            Console.Write("-");
            int removeTaskIndex = int.Parse(Console.ReadLine());
            ToDo.RemoveAt(removeTaskIndex - 1);
            Console.WriteLine("Task removed!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void MarkTaskAsDone(List<string> ToDo, List<string> DoneTasks)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please insert the position of the task you would like to be marked as done:");
            int doneTaskIndex = int.Parse(Console.ReadLine());
            string taskToBeDone = ToDo[doneTaskIndex - 1];
            Console.WriteLine(taskToBeDone);
            DoneTasks.Add(taskToBeDone);
            Console.WriteLine("Task added as done!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void AddTask(List<string> ToDo)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What task would you like to add?");
            Console.Write("+");
            string task = Console.ReadLine();
            ToDo.Add(task);
            Console.WriteLine("Task added!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintMenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Menu:                      ");
            Console.WriteLine("1. Add task                ");
            Console.WriteLine("2. Mark task as done       ");
            Console.WriteLine("3. Remove task             ");
            Console.WriteLine("4. Check done tasks        ");
            Console.WriteLine("5. Check tasks             ");
            Console.WriteLine("6. Clear all tasks         ");
            Console.WriteLine("7. Exit program :(         ");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}