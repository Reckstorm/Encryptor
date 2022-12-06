using Encryptor;
using System.Text.Json;

User temp = new User();
ConsoleKeyInfo key;
using (UserList Users = FileController.GetInstance().ReadInfo())
{
    do
    {
        Console.Clear();
        Console.WriteLine("1 - Register");
        Console.WriteLine("2 - Login");
        Console.WriteLine("Esc - Exit");
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
                Users.Users.Add(temp);
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
                    Console.WriteLine("Successfully logged in");
                    Console.ReadKey(true);
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

