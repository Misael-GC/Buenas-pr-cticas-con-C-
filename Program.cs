

List<string> TaskList = new List<string>();


int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

/// <summary>
/// Show the options for tasks, 1. Nueva tarea
/// </summary>
/// <returns>Returns option selected by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string ingresaNumero = Console.ReadLine();
    return Convert.ToInt32(ingresaNumero);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        
        TaskToDoList();

        string ingresaNumParaRemover = Console.ReadLine();
        // Remove one position because thhe array starts in 0
        int indexToRemove = Convert.ToInt32(ingresaNumParaRemover) - 1;
        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
            Console.WriteLine("Número de tarea seleccionado no es valido");
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }

    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea ");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string newTask = Console.ReadLine();

        if (newTask.Length == 0)
            Console.WriteLine("No ingresaste nada :0");
        else
        {
            TaskList.Add(newTask);
            Console.WriteLine("Tarea registrada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al ingresar el nombre de la tarea ");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        TaskToDoList();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

//separación ---------------------------------------------------------
void TaskToDoList()
{
    Console.WriteLine("----------------------------------------"); //reto hacer una función
    var indexTask = 1;
    TaskList.ForEach(task => Console.WriteLine($"{indexTask++} . {task}"));
    // for (int i = 0; i < TaskList.Count; i++) se elimina por el principio KISS
    // {
    //     Console.WriteLine((i + 1) + ". " + TaskList[i]);
    // }
    Console.WriteLine("----------------------------------------");
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}

