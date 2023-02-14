// See https://aka.ms/new-console-template for more information
using Design_pattern_factory;
using System;


string[] orderList = { "cake", "cake", "grean tea" };

Console.Write("Hello, i'd like to order: ");
foreach( string item in orderList)
{
    Console.Write(item + ", ");
}
Console.WriteLine("");


// -------------------------- Ori Code -------------------------------------


OriCode obj = new OriCode();
int totalCost = obj.ApiTotalCost(orderList);

Console.WriteLine(string.Format("Total cost is {0} ", totalCost));


Console.WriteLine("");


// -------------------------- Factory Mode ------------------------------------

Factory factory = new Factory();
int facTotalCost = factory.ApiTotalCost(orderList);

Console.WriteLine(string.Format("Total cost by Factory mode is {0} ", facTotalCost));



