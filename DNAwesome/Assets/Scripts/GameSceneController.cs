using UnityEngine;

namespace DNAwesome
{
	public class GameSceneController : MonoBehaviour
	{
		public GameObject PlayerGO; 
		public GameObject OtherGO;
        public GameObject TinderPrefab;
		DNAController _playerController;
		DNAController _otherController;
        public Canvas Canvas;



		// Use this for initialization
		void Start()
		{
			_playerController = PlayerGO.GetComponent<DNAController>();
			_playerController.ResetDNA();
            //GameObject tp = Instantiate(TinderPrefab, Canvas.transform);
            _otherController = OtherGO.GetComponentInChildren<DNAController>();
			_otherController.ResetDNA(); 
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void OnAcceptClick()
		{
			_playerController.SmashDNA(_otherController.DNA);
			_otherController.ResetDNA(); 
		}

		public void OnRejectClick()
		{
			_otherController.ResetDNA();
		}


	}
}

