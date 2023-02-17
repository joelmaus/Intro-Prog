# Different Kinds of .NET Applications
 
(Not an exhaustive list)

## Applications that Users Directly Interact With

- Console Application (Command Line Application)
- User Interface - "Windowed"
    - Windows Forms Applications
    - Windows Presentation Foundation (WPF)
    - MAUI - Sort of WPF, but Cross-Platform
        - Using MAUI you can build apps that run on
            - Windows
            - MacOS
            - iOS
            - Android
            - Linux
- Web Based User Interface
    - Web Forms (still around, but deprecated) 
    - MVC (Razor Pages)
        - Server-Side Generated HTML Applications
        - Progressive.Com

## Services - Applications that other Applications Interact With

- Web APIs (MVC) Exposes an HTTP-based interface.
    - Old Skool MVC with Controllers Model
        - We will build one of these.
    - Minimal APIs - no Controller Classes
        - This is what we did in the "Finger" API

- gRPC Services 
    - Really fast way to create services that talk to other services.
    - Also supports streaming (sending data from either to the client to the server over time or vice-versa)
        - Can also be "bi-directional"


## Every Application has to be "Runnable"

- Have a `public static void Main()` method where the execution begins.


## Class Libraries

Are not "runnable" - they are literally a CLASS (or type) library.
They are referenced and used by other applications, usually one that is runnable.

- Usually are created to "share" common code between different applications.
- The "right" way to share class libraries is to publish them a NuGet packages 
    - There is a global public registry for NuGet where Microsoft and everybody else puts stuff.
    - Inside of Progressive, you have your own internal registry that you can publish to that is "private" to Progressive.


## Versioning Software with Semantic Versioning (https://semver.org)

Version numbers are expressed in three parts (4.18.3)

- Major - 4
    - We screwed up. There is a good chance if you move to a new major version there is at least one breaking change.
    - Changes:
        - We removed something.
        - We changed something in a way that might break your code (removed or added parameters to a method, etc.)
        - Anything else that would tick break the users of this, maybe. 
- Minor - 18
    - There are backward compatible new featurs.
    - Check the changelog - there might be some cool new stuff here you'd want to use.
- Patch - 3
    - There are backward compatible bug fixes.
    - You probably should install this.
