using System;
using System.IO;

namespace assignment10
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Choose an operation: ");
                Console.WriteLine("1.Create");
                Console.WriteLine("2.Read");
                Console.WriteLine("3.Append");
                Console.WriteLine("4.Delete");
                Console.WriteLine("5.Exit");
                Console.WriteLine("\nEnter your choice from the above option:");

                int choice = GetChoiceFromUser();

                switch (choice)
                {
                    case 1:
                        CreateFile();
                        break;
                    case 2:
                        ReadFile();
                        break;
                    case 3:
                        AppendToFile();
                        break;
                    case 4:
                        DeleteFile();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice!! Please try again");
                        break;
                }
            }
        }

        static int GetChoiceFromUser()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input!! Please enter a valid choice");
            }
            return choice;
        }

        static void CreateFile()
        {
            Console.WriteLine("Enter the file name: ");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter the content: ");
            string content = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(content);
                }
                Console.WriteLine($"File '{fileName}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating the file: {ex.Message}");
            }
        }

        static void ReadFile()
        {
            Console.WriteLine("Enter the file name to read: ");
            string fileName = Console.ReadLine();

            try
            {
                string content = File.ReadAllText(fileName);
                Console.WriteLine($"Content of '{fileName}':\n{content}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        static void AppendToFile()
        {
            Console.WriteLine("Enter the file name to append: ");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter the content to append: ");
            string contentToAppend = Console.ReadLine();

            try
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.Write(contentToAppend);
                }
                Console.WriteLine($"Content appended to '{fileName}' successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to the file: {ex.Message}");
            }
        }

        static void DeleteFile()
        {
            Console.WriteLine("Enter the file name to delete: ");
            string fileName = Console.ReadLine();

            try
            {
                File.Delete(fileName);
                Console.WriteLine($"File '{fileName}' deleted successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting the file: {ex.Message}");
            }
        }
    }
}
