using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using DG.Tweening;

namespace Arjoloka.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class BasePopupUI : MonoBehaviour
    {
        [Header("Animation")]
        [SerializeField] private float tweenDuration;
        [SerializeField] private float bounceDuration;
        [SerializeField] private Ease easeType;
        [SerializeField] private Vector3 targetScale;
        [SerializeField] private Vector3 bounceScale;

        [Header("Properties")]
        [SerializeField] private bool isMenuPopup;
        [SerializeField] protected RectTransform windowPopupRect;
        [SerializeField] private Button backButtonUI;


        // Methods
        private void Start()
        {
            InitOnStart();
        }

        protected virtual void InitOnStart()
        {
            backButtonUI.onClick.AddListener(OnClickBack);
        }

        // Core
        private void OnClickBack()
        {
            AnimateBounceDown(() =>
            {
                // Check timescale
                if (Time.timeScale == 0)
                    Time.timeScale = 1;
                
                gameObject.SetActive(false);
            });

        }

        public void AnimateBounceUp(TweenCallback onComplete = null)
        {
            // Reset scale
            windowPopupRect.DOScale(Vector3.zero, 0f);

            // Bounce Up
            windowPopupRect.DOScale(bounceScale, tweenDuration)
                .SetEase(easeType);
            
            windowPopupRect.DOScale(targetScale, bounceDuration)
                .SetEase(easeType)
                .SetDelay(tweenDuration)
                .OnComplete(() =>
                {
                    onComplete?.Invoke();
                    ModifyVuforia(enabled: false);
                });
        }

        public void AnimateBounceDown(TweenCallback onComplete = null)
        {
            // Fixed scale
            windowPopupRect.DOScale(targetScale, 0f);

            // Bounce Down
            windowPopupRect.DOScale(bounceScale, bounceDuration)
                .SetEase(easeType);

            windowPopupRect.DOScale(Vector3.zero, tweenDuration)
                .SetEase(easeType)
                .SetDelay(bounceDuration)
                .OnComplete(() =>
                {
                    onComplete?.Invoke();
                    ModifyVuforia(enabled: true);
                });
        }
        
        private void ModifyVuforia(bool enabled)
        {
            if (!isMenuPopup) return;
            VuforiaBehaviour.Instance.enabled = enabled;
        }

    }
}
