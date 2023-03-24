using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Equipment equipmentSystem;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private InteractBehaviour interactBehaviour;

    [SerializeField]
    private MonstreAI monstreAI;

    [Header("Configuration")]
    private bool isAttacking;

    [SerializeField]
    private float attackRange;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Vector3 attackOffset;

    [Header("Enemy")]
    private GameObject AiEnemy;
    public bool makeDammage = false;

    void Update()
    {
        // Debug.DrawRay(transform.position + attackOffset, transform.forward * attackRange, Color.red);

        if(Input.GetMouseButtonDown(0) && CanAttack())
        {
            isAttacking = true;
            animator.SetTrigger("Attack");

            if(makeDammage == true)
            {
                monstreAI.TakeDammage(equipmentSystem.equipedWeaponItem.attackPoints);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AI")
        {
            AiEnemy = other.gameObject;
            monstreAI = other.GetComponent<MonstreAI>();
            makeDammage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AI")
        {
            AiEnemy = null;
            monstreAI = null;
            makeDammage = false;
        }
    }

    bool CanAttack()
    {
        /* Pour attaquer on doit :
        - Avoir une arme équipée
        - Ne pas être en train d'attaquer
        - Ne pas avoir l'inventaire ouvert
        */
        return equipmentSystem.equipedWeaponItem != null && !isAttacking && !uiManager.atLeastOnePanelOpened && !interactBehaviour.isBusy;
    }

    public void AttackFinished()
    {
        isAttacking = false;
    }
}
