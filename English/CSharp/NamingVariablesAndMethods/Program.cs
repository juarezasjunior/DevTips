public class UserAccount
{
    public string UserName { get; set; }
    public DateTime LastLogin { get; set; }

    public void ProcessData(string userInput)
    {
        Console.WriteLine($"Processing data for user: {userInput}");
    }
}

public class Program
{
    public static void Main()
    {
        UserAccount account = new UserAccount
        {
            UserName = "John",
            LastLogin = DateTime.Now
        };

        account.ProcessData(account.UserName);
    }
}