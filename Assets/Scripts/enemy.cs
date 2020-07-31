using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy
{
    private string name;
    private Sprite img;
    private int exp_reward;
    private int money_reward;

    public enemy(string name, Sprite img){
        this.name = name;
        this.img = img;
    }

    public void set_rewards(int exp, int money){
        this.exp_reward = exp;
        this.money_reward = money;
    }

    public string get_name(){ return this.name;}

    public Sprite get_image(){ return this.img;}

    public int get_exp_reward(){ return this.exp_reward;}

    public int get_money_reward(){ return this.money_reward;}
}
