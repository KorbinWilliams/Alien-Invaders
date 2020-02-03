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
      // IRoom destination;

      // if (_game.CurrentRoom.Exits.TryGetValue(direction, out destination))
      // {
      //   _game.CurrentRoom = destination;
      // }
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        // return;
      }
      else
      {
        Messages.Add("You can't go that way.");
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

      Messages.Add(@"

##########################################################################################
##########################################################################################
##########################################################################################
####@@@@@@@@@@@@@@@@@@@@@################@@@@@@@@@@@@@@@@@@@@@@@@@@@@#####################
####@   ____  _         @################@       _____     _____    @#####################
####@  /--_-\|_|        @################@      /|\ /|\   /|\ /|\   @#####################
####@ |  |_| |/|        @################@     / |/_\| \ / |/_\| \  @#####################
####@ |   _  |\|        @################@_______/   \_____/   \____@#####################
####@)|__|_|_|/|((((((((@################@__________________________@#####################
####@    \ \            @################@                          @#####################
####@@@@@@@@@@@@@@@@@  @@################@@@@@  @@@@@@@@@@@@@@@@@@@@@#####################
###################@@  @@@@@@@@@@@@@@@@@@@@@@@  @@@@@@@@@@@@@@############################
###################@   ________         @                    @############################
###################@  |_hotel__|        @                    @############################
###################@  |  _   _ |                             @############################
###################@  | |X| |_||            ___        ___   @############################
###################@  |  _   _ |        @_ /   \      /   \  @############################
###################@  | |_| |_||        @|/_____\    /_____\ @############################
###################@  |    _   |        @|   _   |  |   _   |@############################
###################@__|___| |__|________@|__| |__|__|__| |__|@############################
###################@ - - - - - - - - - -@                    @############################
###################@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@############################
");
      Messages.Add($@"{_game.CurrentRoom.Name}
      {_game.CurrentRoom.Description}");
    }


    public void Help()
    {
      Messages.Add(@"Command List:
      Go (North, South, East, or West),
      Inventory: displays current player items,
      Look: examines current location and reveals items,
      Reset: restarts game,
      TakeItem (item name): takes item from room if available,
      UseItem (item name): uses item from inventory or room if available");
    }

    public void Inventory()
    {
      Messages.Add(@"
      Inventory:
      ");
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"{item.Name}: {item.Description} ");
      }
    }

    public void Look()
    {
      Messages.Add($"{_game.CurrentRoom.Description}");
      if (_game.CurrentRoom.RoomCode == 2)
      {
        Messages.Add("a Nokia cellphone lies in the middle of a crater.");
      }
      else if (_game.CurrentRoom.RoomCode == 3)
      {
        Messages.Add("There seems to be some sort of raygun next to an aliens body.");
      }
      else if (_game.CurrentRoom.RoomCode == 4)
      {
        Messages.Add("A weird alien asking for a phone comes up to you what do you want to do?");
      }
    }

    public void Reset()
    {
      // var room = _game.Rooms.Find(r => r.RoomCode == 1);
      // _game.CurrentRoom = room;
      // _game.CurrentPlayer.Inventory.Clear();
    }

    public void Setup(string playerName)
    {
      // TODO is this required?
    }

    public void TakeItem(string itemName)
    {
      if (_game.CurrentRoom.Items.Exists(i => i.Name == itemName))
      {
        var i = _game.CurrentRoom.Items.Find(i => itemName == i.Name);
        _game.CurrentPlayer.Inventory.Add(i);
      }
      else
      {
        Console.WriteLine("that item does not exist in this room.");
      }
    }

    public void UseItem(string itemName)
    {
      if (_game.CurrentRoom.RoomCode == 4 && itemName == "cellphone" && _game.CurrentPlayer.Inventory.Exists(i => i.Name == "cellphone"))
      {
        Messages.Add("You give the strange alien your nokia. After speaking on the phone for a while in some strange tongue, hundreds of UFOs fill the sky. Good job you just helped an alien call for backup");
        Messages.Add("Game Over");
      }
      else if (_game.CurrentRoom.RoomCode == 4 && itemName == "raygun" && _game.CurrentPlayer.Inventory.Exists(i => i.Name == "raygun"))
      {
        Messages.Add("The alien scourge is no more, no longer will Donald rant about those dang aliens.");
        Messages.Add("You win.");
      }
      else
      {
        Messages.Add("That didn't seem to do anything");
      }
    }
  }
}