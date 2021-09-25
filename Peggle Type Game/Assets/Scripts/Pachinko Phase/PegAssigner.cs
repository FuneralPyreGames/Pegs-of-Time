using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegAssigner : MonoBehaviour
{
    public GameObject[] Pegs;
    int pegToGold;
    int pegsMadeGold = 0;
    public void AssignGoldPegs(){
        pegToGold = Random.Range(1,5);
        Pegs = GameObject.FindGameObjectsWithTag("Pegs");
        foreach (GameObject target in Pegs){
            pegToGold -= 1;
            if (pegToGold == 0){
                pegsMadeGold += 1;
                target.GetComponent<PegHandler>().GoldPeg = true;
                target.GetComponent<PegHandler>().setGoldPeg();
                pegToGold = 4;
            }
            if (pegsMadeGold == 25){
                return;
            }
        }
        //If for whatever reason assigning gold pegs fails, this code ensures that the code will try again
        if (pegsMadeGold != 25){
            foreach (GameObject target in Pegs){
                target.GetComponent<PegHandler>().GoldPeg = false;
            }
            AssignGoldPegs();
        }
    }
}
