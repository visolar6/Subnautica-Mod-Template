using UnityEngine;

namespace MODNAME.Mono
{
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class GenericBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            // Logic to run when the object is initialized
        }

        private void Start()
        {
            // Logic to run when the object is instantiated
        }

        private void Update()
        {
            // Logic to run every frame
        }

        private void OnDestroy()
        {
            // Logic to run when the object is destroyed
        }

        private void OnEnable()
        {
            // Logic to run when the object is enabled
        }

        private void OnDisable()
        {
            // Logic to run when the object is disabled
        }
    }
}
