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

    public void Setup()
    {
      Item Pitchfork = new Item("Pitchfork", "A tool usually used for farming or joining local uprisings");
      Item DBshotgun = new Item("Double Barreled Shotgun", "As the saying goes,\"Killing one alien with two barrels.\"");
      Item Fork = new Item("Fork", "\"When all else fails fork it.\"");
      Item RayGun = new Item("Ray gun", "gun that goes pew pew");
      Room CountrySide = new Room("Farmville", "You find yourself in a small farm in the country-side. There is an old barn with a missing door.", 1);
      Room Boise = new Room("Boise", "Right next to the freeway is a newer hotel that looks abandoned.", 2);
      Room Area52 = new Room("Area-52", "The place looks like a warzone. The main building is demolished, but two hangers look okay.", 4);
      Room Meridian = new Room("Meridian", "You can't tell if you're still in Boise or not. There are several houses in this small neighborhood.", 3);
      CountrySide.AddExit("south", Boise);
      Boise.AddExit("north", CountrySide);
      Boise.AddExit("east", Meridian);
      Meridian.AddExit("west", Boise);
      Meridian.AddExit("north", Area52);
      Area52.AddExit("south", Meridian);
      Rooms.Add(CountrySide);
      Rooms.Add(Boise);
      Rooms.Add(Meridian);
      Rooms.Add(Area52);
      Player Leeroy = new Player("Leeroy Jenkins");
      CurrentRoom = CountrySide;
      CurrentPlayer = Leeroy;
    }

    public Game()
    {
      Setup();
    }
  }
}


// List<Item> CountryItems = new List<Item>();