using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerselected : MonoBehaviour
{
    public Characterdata characterdata;
    private int selectOption = 0;

    public SpriteRenderer spriter;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectOptin"))
        {

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
    private void UpdateCharacter(int select)
    {
        Character character = characterdata.GetCharacter(select);
        spriter.sprite = character.sprite;
        
    }
    private void Load()
    {
        selectOption = PlayerPrefs.GetInt("selectOtion");
    }
}
