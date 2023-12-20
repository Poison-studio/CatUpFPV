using UnityEngine;
using Yarn.Unity;

namespace CatUp
{
    public class SaveLoadSystem : MonoBehaviour
    {
        [SerializeField]
        private DialogueRunner dialogueRunner;

        public string saveName { get; private set; } = "Test 6";

        // Start is called before the first frame update
        void Start()
        {
            dialogueRunner.SaveStateToPersistentStorage(saveName);
        }

        public void Save()
        {
            dialogueRunner.SaveStateToPersistentStorage(saveName);
        }

        public void Load() 
        {
            dialogueRunner.LoadStateFromPersistentStorage(saveName);
        }
    }

}