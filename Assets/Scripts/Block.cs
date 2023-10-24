using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool canCheck = false;

    public GameObject vfx;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canCheck)
        {
            if (collision != null && collision.gameObject.tag == gameObject.tag)
            {
                canCheck = false;
                GameObject vfxSuccess = Instantiate(vfx, transform.position, Quaternion.identity) as GameObject;

                Destroy(vfxSuccess, 1f);
                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(collision.gameObject);
                GameManager.Instance.CheckLevelUp();
            }
        }
    }
}
