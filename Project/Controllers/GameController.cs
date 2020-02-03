using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService { get; set; } = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
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
          var i = _gameService._game.CurrentRoom.Items.Find(i => option == i.Name);
          if (i.Name != option)
          {
            Console.WriteLine("that item does not exist in this room.");
          }
          else
          {
            _gameService._game.CurrentPlayer.Inventory.Add(i);
          }
          break;
        default:
          break;
      }
    }

    //NOTE this should print your messages for the game.
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