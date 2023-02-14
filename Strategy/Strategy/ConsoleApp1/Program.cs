// See https://aka.ms/new-console-template for more information
using Strategy;


OriCode signSystem = new OriCode();

Console.WriteLine("Enable sign process");
Console.WriteLine("Employee sign finish.");

signSystem.ApiSendToNextStage("Employee");

signSystem.ApiSendToNextStage("Manager");

signSystem.ApiSendToNextStage("Director");

signSystem.ApiSendToNextStage("President");

Console.WriteLine("\n----------------------\n");

StrategyClass strategySys = new StrategyClass();

Console.WriteLine("Use Strategy Mode.");
Console.WriteLine("Employee sign finish.");

strategySys.ApiSendToNextStage("Employee");

strategySys.ApiSendToNextStage("Manager");

strategySys.ApiSendToNextStage("Director");

strategySys.ApiSendToNextStage("President");

Console.WriteLine("\n----------------------\n");

Console.WriteLine("Employee has permission to close this documents.");
strategySys.ApiSendToNextStage("Special permission");
