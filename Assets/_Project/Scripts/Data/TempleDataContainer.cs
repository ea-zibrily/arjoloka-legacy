using System.Collections.Generic;
using UnityEngine;

namespace Arjoloka.Data
{
    public class TempleDataContainer : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private List<TempleData> templeDatas;

        // Simple singleton
        public static TempleDataContainer Instance;

        private void Awake()
        {
            Instance = this;
        }
        
        public List<TempleData> GetAllTempleDatas()
        {
            return templeDatas;
        }

        public TempleData GetTempleDataWithID(string templeID)
        {
            return templeDatas.Find(x => x.TempleID == templeID);
        }

        public bool IsTempleDatasNull()
        {
            return templeDatas == null || templeDatas.Count == 0;
        }
    }
}
