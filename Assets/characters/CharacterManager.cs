using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public Characterdata characterdata;
    public Text charactername;
    public Text characterprice;
    public SpriteRenderer spriterender;
    private int selectOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectOptin")){

            selectOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectOption);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Nextoption()
    {
        selectOption++;
        if (selectOption >= characterdata.characterCount)
        {
            selectOption = 0;
        }
        UpdateCharacter(selectOption);
    }
    public void Backoption()
    {
        selectOption--;
        if (selectOption <0)
        {
            selectOption = characterdata.characterCount-1;
        }
        UpdateCharacter(selectOption);
    }
    private void UpdateCharacter(int select)
    {
        Character character = characterdata.GetCharacter(select);
        spriterender.sprite = character.sprite;
        charactername.text = character.Name;
    }
    private void Load()
    {
        selectOption = PlayerPrefs.GetInt("selectOtion");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectOtion", selectOption);
    }
}
