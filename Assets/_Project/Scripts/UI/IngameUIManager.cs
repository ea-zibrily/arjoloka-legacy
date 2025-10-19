using UnityEngine;
using UnityEngine.UI;

namespace Arjoloka.UI
{
    public class IngameUIManager : MonoBehaviour
    {
        [Header("Ingame")]
        [SerializeField] private Button infoButtonUI;
        [SerializeField] private Button backButtonUI;

        [Space]
        [SerializeField] private BasePopupUI infoPopupUI;
        [SerializeField] private BasePopupUI backPopupUI;

        private void Start()
        {
            infoButtonUI.onClick.AddListener(OnClickInfo);
            backButtonUI.onClick.AddListener(OnClickBack);
        }
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            OnClickBack();
        }

        private void OnClickInfo()
        {
            infoPopupUI.gameObject.SetActive(true);
            infoPopupUI.AnimateBounceUp(() =>
            {
                Time.timeScale = 0;
            });
        }

        private void OnClickBack()
        {
            backPopupUI.gameObject.SetActive(true);
            backPopupUI.AnimateBounceUp();
        }
    }
}
