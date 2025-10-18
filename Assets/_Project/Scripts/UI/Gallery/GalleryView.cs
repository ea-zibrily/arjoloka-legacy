using UnityEngine;
using UnityEngine.UI;

namespace Arjoloka.UI
{
    [RequireComponent(typeof(Button))]
    public class GalleryView : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private GameObject lockItemObj;
        [SerializeField] private BasePopupUI explanationPopupUI;
        private Button _itemButtonUI;

        private void Awake()
        {
            _itemButtonUI = GetComponent<Button>();
        }

        private void Start()
        {
            _itemButtonUI.onClick.AddListener(OnClickItem);
        }

        // Core
        public void ModifyItemLock(bool isLocked)
        {
            lockItemObj.SetActive(isLocked);
            _itemButtonUI.interactable = !isLocked;
        }

        private void OnClickItem()
        {
            explanationPopupUI.gameObject.SetActive(true);
            explanationPopupUI.AnimateBounceUp();
        }
    }
}
