using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Arjoloka.Data;

namespace Arjoloka.UI
{
    [RequireComponent(typeof(Button))]
    public class GalleryView : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private string viewID;
        [SerializeField] private GameObject lockItemObj;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI viewNameTextUI;
        [SerializeField] private GalleryPopupUI explanationPopupUI;
        private Button _itemButtonUI;

        private void Awake()
        {
            _itemButtonUI = GetComponent<Button>();
        }

        private void Start()
        {
            _itemButtonUI.onClick.AddListener(OnClickItem);
            viewNameTextUI.text = TempleDataContainer.Instance.GetTempleDataWithID(viewID).TempleName;
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
            explanationPopupUI.SetPopupData(viewID);
            explanationPopupUI.AnimateBounceUp();
        }
    }
}
