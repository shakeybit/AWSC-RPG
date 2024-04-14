using Microsoft.VisualBasic;

namespace RPGidea
{
    public interface IEntityVisitor // defines new operation without changing classes of elements operated
    {
    int Visit(Entity entity);
    int Visit(Creature creature);
    int Visit(Gobject gobject);

    //add new types as needed
    
    }

    public interface IItemVisitor
    {
        int Visit(Item item);
        int Visit(Weapon weapon);
        int Visit(Armor armor);


    }


}