using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitychanAnimContoroller : MonoBehaviour
{

    private const string KEY_ANIME_SPEED = "Speed";
    private const string KEY_ANIME_JUMP = "Jump";


    private bool isJump = false;
    private float speedWork = 0.0f;


    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /**
     * 
     */
    public void OnDownWorkFront()
    {
        Debug.Log("長押しですよ");
        //animator.SetFloat(KEY_ANIME_SPEED, speedWork);
    }


    public void OnClickWorkFront()
    {
        Debug.Log("キャット!!");
        //animator.SetFloat(KEY_ANIME_SPEED, speedWork);
    }

    public void OnUpWorkFront()
    {
        Debug.Log("アップ");
        //animator.SetFloat(KEY_ANIME_SPEED, speedWork);
    }
}
