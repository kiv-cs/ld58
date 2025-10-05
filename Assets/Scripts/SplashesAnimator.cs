using UnityEngine;

namespace DefaultNamespace
{
    public class SplashesAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _bluePrefab;
        [SerializeField] private Animator _redPrefab;

        public void PlaySplash(Vector3 transformPosition, bool isPriest, bool isReverse)
        {
            var splashPrefab = isPriest ? _bluePrefab : _redPrefab;

            var splash = Instantiate(splashPrefab, transformPosition - Vector3.forward, Quaternion.identity);
            
            if (isReverse) splash.speed = -1;
            
            Destroy(splash.gameObject, .4f);
            
        }
    }
}