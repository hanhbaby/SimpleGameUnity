using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    public GameObject MainPlayer;
   public bool hammerAttack;
    // Start is called before the first frame update
    void Start()
    {
        hammerAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "monster" && hammerAttack)
        {
            Destroy(collision.gameObject);
            if(MainPlayer.GetComponent<MainPlayer>().mHealth < 10)
            {
                MainPlayer.GetComponent<MainPlayer>().mHealth++;
                MainPlayer.GetComponent<MainPlayer>().mHealthBar.fillAmount = MainPlayer.GetComponent<MainPlayer>().mHealth / 10f;
            }
           
        }
    }

}
