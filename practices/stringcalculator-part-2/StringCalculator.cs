
namespace StringCalculator;

public class StringCalculator
{
    private IWebService _webService;
    private ILogger _logger;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {
        int answer = 0;
        if (numbers == "")
        {

            answer = 0;
        }
        else
        {
            answer = numbers.Split(',', '\n')
                .Select(int.Parse)
                .Sum();
        }
        // WTCYWYH
        try
        {
            _logger.Write(answer.ToString());
        }
        catch (LoggerException ex)
        {

            // Write the Code You Wish You Had
            //_webService.NotifyOfFailedLogging(ex.Message);
        _webService.NotifyOfFailedLogging(ex.Message);
        }

        return answer;
    }
}

public interface ILogger
{
    void Write(string message);
}

public interface IWebService
{
    void NotifyOfFailedLogging(string message);
}

public class LoggerException : ApplicationException
{
    public string Message { get; private set; } = "";
    public LoggerException(string message)
    {
        Message = message;
    }
}

