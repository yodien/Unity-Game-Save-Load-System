using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "shop_data", menuName = "shop_data")]
public class shop_data : ScriptableObject
{
    private List<upgrade> upgrades = null;
    private int cost_inc;
    private int val_inc;

    public void init(int cost_inc, int val_inc){
        this.upgrades = new List<upgrade>();
        this.cost_inc = cost_inc;
        this.val_inc = val_inc;
    }

    public void add_upgrade(string name, string type, int level, int cost, int val, Sprite img){
        this.upgrades.Add(new upgrade(name, type, level, cost, val, img));
    }

    public void inc_upgrades(int level_inc, int cost_inc){
        for(int i = 0; i < this.upgrades.Count; i++){
                this.upgrades[i].inc_level(level_inc);
                this.upgrades[i].inc_cost(cost_inc);
        }
    }


    public upgrade get_upgrade(string name){
        for(int i = 0; i < this.upgrades.Count; i++){
            if(this.upgrades[i].get_name() == name)
                return this.upgrades[i];
        }
        return null;
    }

    public int get_level_of_items(){
        return this.upgrades[0].get_level();
    }

    public int get_cost_inc(){ return this.cost_inc;}

    public int get_val_inc(){ return this.val_inc;}

    public List<upgrade> get_upgrades(){ return this.upgrades;}
}