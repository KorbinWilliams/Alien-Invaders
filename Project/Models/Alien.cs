namespace ConsoleAdventure.Models
{
  class Alien
  {
    public string Name { get; set; }
    public int Defence { get; set; }

    public Alien(string name, int defence)
    {
      Name = name;
      Defence = defence;
    }
  }
}