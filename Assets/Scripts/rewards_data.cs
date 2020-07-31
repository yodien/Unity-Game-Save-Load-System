using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "rewards_data", menuName = "rewards_data")]
public class rewards_data : ScriptableObject
{
    private int exp;
    private int money;

    public void init(int exp, int money){
        this.exp = exp;
        this.money = money;
    }

    public void set_rewards(int exp, int money){
        this.exp = exp;
        this.money = money;
    }

    public int get_exp(){ return this.exp;}

    public int get_money(){ return this.money;}
}
