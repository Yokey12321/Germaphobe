using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSprites : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite[] platoReddWyattJeremySprites;

    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite getIcon(string s)
    {
        switch(s)
        {
            case "P":
                return platoReddWyattJeremySprites[0];
            case "R":
                return platoReddWyattJeremySprites[1];
            case "W":
                return platoReddWyattJeremySprites[2];
            case "J":
                return platoReddWyattJeremySprites[3];
            default:  return null;
        }
    }

}
