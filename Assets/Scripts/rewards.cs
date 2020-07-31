using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewards : MonoBehaviour
{
    [SerializeField] private rewards_data reward;
    [SerializeField] private spaceship_data ship_data;

    void Start(){
        int money = this.reward.get_money();
        int exp = this.reward.get_exp();

        this.ship_data.update_money(money);
        this.ship_data.update_exp(exp);

        gameObject.GetComponent<Text>().text = "Rewards: $ " + money + "      EXP: " + exp;
    }
}
