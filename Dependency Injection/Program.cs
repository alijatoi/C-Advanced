// See https://aka.ms/new-console-template for more information
using DependencyInjectionExample;
using Microsoft.Extensions.DependencyInjection;
using static DependencyInjectionLooseCoupling;

Console.WriteLine("Week 9 - Dependency Injection and Without DI Examples");

Console.WriteLine("Tight Coupling Example: Without DI");

//InternalClass.Class,, hamra pase aik internal class he uske andar aik class he..
WithoutDependencyInjection.NotificationService notificationService = new WithoutDependencyInjection.NotificationService   ();

notificationService.SendNotifications("Without Dependency Injection, Hello, this is a tight coupling example!");
Console.WriteLine("---------------------------------------------------");

// ----------------------------------------------------------------------------------------------

// Idhar se Hamara Loose Coupling Start hoga....
// Yahan per ham apni se taraf se inject karenge,, kuch bh inject kaskty hen,,, jaise k MessageSender ya EmailSender
// to ye ham per depend karta hai k ham kya inject karna chahte hain
// bahir se inject kar rhy hen Notification Service mein, uper wale mein class ke andar hi bana rahe the,, jo ke tight coupling hai
// or idhar ham khud se inject kar rhy hen,,, jo ke loose coupling hai

Console.WriteLine("Loosely Coupling Example: This is Dependency Injection");
Console.WriteLine("Dependency Injection ka example,,, Program Main mein jao wahan se call karna hai..");


// Idhar object banayenge  ka aur usko bad m nechy inject karenge
IUpdateSender messageSender = new MessageSender();

//Internal Class.Class Object Creation
// idhar hamne MessageSender ko inject kar diya hai NotificationService mein
// please variable name per focus karna kahin uper wale se confuse na ho jana,, or uper wala class ka object na samajhna
DependencyInjectionLooseCoupling.NotificationService notificationServiceLooseCoupling = new DependencyInjectionLooseCoupling.NotificationService(messageSender);
notificationServiceLooseCoupling.SendNotification("Hello, this is a loosely coupling example with MessageSender!");


// Idhar ham Emailsender ka object banayenge  ka aur usko bad m nechy inject karenge
IUpdateSender emailSender = new EmailSender();

//idhar hamne EmailSender ko inject kar diya hai NotificationService mein..
notificationServiceLooseCoupling = new DependencyInjectionLooseCoupling.NotificationService(emailSender);
notificationServiceLooseCoupling.SendNotification("Hello, this is a loosely coupling example with Email Sender!");




// Another Examples of Dependency Injection

Console.WriteLine("---------------------------------------------------");
Console.WriteLine("Another Example of Dependency Injection");
Console.WriteLine("WIthout Dependency Injection Example: Robot Chef making Sandwich");
RobotChef robotChef = new RobotChef();
robotChef.MakeSandwich();

Console.WriteLine("---------------------------------------------------");
Console.WriteLine("With Dependency Injection Example: Robot Chef making Sandwich");

ISpread peanutButter = new PeanutButter();
// providing the dependency from outside via constructor injection
RobotChefDI robotChefDI = new RobotChefDI(peanutButter);
robotChefDI.MakeSandwich();

// providing the dependency from outside via constructor injection
ISpread jelly = new Jelly();
robotChefDI = new RobotChefDI(jelly);
robotChefDI.MakeSandwich();


Console.WriteLine("---------------------------------------------------");
Console.WriteLine("Modern Dependency Injection Example: Vehicle User");
Console.WriteLine("Only one Dependency Injected");


// (1) creating DI Container
// in whole app there should be only one container
// Only one container — simpler and safer.
//Avoids accidentally creating multiple instances of singletons.
ServiceCollection services = new ServiceCollection(); // creating a empty DI container (service collection) This will hold the list of all the services (dependencies) your app can create.


// (2) Register all dependencies before building the provider

// single dependency example
// Vehicle example
services.AddTransient<IVehicle, Car>(); // when someone asks for IVehicle, give them Car
services.AddTransient<VehicleUser>();  // When someone asks for VehicleUser, create it — and if it needs any dependencies (like IVehicle), it will provided them automatically.

// Social media example
// Multiple dependencies example
services.AddTransient<ISocialMedia, FacebookService>(); // when someone asks for ISocialMedia, give them FacebookService
services.AddTransient<ISocialMedia, TwitterService>(); // also register TwitterService as another implementation of ISocialMedia
services.AddTransient<SocialMediaPoster>();

// (3)
// Build the provider once
IServiceProvider provider = services.BuildServiceProvider();


//(4.a)
// Resolve VehicleUser
var driver = provider.GetRequiredService<VehicleUser>();
driver.Drive("By Driver");

//(4.b)
// Resolve SocialMediaPoster
var poster = provider.GetRequiredService<SocialMediaPoster>();
poster.Share("Hello World! This is a modern DI example with multiple dependencies!");
