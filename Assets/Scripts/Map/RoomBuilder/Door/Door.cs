using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private static readonly int Switch = Animator.StringToHash("Switch");
    
    [SerializeField]
    private Animator animator;
    
    public event Action<Vector2> OnPlayerEntered;
    public Vector2 direction;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerEntered?.Invoke(direction);
        }
    }

    public void SwitchDoor()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger(Switch);
    }
}
