using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public PersistentData persistentData;
    //If an NPC is helped, the value of the int is 1, if they are not the value is 0
    public void Save(bool malloryHelped, bool gregoryHelped, bool dexterHelped, bool axelHelped){
        if (malloryHelped == false){
            PlayerPrefs.SetInt("malloryHelped", 0);
        }
        else if (malloryHelped == true){
            PlayerPrefs.SetInt("malloryHelped", 1);
        }
        if (gregoryHelped == false){
            PlayerPrefs.SetInt("gregoryHelped", 0);
        }
        else if (gregoryHelped == true){
            PlayerPrefs.SetInt("gregoryHelped", 1);
        }
        if (dexterHelped == false){
            PlayerPrefs.SetInt("dexterHelped", 0);
        }
        else if (dexterHelped == true){
            PlayerPrefs.SetInt("dexterHelped", 1);
        }
        if (axelHelped == false){
            PlayerPrefs.SetInt("axelHelped", 0);
        }
        else if (axelHelped == true){
            PlayerPrefs.SetInt("axelHelped", 1);
        }
    }
    public void Load(){
        int malloryValue = PlayerPrefs.GetInt("malloryHelped", 0);
        int gregoryValue = PlayerPrefs.GetInt("gregoryHelped", 0);
        int dexterValue = PlayerPrefs.GetInt("dexterHelped", 0);
        int axelValue = PlayerPrefs.GetInt("axelHelped", 0);
        if (malloryValue == 1){
            persistentData.mallorySave = true;
        }
        if (gregoryValue == 1){
            persistentData.gregorySave = true;
        }
        if (dexterValue == 1){
            persistentData.dexterSave = true;
        }
        if (axelValue == 1){
            persistentData.axelSave = true;
        }
    }
    public void Reset() {
        PlayerPrefs.SetInt("malloryHelped", 0);
        PlayerPrefs.SetInt("gregoryHelped", 0);
        PlayerPrefs.SetInt("dexterHelped", 0);
        PlayerPrefs.SetInt("axelHelped", 0);
        persistentData.mallorySave = false;
        persistentData.gregorySave = false;
        persistentData.dexterSave = false;
        persistentData.axelSave = false;
    }
}
