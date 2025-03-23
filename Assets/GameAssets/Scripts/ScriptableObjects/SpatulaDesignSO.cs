using UnityEngine;

namespace SpatulaDesign
{
    [CreateAssetMenu(fileName = "SpatulaDesignSO", menuName = "ScriptableObjects/SpatulaDesignSO")]
    public class SpatulaDesignSO : ScriptableObject
    {
        [SerializeField] public float extraJumpForce;
    }
}

