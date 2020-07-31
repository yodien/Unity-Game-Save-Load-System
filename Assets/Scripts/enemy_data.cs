using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "enemy_data", menuName = "enemy_data")]
public class enemy_data : ScriptableObject
{
    [SerializeField] private List<enemy> enemys = null;
    
    public void init(){
        this.enemys = new List<enemy>();
    }

    public void add_enemy(string name, Sprite img){
        this.enemys.Add(new enemy(name, img));
    }

    public enemy get_enemy(){

        //generate and return random enemy 
        int i = Random.Range(0, this.enemys.Count);
        return this.enemys[i];
    }
}
