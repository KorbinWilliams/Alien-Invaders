using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }
    public List<IRoom> Rooms { get; set; } = new List<IRoom>();

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Item Pitchfork = new Item("Pitchfork", "A tool usually used for farming or joining local uprisings");
      Item DBshotgun = new Item("Double Barreled Shotgun", "As the saying goes,\"Killing one alien with two barrels.\"");
      Item Fork = new Item("Fork", "\"When all else fails fork it.\"");
      Item RayGun = new Item("Ray gun", "gun that goes pew pew");
      Room CountrySide = new Room("Farmville", "A quaint little farm infamous for it's obsessive community.");
    }

    public Game(IRoom currentRoom, IPlayer currentPlayer, List<IRoom> rooms)
    {
      CurrentRoom = currentRoom;
      CurrentPlayer = currentPlayer;
      Rooms = rooms;
    }
  }
}


// List<Item> CountryItems = new List<Item>();