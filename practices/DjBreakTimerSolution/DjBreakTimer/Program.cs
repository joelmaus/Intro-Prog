Console.WriteLine("So, You want to take a break!\n\n");

Console.Write("How long of a break, in minutes: ");
var minutesEntered = Console.ReadLine();

var minutes = int.Parse(minutesEntered!);

Console.Write("How long is the song? (mm:ss)");
var songLengthEntered = Console.ReadLine();

var songLength = TimeSpan.Parse("0:" + songLengthEntered!);

var timeAtEndOfBreak = DateTimeOffset.Now.AddMinutes(minutes);
var timeToStartSong = timeAtEndOfBreak - songLength;
var originalConsoleForeground = Console.ForegroundColor;
var originalConsoleBackground = Console.BackgroundColor;
var songShouldBePlaying = false;
while(true)
{
    
    Console.WriteLine($"Your break will end at {timeAtEndOfBreak:T} and you should start the song at {timeToStartSong:T}");
    
    var timeLeftInBreak = timeAtEndOfBreak - DateTimeOffset.Now;
    Console.WriteLine($"You have {timeLeftInBreak.Minutes}:{timeLeftInBreak.Seconds} minutes until the break is over");

    if( DateTimeOffset.Now > timeToStartSong)
    {
        songShouldBePlaying= true;
    } else
    {
        var timeLeftUntilSongStarts = timeToStartSong - DateTimeOffset.Now;
        Console.WriteLine($"You have {timeLeftUntilSongStarts.Minutes}:{timeLeftUntilSongStarts.Seconds} minutes until you should start the song.");
    }
    if(timeAtEndOfBreak < DateTimeOffset.Now)
    {
        break;
    }

    Thread.Sleep( 1000 );
    if(songShouldBePlaying)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
    }
    Console.Clear();
}
Console.ForegroundColor = originalConsoleForeground;
Console.BackgroundColor = originalConsoleBackground;
Console.Clear();
Console.WriteLine("Break Over");