using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    // NOTE Don't forget safety checks.
    public void Go(string direction)
    {
      // TODO
    }

    internal void PrintMain()
    {
      Console.Clear();
      Console.WriteLine(@"

   _____   .__   .__                  .___                           .___                     
  /  _  \  |  |  |__|  ____    ____   |   |  ____ ___  _______     __| _/ ____ _______  ______
 /  /_\  \ |  |  |  |_/ __ \  /    \  |   | /    \\  \/ /\__  \   / __ |_/ __ \\_  __ \/  ___/
/    |    \|  |__|  |\  ___/ |   |  \ |   ||   |  \\   /  / __ \_/ /_/ |\  ___/ |  | \/\___ \ 
\____|__  /|____/|__| \___  >|___|  / |___||___|  / \_/  (____  /\____ | \___  >|__|  /____  >
        \/                \/      \/            \/            \/      \/     \/            \/ 

");
      // TODO add if(player.location == here)
      //           {Console.Writeline("Map with cur location")}
      Console.WriteLine(@"--------Map--------

##########################################################################################
##########################################################################################
##########################################################################################
####@@@@@@@@@@@@@@@@@@@@@################@@@@@@@@@@@@@@@@@@@@@@@@@@@@#####################
####@   ____  _         @################@                          @#####################
####@  /--_-\| |        @################@                          @#####################
####@ |  |_| | |        @################@                          @#####################
####@ |   _  | |        @################@                          @#####################
####@ |  | | | |        @################@                          @#####################
####@ ---------         @################@                          @#####################
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
      // TODO for each item in player inventory add msg 
      // foreach (var item in player.Inventory)
      // {
      //   Messages.Add($"{item.Name}: {item.Description}")
      // }
    }

    public void Look()
    {
      // TODO
    }

    public void Quit()
    {
      // TODO
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