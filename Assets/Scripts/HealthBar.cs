using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text HPText, HPValue;
    public RawImage HPBar;

    public float drainRate = 1;

    private int MaxHP;
    private int HP;
    private float HPBarLength;

    public bool isDraining;

    // Start is called before the first frame update
    void Start()
    {
        HPBarLength = HPBar.rectTransform.rect.width;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CalcBarHP() > HP)
        {
            isDraining = true;
            float deltaHP = CalcBarHP() - HP;
            //Debug.Log(deltaHP);
            if(deltaHP > drainRate * Time.deltaTime)
            {
                //Debug.Log("draining");
                HPBar.rectTransform.sizeDelta = new Vector2(CalcBarLength((CalcBarHP() - drainRate * Time.deltaTime)), HPBar.rectTransform.sizeDelta.y);
            }
            else
            {
                HPBar.rectTransform.sizeDelta = new Vector2(CalcBarLength(HP), HPBar.rectTransform.sizeDelta.y);
                isDraining = false;
            }

            HPValue.text = ((int)CalcBarHP()).ToString();
        }
        else
        {
            isDraining = false;
        }
    }

    public void SetupHealthBar(string label, int maxHP, Color color)
    {
        HPText.text = label;
        HPValue.text = maxHP.ToString();
        MaxHP = maxHP;
        HP = maxHP;
        HPBar.rectTransform.sizeDelta = new Vector2(HPBarLength, HPBar.rectTransform.sizeDelta.y);
        HPBar.color = color;
    }
    public void ReduceHP(int damage)
    {
        int newHP = HP - damage;
        newHP = Mathf.Clamp(newHP, 0, MaxHP);
        SetHP(newHP);
    }

    public void SetHP(int hp)
    {
        HP = hp;
    }
    public int GetHP()
    {
        return HP;
    }

    private float CalcBarLength(float hp)
    {
        //Debug.Log(HPBarLength * hp / MaxHP);
        return HPBarLength * hp / MaxHP;
    }

    private float CalcBarHP()
    {
        return MaxHP * HPBar.rectTransform.sizeDelta.x / HPBarLength;
    }
}
