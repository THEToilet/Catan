using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Player
{

public class PlayerAction : MonoBehaviour
{
    PlayerCore playerCore;
    // Start is called before the first frame update
    void Start()
    {
            playerCore = this.GetComponent<PlayerCore>();
    }
    
    // Update is called once per frame
    void Update()
    {
    /*  PlayerID = turnID
        if(this.playerID == PlayerID)
        {

        }*/
    }
}

}