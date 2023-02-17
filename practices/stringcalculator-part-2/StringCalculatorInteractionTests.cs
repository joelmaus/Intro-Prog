using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator;

public class StringCalculatorInteractionTests
{
    
    [Theory]
    [InlineData("1,2", "3")]
    [InlineData("1,2,3,4,5,6,7,8,9", "45")]
    public void AnswersAreLoggedToLogger(string numbers, string expected)
    {
        // Given
        var mockedLogger = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(mockedLogger.Object, mockedWebService.Object ); // NEED SOMETHING HERE

        // When
        calculator.Add(numbers);

        // Then
        // I need to verify (assert) that the logger was called with the expected value!
        mockedLogger.Verify(logger => logger.Write(expected), Times.Once);
        mockedWebService.Verify(ws => ws.NotifyOfFailedLogging(It.IsAny<string>()), Times.Never);
    }


    [Theory]
    [InlineData("Blammo!")]
    [InlineData("Taco Bell")]
    public void WhenLoggerBlowsUpTheWebServiceIsCalled(string expected)
    {
        // Given
        var stubbedLogger = new Mock<ILogger>();
        stubbedLogger.Setup(m => m.Write(It.IsAny<string>())).Throws(new LoggerException(expected));
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);

        // When
        calculator.Add("1");

        // then
        // ?? The web service should be called
        mockedWebService.Verify(ws => ws.NotifyOfFailedLogging(expected));
    }

   
}
