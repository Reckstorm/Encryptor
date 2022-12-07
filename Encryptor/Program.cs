using Encryptor.Sources.Users;
using Encryptor;
using Encryptor.Sources.Notes;

User temp = new User();
string tempStr;
ConsoleKeyInfo key;
using (UserList Users = FileController.GetInstance().ReadInfo())
{
    do
    {
        Console.Clear();
        Console.WriteLine("1 - Register\n2 - Login\nEsc - Exit");
        key = Console.ReadKey(true);
        if (key.KeyChar == '1')
        {
            Console.Clear();
            Console.Write("Enter Login:");
            temp.Login = Console.ReadLine().ToLower();
            Console.Write("Enter Password:");
            temp.Password = StringEncryptor.SimpleEnc(Console.ReadLine());
            if (Users.LoginCheck(temp.Login))
            {
                Console.WriteLine("User already exists");
                Console.ReadKey(true);
            }
            else
            {
                Users.Add(temp);
                temp = new User();
                Console.WriteLine("Registration successful");
                Console.ReadKey(true);
            }
            
        }
        else if (key.KeyChar == '2')
        {
            Console.Clear();
            Console.Write("Enter Login:");
            temp.Login = Console.ReadLine().ToLower();
            Console.Write("Enter Password:");
            temp.Password = StringEncryptor.SimpleEnc(Console.ReadLine());
            if (Users.LoginCheck(temp.Login))
            {
                if (Users.Find(temp).CompareTo(temp) == 0)
                {
                    int LoggedIn = Users.FindIndex(x => x.Login.Equals(temp.Login));
                    Console.WriteLine("Successfully logged in");
                    Console.ReadKey(true);
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Currently present {Users[LoggedIn].Notes.Count} note(s)");
                        Console.WriteLine("1 - Add note\n2 - Remove note\n3 - Edit note\n4 - Find notes by priority\n5 - Find duplicates by name\n6 - Sort notes by date\n7 - Read all notes\nEsc - exit");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '1')
                        {
                            Console.Clear();
                            Note tempNote = new Note();
                            Console.WriteLine("Enter Note title");
                            tempStr = Console.ReadLine();
                            tempNote.Title = tempStr;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Note priority:\n1 - Low\n2 - Medium\n3 - High");
                                key = Console.ReadKey(true);
                                if (key.KeyChar == '1')
                                {
                                    tempNote.Priority = "Low";
                                    Console.WriteLine("Success");
                                }
                                else if (key.KeyChar == '2')
                                {
                                    tempNote.Priority = "Medium";
                                    Console.WriteLine("Success");
                                }
                                else if (key.KeyChar == '3')
                                {
                                    tempNote.Priority = "High";
                                    Console.WriteLine("Success");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid command");
                                }
                                Console.ReadKey(true);
                            } while (tempNote.Priority == null);
                            Console.Clear();
                            Console.WriteLine("Enter Note body");
                            tempStr = Console.ReadLine();
                            tempNote.Body = tempStr;
                            Users[LoggedIn].Notes.Add(tempNote);
                            Console.Clear();
                            Console.WriteLine("Note Saved");
                            Console.ReadKey(true);
                        }
                        else if (key.KeyChar == '2')
                        {
                            Console.Clear();
                            Console.WriteLine("Enter note title you wish to remove");
                            tempStr = Console.ReadLine();
                            if (Users[LoggedIn].Notes.RemoveByTitle(tempStr))
                            {
                                Console.Clear();
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("No relevant notes found");
                            }
                            Console.ReadKey(true);
                        }
                        else if (key.KeyChar == '3')
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Enter note title you wish to edit");
                                tempStr = Console.ReadLine();
                                int tempIndex = Users[LoggedIn].Notes.FindIndexByTitle(tempStr);
                                if (tempIndex != -1)
                                {
                                    Console.Clear();
                                    Console.WriteLine(Users[LoggedIn].Notes[tempIndex]);
                                    Console.WriteLine("\n\nChoose what do you want to edit:\n1 - Title\n2 - Priority\n3 - Body");
                                    key = Console.ReadKey(true);
                                    if (key.KeyChar == '1')
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter new title");
                                        tempStr = Console.ReadLine();
                                        Users[LoggedIn].Notes[tempIndex].Title = tempStr;
                                        Console.WriteLine("Success");
                                    }
                                    else if (key.KeyChar == '2')
                                    {
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Enter Note priority:\n1 - Low\n2 - Medium\n3 - High");
                                            key = Console.ReadKey(true);
                                            if (key.KeyChar == '1')
                                            {
                                                Users[LoggedIn].Notes[tempIndex].Priority = "Low";
                                                Console.WriteLine("Success");
                                            }
                                            else if (key.KeyChar == '2')
                                            {
                                                Users[LoggedIn].Notes[tempIndex].Priority = "Medium";
                                                Console.WriteLine("Success");
                                            }
                                            else if (key.KeyChar == '3')
                                            {
                                                Users[LoggedIn].Notes[tempIndex].Priority = "High";
                                                Console.WriteLine("Success");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid value");
                                            }
                                        } while (Users[LoggedIn].Notes[tempIndex].Priority.Length == 0);
                                    }
                                    else if (key.KeyChar == '3')
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter new body");
                                        tempStr = Console.ReadLine();
                                        Users[LoggedIn].Notes[tempIndex].Body = tempStr;
                                        Console.WriteLine("Success");
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid command");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("No relevant notes found");
                                }
                                Console.ReadKey(true);
                                break;
                            } while (true);
                        }
                        else if (key.KeyChar == '4')
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Note priority you wish to view:\n1 - Low\n2 - Medium\n3 - High");
                                key = Console.ReadKey(true);
                                if (key.KeyChar == '1')
                                {
                                    if (Users[LoggedIn].Notes.FindPriority("Low").Count > 0)
                                    {
                                        Console.WriteLine("Relevant notes:\n");
                                        Users[LoggedIn].Notes.FindPriority("Low").ForEach(x => Console.WriteLine(x + "\n"));
                                    }
                                    else
                                    {
                                        Console.WriteLine("No relevant notes");
                                    }
                                }
                                else if (key.KeyChar == '2')
                                {
                                    if (Users[LoggedIn].Notes.FindPriority("Medium").Count > 0)
                                    {
                                        Console.WriteLine("Relevant notes:\n");
                                        Users[LoggedIn].Notes.FindPriority("Medium").ForEach(x => Console.WriteLine(x + "\n"));
                                    }
                                    else
                                    {
                                        Console.WriteLine("No relevant notes");
                                    }
                                }
                                else if (key.KeyChar == '3')
                                {
                                    if (Users[LoggedIn].Notes.FindPriority("High").Count > 0)
                                    {
                                        Console.WriteLine("Relevant notes:\n");
                                        Users[LoggedIn].Notes.FindPriority("High").ForEach(x => Console.WriteLine(x + "\n"));
                                    }                               
                                    else
                                    {
                                        Console.WriteLine("No relevant notes");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid value");
                                }
                                Console.ReadKey(true);
                                break;
                            } while (true);
                        }
                        else if (key.KeyChar == '5')
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Note title you wish to view:");
                            tempStr = Console.ReadLine();
                            if (Users[LoggedIn].Notes.FindDuplicates(tempStr).Count > 1)
                            {
                                Console.WriteLine("Relevant notes:\n");
                                Users[LoggedIn].Notes.FindDuplicates(tempStr).ForEach(x => Console.Write(x + "\n"));
                            }
                            else
                            {
                                Console.WriteLine("No duplicates");
                            }
                            Console.ReadKey(true);
                        }
                        else if (key.KeyChar == '6')
                        {
                            Console.Clear();
                            Users[LoggedIn].Notes.Sort();
                            Console.WriteLine("Success");
                            Console.ReadKey(true);
                        }
                        else if (key.KeyChar == '7')
                        {
                            Console.Clear();
                            Users[LoggedIn].Notes.ForEach(x => Console.WriteLine(x + "\n"));
                            Console.ReadKey(true);
                        }
                        else if (key.KeyChar == 27)
                        {
                            Console.Clear();
                            Console.WriteLine("Exiting...");
                            Console.ReadKey(true);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid command");
                            Console.ReadKey(true);
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("Failed to login");
                    Console.ReadKey(true);
                }
            }
            else
            {
                Console.WriteLine("User is not registered");
                Console.ReadKey(true);
            }
        }
        else if (key.KeyChar == 27)
        {
            Console.Clear();
            Console.WriteLine("Bye");
            Console.ReadKey(true);
            break;
        }
    } while (true);
}

