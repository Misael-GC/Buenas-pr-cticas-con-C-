﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
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
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string ingresaNumero = Console.ReadLine();
            return Convert.ToInt32(ingresaNumero);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                TaskToDoList();
                
                string ingresaNumParaRemover = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(ingresaNumParaRemover) - 1;

                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                        string taskToRemove = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + taskToRemove + " eliminada");
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string newTask = Console.ReadLine();
                TaskList.Add(newTask);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                TaskToDoList();
            }
        }
        //separación ---------------------------------------------------------
        public static void TaskToDoList()
        {
            Console.WriteLine("----------------------------------------"); //reto hacer una función
            var indexTask = 1;
            TaskList.ForEach( p =>  Console.WriteLine(indexTask++ + ". " + p));
            // for (int i = 0; i < TaskList.Count; i++) se lelimna por el principio KISS
            // {
            //     Console.WriteLine((i + 1) + ". " + TaskList[i]);
            // }
            Console.WriteLine("----------------------------------------");
        }
    }
    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}
