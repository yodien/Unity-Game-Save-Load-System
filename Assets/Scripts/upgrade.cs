using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class upgrade
{
    private string name;
    private Sprite image;
    private int level;
    private int cost;
    private string upgrade_type;
    private int upgrade_value;

    public upgrade(string name, string type, int level, int cost, int val, Sprite img){
        this.name = name;
        this.upgrade_type = type;
        this.level = level;
        this.cost = cost;
        this.upgrade_value = val;
        this.image = img;
    }

    public string get_name(){ return this.name;}

    public string get_type(){ return this.upgrade_type;}

    public int get_level(){ return this.level;}

    public int get_cost(){ return this.cost;}

    public int get_val(){ return this.upgrade_value;}

    public Sprite get_img(){ return this.image;}

    public void inc_level(int level_inc){ this.level += level_inc;}

    public void inc_cost(int cost_inc){ this.cost += cost_inc;}
}