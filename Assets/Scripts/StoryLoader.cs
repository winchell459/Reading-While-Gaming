using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryLoader : MonoBehaviour
{
    public List<TextAsset> pages;

    public TMP_Text textBox;

    private int currPage;

    void Start()
    {
        currPage = 0;
        textBox.text = pages[currPage].text;
    }

    public void NextPage()
    {
        if (currPage + 1 < pages.Count)
        {
            currPage++;
            textBox.text = pages[currPage].text;
        }
    }

    public void PrevPage()
    {
        if(currPage -1 >=0)
        {
            currPage--;
            textBox.text = pages[currPage].text;
        }
    }
}
