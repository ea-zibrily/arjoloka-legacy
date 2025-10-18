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

        public string ViewID => viewID;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI viewNameTextUI;
        [SerializeField] private GalleryPopupUI explanationPopupUI;
        private Button _itemButtonUI;

        // Methods
        private void Awake()
        {
            _itemButtonUI = GetComponent<Button>();
        }

        private void Start()
        {
            _itemButtonUI.onClick.AddListener(OnClickItem);
            var data = TempleDataContainer.Instance.GetTempleDataWithID(viewID);
            if (data == null)
            {
                Debug.LogWarning($"GalleryView with ID {viewID} not found in TempleDataContainer.");
                return;
            }
            viewNameTextUI.text = data.TempleName;
        }

        // Core
        public void ModifyItemLock(bool isLocked)
        {
            lockItemObj.SetActive(isLocked);
            viewNameTextUI.text = "???";
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
