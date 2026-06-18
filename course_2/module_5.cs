namespace Course2.Modules
{
    class LibraryProject
    {

        public static void Run()
        {
            Dictionary<string, bool> libraryCollection = new Dictionary<string, bool>()
            {
                { "the hobbit", false },
                { "1984", false },
                { "the great gatsby", false },
                { "to kill a mockingbird", false }
            };

        int borrowedCount = 0;

        while(true)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine("    LIBRARY MANAGEMENT MENU      ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Search for a Book");
                Console.WriteLine("2. Borrow a Book");
                Console.WriteLine("3. Return a Book");
                Console.WriteLine("4. Exit Program");
                Console.Write("Please enter your choice (1-4): ");

                string choice = Console.ReadLine().Trim().ToLower();

                if (choice == "1")
                {
                    Console.Write("Enter the name of the book to search for: ");
                    string searchQuery = Console.ReadLine().Trim().ToLower();


                    /* Checks for book in the collection */
                    if(libraryCollection.ContainsKey(searchQuery))
                    {

                        /* If found, checks if the book is available or borrowed */
                        if(libraryCollection[searchQuery] == false)
                        {
                            Console.WriteLine($"'{searchQuery}' is available for borrowing.");
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, '{searchQuery}' is currently borrowed.");
                        }
                    }

                    /* Book not found */
                    else
                    {
                        Console.WriteLine($"Sorry, '{searchQuery}' is not in our collection.");
                    }
                }

                else if (choice == "2")
                {

                    /* Checks the borrow limit */
                    if (borrowedCount >= 3)
                    {
                        Console.WriteLine("-> Access Denied: You cannot borrow more books. You have reached your limit of 3 books!");
                    }

                    // Prompt the user for the book they want to borrow
                    else
                    {
                        Console.Write("Enter the title of the book you want to borrow: ");
                        string borrowTitle = Console.ReadLine().Trim().ToLower();

                        // Check if the book exists in the library
                        if(libraryCollection.ContainsKey(borrowTitle))
                        {

                            // Check if the book is already flagged as checked out
                            if(libraryCollection[borrowTitle] == true)
                            {
                                Console.WriteLine($"-> Error: Sorry, '{borrowTitle}' is already checked out.");
                            }
                            else
                            {
                                libraryCollection[borrowTitle] = true;
                                borrowedCount++;
                                Console.WriteLine($"-> Success: You have successfully borrowed '{borrowTitle}'.");
                                Console.WriteLine($"   (You currently have {borrowedCount}/3 books borrowed)");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"-> Error: '{borrowTitle}' is not in the collection.");
                        }
                    }
                }
                else if (choice == "3")
                {
                    // Prompt the user for the book they want to return
                    Console.Write("Enter the title of the book you want to return: ");
                    string returnTitle = Console.ReadLine().Trim().ToLower();

                    // Check if the book belongs to the library collection
                    if (libraryCollection.ContainsKey(returnTitle))
                    {
                        // Check if the book is actually flagged as checked out (true)
                        if (libraryCollection[returnTitle] == true)
                        {
                            libraryCollection[returnTitle] = false;
                            borrowedCount--;
                            Console.WriteLine($"-> Success: You have successfully checked in '{returnTitle}'.");
                            Console.WriteLine($"   (You currently have {borrowedCount}/3 books borrowed)");
                        }
                        else
                        {
                            Console.WriteLine($"-> Notice: '{returnTitle}' is already sitting on the shelf!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"-> Error: '{returnTitle}' does not belong to this library collection.");
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Thank you for using the Library Management System. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("-> Invalid input. Please type a number from 1 to 4.");
                }
            }

            





        }
    }
}