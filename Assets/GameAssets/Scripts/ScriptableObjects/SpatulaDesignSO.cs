using UnityEngine;
[CreateAssetMenu(fileName = "SpatulaDesignSO", menuName = "ScriptableObjects/SpatulaDesignSO")]
public class SpatulaDesignSO : ScriptableObject
{
    [SerializeField] private float extraJumpForce;

    public float ExtraJumpForce => extraJumpForce;
}
