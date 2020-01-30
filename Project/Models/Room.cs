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
    public Dictionary<string, Room> Exits { get; set; }

    private void AddItem(Item item)
    {
      Items.Add(item);
    }
    private void AddItem(Item[] items)
    {
      Items.AddRange(items);
    }
    private void AddRoom(Room exit)
    {
      Exits.Add($"{exit.RoomCode}", exit);
    }
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, Room>();
    }
  }
}