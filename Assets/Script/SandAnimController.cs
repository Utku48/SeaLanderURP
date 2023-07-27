using UnityEngine;

public class SandAnimController : MonoBehaviour
{
    public Animator animator;
    private bool isPlayerInside;

    public GameObject net;

    public static bool walk;


    private void Start()
    {
        walk = false;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("sand"))
        {
            isPlayerInside = true;
            animator.SetBool("isWalking", true);
            PlayerMovement.Instance._animator.SetBool("iSwimming", false);

            net.transform.position = PlayerMovement.Instance.netStartPos.position;

            walk = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sand"))
        {
            Vector3 animPos = transform.position + Vector3.up * 1.5f;
            transform.position = animPos;
            net.SetActive(false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sand"))
        {
            isPlayerInside = false;
            animator.SetBool("isWalking", false);
            PlayerMovement.Instance._animator.SetBool("iSwimming", true);

            net.SetActive(true);

            net.transform.position = PlayerMovement.Instance.netAnimPos.position;
            walk = false;

            Vector3 animPos = transform.position - Vector3.up * 1.05f;
            transform.position = animPos;
        }
    }
}
