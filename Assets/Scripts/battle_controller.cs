using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum battle_state {START, PLAYERTURN, ENEMYTURN, WON, LOST, ESCAPE}

public class battle_controller : MonoBehaviour
{

    [SerializeField] private spaceship_data ship_data;
    [SerializeField] private rewards_data rewards;

    //Being loaded from inspector 
    public GameObject player;
    public GameObject enemy;

    public battle_state state;
    
    public battle_HUB player_HUB;
    public battle_HUB enemy_HUB;

    public Text action_text;

    // private variables
    private Unit player_unit;
    private Unit enemy_unit;


    // Start is called before the first frame update
    void Start()
    {
        state = battle_state.START;
        StartCoroutine(setup_battle());

    }

    IEnumerator setup_battle(){
        //set up player and enemy ship game ojects
        GameObject player_GO = Instantiate(player);
        GameObject enemy_GO = Instantiate(enemy);

        //set up player and enemey units for battle
        player_unit = player_GO.GetComponent<Unit>();
        player_unit.set_player_unit();
        player_GO.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = player_unit.get_image();
        
        enemy_unit = enemy_GO.GetComponent<Unit>();
        enemy_unit.set_enemy_unit();
        enemy_GO.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = enemy_unit.get_image();

        // set up health bars for player and enemy ships
        player_HUB.set_HUB(player_unit);
        enemy_HUB.set_HUB(enemy_unit);

        // set rewards proportional to player level
        int exp_val_per_level = 70;
        int money_val_per_level = 5;
        rewards.set_rewards(ship_data.get_level() * exp_val_per_level, ship_data.get_level() * money_val_per_level);

        // wait for diaglogue text to be read
        yield return new WaitForSeconds(2f);

        // speed determines who goes first
        if(player_unit.speed >= enemy_unit.speed){
            state = battle_state.PLAYERTURN;
            player_turn();
        }
        else{
            state = battle_state.ENEMYTURN;
            StartCoroutine(enemy_turn());
        }
        
    }

    //set dialogue to player turn
    void player_turn(){
        action_text.text = "Player Turn";
    }

    IEnumerator enemy_turn(){
        // attack player
        bool is_player_dead = player_unit.take_damage(enemy_unit.damage);

        // disable shield after enemy has attacked if player used shield in turn
        player_unit.is_shield_up = false;

        player_HUB.set_HP(player_unit.cur_HP);

        action_text.text = "Enemy Attacks!";

        yield return new WaitForSeconds(1f);

        
        //if player is dead; battle is lost. Or if player lives; its player's turn  
        if(is_player_dead){
            state = battle_state.LOST;
            end_battle();
        }
        else {
            state = battle_state.PLAYERTURN;
            player_turn();
        }

    }

    // function to transistion to correct scene once battle ends
    void end_battle(){
        if(state == battle_state.WON){
            SceneManager.LoadScene("congratulation_screen");
        }

        if(state == battle_state.LOST){
            SceneManager.LoadScene("lose_screen");
        }

        if(state == battle_state.ESCAPE){
            SceneManager.LoadScene("waypoint_panel");
        }
    }

    IEnumerator player_attack(){
        bool is_enemey_dead = enemy_unit.take_damage(player_unit.damage);

        enemy_HUB.set_HP(enemy_unit.cur_HP);

        action_text.text = "Player Attacks!";

        yield return new WaitForSeconds(2f);

        if(is_enemey_dead){
            state = battle_state.WON;
            end_battle();
        }
        else{
            state = battle_state.ENEMYTURN;
            StartCoroutine(enemy_turn());
        }
    }

    IEnumerator player_shield(){

        //raise shield
        player_unit.is_shield_up = true;

        action_text.text = "Shields Activated!";

        yield return new WaitForSeconds(1f);

        // enemy turn
        state = battle_state.ENEMYTURN;
        StartCoroutine(enemy_turn());
    }

    public void on_attack_button(){
        if(state != battle_state.PLAYERTURN)
            return;

        StartCoroutine(player_attack());
    }

    public void on_shield_button(){
        if(state != battle_state.PLAYERTURN)
            return;

        StartCoroutine(player_shield());
    }

    public void on_escape_button(){
        if(state != battle_state.PLAYERTURN)
            return;

        state = battle_state.ESCAPE;
        end_battle();
    }
}
