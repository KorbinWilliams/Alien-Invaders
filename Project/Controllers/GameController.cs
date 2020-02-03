using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService { get; set; } = new GameService();

    private bool _running { get; set; } = true;
    public void Run()
    {
      Console.Clear();
      _gameService.PrintMain();
      while (_running)
      {
        Print();
        GetUserInput();
      }
    }

    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      switch (command)
      {
        case "quit":
          Console.Clear();
          _running = false;
          break;
        case "help":
          Console.Clear();
          _gameService.Help();
          break;
        case "inventory":
          _gameService.Inventory();
          break;
        case "take":
          _gameService.TakeItem(option);
          break;
        case "reset":
          _gameService.Reset();
          break;
        case "go":
          Console.Clear();
          _gameService.Go(option);
          break;
        case "look":
          _gameService.Look();
          break;
        case "use":
          _gameService.UseItem(option);
          break;
        default:
          Console.WriteLine("That is not a proper command type help for a list of commands.");
          break;
      }
    }

    private void Print()
    {
      foreach (var message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
      _gameService.PrintMain();
    }

  }
}