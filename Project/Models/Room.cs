using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {

    public string Name { get; set; }
    public int RoomCode { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
    public Dictionary<string, IRoom> Exits { get; set; }

    private void AddItem(Item item)
    {
      Items.Add(item);
    }
    private void AddItem(Item[] items)
    {
      Items.AddRange(items);
    }
    public void AddExit(string direction, IRoom exit)
    {
      Exits.Add(direction, exit);
    }
    public Room(string name, string description, int code)
    {
      Name = name;
      Description = description;
      RoomCode = code;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}