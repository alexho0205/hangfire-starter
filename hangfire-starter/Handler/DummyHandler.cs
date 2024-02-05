using Hangfire;

public class DummyHandler
{

    public void EchoCurrentTime()
    {
        Console.WriteLine(DateTime.Now);
    }

    [AutomaticRetry(Attempts = 1)]
    public void ThrowException()
    {
        if (true)
        {
            throw new Exception("Bad things happend!");
        }
    }

    public void GetHtmlConetent()
    {
        HttpClient client = new HttpClient();
        string page = client.GetStringAsync("https://www.google.com/").Result;
    }

}