namespace ReimaginedAdventure.Shared.Models
{
    public class GameTableListElementModel
    {
        public GameTableListElementModel() { }

        public GameTableListElementModel(string name, string id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
