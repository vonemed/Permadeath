using UnityEngine;

namespace ConfigScripts
{
    [CreateAssetMenu(fileName = "ParticlesConfig", menuName = "Configs/ParticlesConfig")]
    public class ParticlesConfig : ScriptableObject
    {
        [Header("[Impact]")] public GameObject defaultImpact;
    }
}