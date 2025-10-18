using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using DG.Tweening;

namespace Arjoloka.UI
{
    public class MenuUIManager : MonoBehaviour
    {
        // Fields
        [Header("UI")]
        [SerializeField] private GameObject galleryPanelUI;
        [SerializeField] private GameObject ingamePanelUI;
        [SerializeField] private BasePopupUI aboutPopupUI;
        [SerializeField] private BasePopupUI exitPopupUI;

        [Space]
        [SerializeField] private Button playButtonnUI;
        [SerializeField] private Button galleryButtonUI;
        [SerializeField] private Button aboutButtonUI;

        [Header("Animation")]
        [SerializeField] private float tweenDuration = 0.8f;
        [SerializeField] private Ease easeType;
        [SerializeField] private float moveOutY;

        private readonly float defaultAnchorY = 0f;

        // Reference
        private RectTransform _rect;

        // Methods
        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }

        private void Start()
        {
            VuforiaBehaviour.Instance.enabled = false;

            // Menu panel
            galleryPanelUI.SetActive(false);
            aboutPopupUI.gameObject.SetActive(false);
            exitPopupUI.gameObject.SetActive(false);

            // Button
            playButtonnUI.onClick.AddListener(OnClickPlay);
            galleryButtonUI.onClick.AddListener(OnClickGallery);
            aboutButtonUI.onClick.AddListener(OnClickAbout);
        }
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            exitPopupUI.gameObject.SetActive(true);
            exitPopupUI.AnimateBounceUp();
        }

        // Core
        private void OnClickPlay()
        {
            ingamePanelUI.SetActive(true);
            ModifyButtonInteractable(false);
            
            AnimateMoveOut(() =>
            {
                VuforiaBehaviour.Instance.enabled = true;
                ModifyButtonInteractable(true);
                gameObject.SetActive(false);
            });
        }

        private void OnClickGallery()
        {
            galleryPanelUI.SetActive(true);
            ModifyButtonInteractable(false);

            AnimateMoveOut(() =>
            {
                ModifyButtonInteractable(true);
                gameObject.SetActive(false);
            });
        }
        
        private void OnClickAbout()
        {
            aboutPopupUI.gameObject.SetActive(true);
            aboutPopupUI.AnimateBounceUp();
        }

        private void ModifyButtonInteractable(bool isInteractable)
        {
            playButtonnUI.interactable = isInteractable;
            galleryButtonUI.interactable = isInteractable;
            aboutButtonUI.interactable = isInteractable;
        }

        // Animation
        public void AnimateMoveIn(TweenCallback onComplete = null)
        {
            _rect.DOAnchorPosY(defaultAnchorY, tweenDuration)
                .SetEase(easeType)
                .OnComplete(onComplete);
        }
        
        public void AnimateMoveOut(TweenCallback onComplete = null)
        {
            _rect.DOAnchorPosY(moveOutY, tweenDuration)
                .SetEase(easeType)
                .OnComplete(onComplete);
        }
    }
}
