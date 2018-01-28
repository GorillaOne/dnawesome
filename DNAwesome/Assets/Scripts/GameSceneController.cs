using DNAwesome.Models;
using UnityEngine;

namespace DNAwesome
{
	public class GameSceneController : MonoBehaviour
	{
		public GameObject IntroArea;
		public GameObject EvolutionArea;
		public GameObject WorldChallengeArea;

		public GameObject PlayerGO;
		public GameObject OtherGO;
		public GameObject TinderPrefab;
		DNAController _playerController;
		DNAController _otherController;
		public Canvas Canvas;

		public PlanetFightResultVisualizer PlanetVisualizer; 

		InterfaceState _currentInterfaceState;
		InterfaceState CurrentInterfaceState
		{
			get
			{
				return _currentInterfaceState;
			}
			set
			{
				switch (value)
				{
					case InterfaceState.Intro:
						SetStateValues(true, false, false);
						break;
					case InterfaceState.Evolution:
						SetStateValues(false, true, false);
						break;
					case InterfaceState.World:
						SetStateValues(false, false, true);
						break;
					default:
						break;
				}
				_currentInterfaceState = value;
			}
		}

		System.DateTime startTime;

		// Use this for initialization
		void Start()
		{
			_playerController = PlayerGO.GetComponent<DNAController>();
			_playerController.ResetDNA();
			//GameObject tp = Instantiate(TinderPrefab, Canvas.transform);
			_otherController = OtherGO.GetComponentInChildren<DNAController>();
			_otherController.ResetDNA();


			CurrentInterfaceState = InterfaceState.Intro; 

		}

		// Update is called once per frame
		void Update()
		{
			if (CurrentInterfaceState == InterfaceState.Intro)
			{
				if (Input.anyKeyDown)
				{
					CurrentInterfaceState = InterfaceState.Evolution; 
				}

			}
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

		public void OnFightClick()
		{
			var model = PlanetModel.GeneratePlanet(PlanetDifficulty.BabyMode); 
			CurrentInterfaceState = InterfaceState.World;
			
			PlanetVisualizer.result = model.FightMe(_otherController.DNA);
			PlanetVisualizer.enabled = true;

		}

		private void SetStateValues(bool intro, bool evolution, bool world)
		{
			IntroArea.SetActive(intro);
			EvolutionArea.SetActive(evolution);
			WorldChallengeArea.SetActive(world);
		}
	}

	public enum InterfaceState
	{
		Intro,
		Evolution,
		World,
	}
}

