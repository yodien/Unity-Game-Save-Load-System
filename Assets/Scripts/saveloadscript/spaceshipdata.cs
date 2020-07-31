using System.Collections.Generic;

[System.Serializable]
public class spaceshipdata
{
    public string name;
    public int speed;
    public int shield;
    public int hp;
    public int level;
    public int exp;
    public int weaponCount;
    public List<weaponList> weaponList = new List<weaponList>();
    public List<past_WPList> past_WPList = new List<past_WPList>();
    public int current_WP;
    public int consumables_count;
    public List<consumables_List> consumables_List = new List<consumables_List>();
    public int balance;
    public int max_hp;
    public int damage;
    public int max_exp;
    /*/ Start is called before the first frame update
    void Start()
    {
        weapon_list = new ArrayList();
        past_WPList = new ArrayList();
        consumable_list = new ArrayList();
    }

    public void newgamer(string shipname)
    {
        this.name = shipname;
        this.speed = 5;
        this.shield = 5;
        this.hp = 10;
        this.level = 1;
        this.exp = 0;
        this.weapon_count = 1;
        this.weapon_list.Add(4);
        this.past_WPList.Add(0);
        this.current_WP = 1;
        this.consumable_count = 1;
        this.consumable_list.Add(1);
    }

    public void loadgamer(string path)
    {
        string json;
        if (File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();

            }
        } else
        {
            Debug.LogWarning("File not found");
            json = "";
        }
       // JsonUtility.FromJsonOverwrite(json, )
    }*/
}
