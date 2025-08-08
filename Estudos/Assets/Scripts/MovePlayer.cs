using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //int blend = 0;
    public Animator animator;
    int run = 4;
    public GameObject[] magicattacks;
    public GameObject[] magicCircules;
    public GameObject[] magicazones;
    bool invoca = false;
    float time = 4;

    void Start()
    {
        
    }

    void Update()
    {
        if (invoca == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.SetFloat("Blend", 0);
                animator.SetBool("Move", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetFloat("Blend", 0);
                animator.SetBool("Move", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                animator.SetFloat("Blend", 1);
                animator.SetBool("Move", true);
                run *= -1;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetFloat("Blend", 0);
                animator.SetBool("Move", false);
                run *= -1;
            }

            float translation = Input.GetAxis("Vertical") * Time.deltaTime * run;
            float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * (run * 2);

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            invoca = true;
            Instantiate(magicCircules[0], magicazones[0].transform.position, magicazones[0].transform.rotation);
            Instantiate(magicattacks[0], magicazones[0].transform.position, transform.rotation);
            time = 4;
            Debug.Log("Iniciou");
        }

        while(time >= 0)
        {
            time -= Time.deltaTime;
        }

        if(time == 0)
        {
            invoca = true;
            Debug.Log("Acabou");
        }
    }
}
