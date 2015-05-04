using UnityEngine;
using System.Collections;

public class BDIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * while true
		 * 		get next percept p
		 * 		B = Brf (B, p)
		 * 		D = Options (B, I)
		 * 		I = filter (B, D, I)
		 * 		pi = plan(B,I)
		 * 		while not (empty(pi) or succeded(I, B) or impossible(I, B))
		 * 			action = head(pi)
		 * 			execute(action)
		 * 			pi = tail(pi)
		 * 			get next percept p
		 * 			B = Brf(B, p)
		 * 			if reconsider (I, B) then
		 * 				D = options (B, I)
		 * 				I = filter (B, D, I)
		 * 			end-if
		 * 
		 * 			if not sound (pi, I, B) then
		 * 				pi = plan (B, I)
		 * 			end-if
		 * 		end-while
		 * end-while
		 * 
		 */
	}
}