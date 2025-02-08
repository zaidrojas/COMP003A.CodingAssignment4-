/*
 Author: Zaid Rojas
 Course: COMP-003A
 Faculty: Jonathan Cruz
 Purpose: Inventory management application with a minimum of 10
*/

using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace COMP003A.CodingAssignment4
{
    internal class Program
    {
        static void AddingProduct(ref string[] name_array, ref int[] quantity_array, ref int array_length)
        {
            int val; // value of product to be added

            if (array_length == 10) // Should the Array Be Full
            {
                Console.WriteLine("Inventory is full. Cannot add more products!");
                return;
            }

            Console.Write("\nEnter Product Name: ");
            var _name = Console.ReadLine();
            Console.Write("Enter Product Quantity: ");
            try
            {
                val = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid int value.");
                return;
            }

            name_array[array_length] = _name.ToLower();
            quantity_array[array_length] = val;
            array_length++;


            Console.WriteLine("Product Added Successfully!\n");
        }

        static void UpdateProduct(ref string[] array_name, ref int[] array_quantity)
        {
            string find_product;
            int new_amount;

            Console.Write("\nEnter Product Name: ");
            find_product = Console.ReadLine().ToLower();

            int location = Array.IndexOf(array_name, find_product);
            if (location < 0)
            {
                Console.WriteLine($"Item {find_product} is not in list.\n");
                return;
            }
            else
            {
                Console.Write($"Enter the current quantity of the {find_product}: ");
                new_amount = int.Parse(Console.ReadLine());
                array_quantity[location] = new_amount;
                Console.WriteLine("Update Successful!\n");
            }
            

        }

        static void InventorySummary(ref string[] array_name, ref int[] array_quantity, ref int array_length)
        {
            int total_prod = 0;
            int total_quant = 0;

            Console.WriteLine("\nInventory Summary: ");

            for (var i = 0; i < array_length; i++)
            {
                Console.WriteLine($"- {array_name[i]} {array_quantity[i]}");
                total_prod++;
                total_quant += array_quantity[i];
            }

            Console.WriteLine($"Total Products: {total_prod}");
            Console.WriteLine($"Total Quantity: {total_quant}");
            try
            {
                Console.WriteLine($"Average Quantity: {total_quant / total_prod}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You attempted to divide by 0.\n");
                return;
            }
        }


        static void Main(string[] args)
        {
                int prod_choice; // Decides how the arrays or lists will be edited
                string handling; // Determines if we are handling the list or arrays
                                 // Products in arrays
                string[] prod_array_name = new string[10];
                int[] prod_array_quantity = new int[10];
                int array_len = 0; // Determines addition location
                                   // Products in list
                List<string> prod_list_name = new List<string>();
                List<int> prod_list_quantity = new List<int>();

                while (true)
                {
                    static string Introduction()
                    {
                        while (true)
                        {
                            int storeage_choice;

                            // Introduction
                            Console.WriteLine("Welcome to the Inventory Management System!");
                            Console.WriteLine("Choose data storage type:");
                            Console.WriteLine("1. Arrays");
                            Console.WriteLine("2. Lists");
                            Console.Write("Enter your choice: ");
                            if (!int.TryParse(Console.ReadLine(), out storeage_choice))
                            {
                                Console.WriteLine("**Invalid input. Please enter a valid number.**\n");
                                continue;
                            }

                            switch (storeage_choice)
                            {
                                case 1:
                                    return "Arrays";
                                case 2:
                                    Console.WriteLine("Program currently has no lists support.\n");
                                    continue;
                            default:
                                    Console.WriteLine("**Enter either numbers 1 or 2.**\n");
                                    continue;
                            }
                        }
                    }

                    // Do the introduction then determine wheither it will be affecting the array or list variables
                    if (Introduction() == "Arrays")
                    {
                        handling = "Arrays";
                    }
                    else
                    {
                        handling = "Lists";
                    }

                    while (true) //After List/Array has been chosen
                    {


                        // Determine how the list/array will be affected
                        Console.WriteLine("\n--Inventory Management System Menu--");
                        Console.WriteLine("1. Add a product");
                        Console.WriteLine("2. Update Product Quantity");
                        Console.WriteLine("3. View Inventory Summary");
                        Console.WriteLine("4. Exit");
                        Console.Write("Enter your choice: ");
                        try { prod_choice = int.Parse(Console.ReadLine()); }
                        catch (Exception)
                        {
                            Console.WriteLine("**Invalid input. Please enter a valid number.**\n");
                            continue;
                        }

                        
                        // Deciding how the ARRAYS will be handled
                        switch (prod_choice)
                        {
                            case 1: // Adding product
                                AddingProduct(ref prod_array_name, ref prod_array_quantity, ref array_len);
                                break;

                            case 2: // Updating Product Quantity
                                UpdateProduct(ref prod_array_name, ref prod_array_quantity);
                                break;

                            case 3: // View Inventory Summary
                                InventorySummary(ref prod_array_name, ref prod_array_quantity, ref array_len);
                                break;

                            case 4: // Exit the Program
                                Console.WriteLine("Goodbye!\n");
                                goto Exit;
                                break;

                            default:
                                Console.WriteLine("**Invalid input. Enter numbers 1-4**\n");
                                continue;
                        }

                    }
            Exit:
                break;
            }
        }
    }
}
