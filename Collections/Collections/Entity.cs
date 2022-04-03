namespace Collections
{
    public class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public Entity(int id, int parentId, string name) { Id = id; ParentId= parentId; Name=name; }
    }
}