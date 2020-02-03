using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    public IGame _game { get; set; } = new Game();

    public List<string> Messages { get; set; } = new List<string>();

    // NOTE Don't forget safety checks.
    public void Go(string direction)
    {
      IRoom destination;

      if (_game.CurrentRoom.Exits.TryGetValue(direction, out destination))
      {
        _game.CurrentRoom = destination;
        Look();
      }
      else
      {
        Console.WriteLine("You can't go that way.");
      }
    }

    internal void PrintMain()
    {
      Messages.Add(@"

   _____   .__   .__                  .___                           .___                     
  /  _  \  |  |  |__|  ____    ____   |   |  ____ ___  _______     __| _/ ____ _______  ______
 /  /_\  \ |  |  |  |_/ __ \  /    \  |   | /    \\  \/ /\__  \   / __ |_/ __ \\_  __ \/  ___/
/    |    \|  |__|  |\  ___/ |   |  \ |   ||   |  \\   /  / __ \_/ /_/ |\  ___/ |  | \/\___ \ 
\____|__  /|____/|__| \___  >|___|  / |___||___|  / \_/  (____  /\____ | \___  >|__|  /____  >
        \/                \/      \/            \/            \/      \/     \/            \/ 

");
      Messages.Add("     -------------------------------------Map--------------------------------------");
      if (_game.CurrentRoom.RoomCode == 1)
      {
        Messages.Add(@"
##########################################################################################
##########################################################################################
##########################################################################################
####@@@@@@@@@@@@@@@@@@@@@################@@@@@@@@@@@@@@@@@@@@@@@@@@@@#####################
####@   ____  _         @################@                          @#####################
####@  /--_-\| |        @################@                          @#####################
####@ |  |_| | |    You @################@                          @#####################
####@ |   _  | |    \o/ @################@                          @#####################
####@ |  | | | |     |  @################@                          @#####################
####@ ---------     / \ @################@                          @#####################
####@@@@@@@@@@@@@@@@@  @@################@@@@@  @@@@@@@@@@@@@@@@@@@@@#####################
###################@@  @@@@@@@@@@@@@@@@@@@@@@@  @@@@@#####################################
###################@                                @#####################################
###################@                                @#####################################
###################@                                @#####################################
###################@                                @#####################################
###################@                                @#####################################
###################@                                @#####################################
###################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#####################################
");
      }
      //TODO make map for area 2 
      else if (_game.CurrentRoom.RoomCode == 2)
      {
        Messages.Add(@"");
      }
      // TODO make map for area 3
      else
      {
        Messages.Add(@"");
      }
    }

    public void Help()
    {
      Messages.Add(@"Command List:
      Go (North, South, East, or West),
      Inventory: displays current player items,
      Look: examines current location,
      EnterBuilding (building name): enters selected building,
      ExitBuilding: takes player back to city/main area,
      Reset: restarts game,
      TakeItem (item name): takes item from room if available,
      UseItem (item name): uses item from inventory or room if available");
    }

    public void Inventory()
    {
      Messages.Add("Inventory:");
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"{item.Name}: {item.Description}");
      }
    }

    public void Look()
    {
      Console.WriteLine($"{_game.CurrentRoom.Description}");
    }

    public void Reset()
    {
      // TODO
    }

    public void Setup(string playerName)
    {
      // TODO
    }

    public void TakeItem(string itemName)
    {
      // TODO
    }

    public void UseItem(string itemName)
    {
      // TODO
    }
  }
}