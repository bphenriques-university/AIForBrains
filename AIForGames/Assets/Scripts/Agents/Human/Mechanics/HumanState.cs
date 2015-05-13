using UnityEngine;
using System.Collections.Generic;

public class HumanState : MonoBehaviour
{
	Collider sightCollider;

	HumanHunger hunger;
	HumanHealth health;
	HumanShooting shooting;
	HumanMovement movement;
    HumanSpeak speech;
	int shootableMask;

	public GameObject ExitRoute;

	public Actuator actuator;

	void Awake(){
		GameOverManager.humansAlive++;

		FoodMemory = new Dictionary<int, MemoryEntry> ();
		ZombieMemory = new Dictionary<int, MemoryEntry> ();
		HumanMemory = new Dictionary<int, MemoryEntry> ();
		AmmoMemory = new Dictionary<int, MemoryEntry> ();

		targetPosition = transform.position;

        speech = GetComponent<HumanSpeak>();
		hunger = GetComponent<HumanHunger> ();
		health = GetComponent<HumanHealth> ();
		shooting = GetComponentInChildren<HumanShooting> ();
		movement = GetComponentInChildren<HumanMovement> ();
		shootableMask = LayerMask.GetMask ("Shootable");
		actuator = GetComponent<Actuator> ();
		sightCollider = GetComponentInChildren<MeshCollider> ();

	}
	
	/* ------------------------------------------*/
	/* ---------- PUBLIC PROPERTIES  ------------*/
	/* ------------------------------------------*/
	
	public Transform[] randomPoints;
	public GameObject[] closeFriends;
	
	/* ------------------------------------------*/
	/* ----------       STATE        ------------*/
	/* ------------------------------------------*/

	float attackTimer;
	int lastSeenHealth;
	
	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject = null;
	public GameObject foodSeen = null;
	public Ammo ammoSeen = null;
	public GameObject zombieSeen = null;
	public GameObject exitSeen = null;

	public GameObject lastHumanSeen = null;


	public float humanTimer = 0f;

	public bool sawFood = false;
	public bool onFood = false;
	public bool sawZombie = false;
	public bool sawHumanInDanger = false;
	public bool bitten = false;
	public bool sawAmmo = false;
	public bool onAmmo = false;
	public bool sawExitDoor = false;

	
	void Update(){
		humanTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;
		cleanWrongMemories ();

	}

	/* ------------------------------------------*/
	/* ----------       MEMORY       ------------*/
	/* ------------------------------------------*/
	public struct MemoryEntry{
		private GameObject gObject;
		private Vector3 position;
		
		public MemoryEntry(GameObject memory, Vector3 position){
			this.gObject = memory;
			this.position = position;
		}
		
		public GameObject getGameObject(){
			return gObject;
		}
		
		public Vector3 getLastKnownPosition(){
			return position;
		}

		public void updatePosition(Vector3 position){
			this.position = position;
		}
	}
	
	public Dictionary<int, MemoryEntry> FoodMemory;
	public Dictionary<int,MemoryEntry> AmmoMemory;
	public Dictionary<int,MemoryEntry> HumanMemory;
	public Dictionary<int,MemoryEntry> ZombieMemory;

	public void rememberFood(GameObject food){
		MemoryEntry entry;

		if(FoodMemory.TryGetValue(food.GetInstanceID(), out entry))
		   entry.updatePosition(food.transform.position);
		else
		   FoodMemory.Add(food.GetInstanceID(), new MemoryEntry (food ,food.transform.position));
	}

	public void rememberHuman(GameObject human){
		MemoryEntry entry;
		
		if(HumanMemory.TryGetValue(human.GetInstanceID(), out entry))
			entry.updatePosition(human.transform.position);
		else
			HumanMemory.Add(human.GetInstanceID(), new MemoryEntry (human, human.transform.position));
	}

	public void rememberZombie(GameObject zombie){
		MemoryEntry entry;
		
		if(ZombieMemory.TryGetValue(zombie.GetInstanceID(), out entry))
			entry.updatePosition(zombie.transform.position);
		else
			ZombieMemory.Add(zombie.GetInstanceID(), new MemoryEntry (zombie ,zombie.transform.position));
	}

	public void rememberAmmo(GameObject ammo){
		MemoryEntry entry;
		
		if(AmmoMemory.TryGetValue(ammo.GetInstanceID(), out entry))
			entry.updatePosition(ammo.transform.position);
		else
			AmmoMemory.Add(ammo.GetInstanceID(), new MemoryEntry (ammo ,ammo.transform.position));
	}

	public Dictionary<int, MemoryEntry> getFoodMemory(){

		return FoodMemory;
	
	}

	public Dictionary<int, MemoryEntry> getAmmoMemory(){
		
		return AmmoMemory;
		
	}
	public Dictionary<int, MemoryEntry> getZombieMemory(){
		
		return ZombieMemory;
		
	}

	public Dictionary<int, MemoryEntry> geHumanMemory(){
		
		return HumanMemory;
		
	}

	public void cleanWrongMemories(){
		Bounds bounds = sightCollider.bounds;
		GameObject gObject;


        foreach(MemoryEntry memory in FoodMemory.Values){
            if(bounds.Contains(memory.getLastKnownPosition())){
                gObject = memory.getGameObject();
                if( gObject.transform.position.Equals(memory.getLastKnownPosition()) == false){
                    FoodMemory.Remove(gObject.GetInstanceID());
                }
            }
        }

        foreach(MemoryEntry memory in ZombieMemory.Values){
            if(bounds.Contains(memory.getLastKnownPosition())){
                gObject = memory.getGameObject();
				if( gObject.transform.position.Equals(memory.getLastKnownPosition()) == false){
					ZombieMemory.Remove(gObject.GetInstanceID());
                }
            }
        }

        foreach(MemoryEntry memory in HumanMemory.Values){
            if(bounds.Contains(memory.getLastKnownPosition())){
                gObject = memory.getGameObject();
				if( gObject.transform.position.Equals(memory.getLastKnownPosition()) == false){
					HumanMemory.Remove(gObject.GetInstanceID());
                }
            }
        }

        foreach(MemoryEntry memory in AmmoMemory.Values){
            if(bounds.Contains(memory.getLastKnownPosition())){
                gObject = memory.getGameObject();
				if( gObject.transform.position.Equals(memory.getLastKnownPosition()) == false){
					AmmoMemory.Remove(gObject.GetInstanceID());
                }
            }
        }
	}

	/* ------------------------------------------*/
	/* ----------------- Sensors  ---------------*/
	/* ------------------------------------------*/
	
	public bool IsSeeingFood(){
		return sawFood;
	}

	public bool IsOnFood(){
		return onFood;
	}

	public bool IsOnAmmo ()
	{
		return onAmmo;
	}

	public bool IsSeeingZombie(){
		return sawZombie && zombieSeen.GetComponent<EnemyHealth> ().currentHealth > 0;
	}

	public bool IsSeeingHumanInDanger(){
		return sawHumanInDanger;
	}

	public bool IsGrabbed(){
		return movement.isBeingGrabbed();
	}
	
	public bool IsBitten() {
		return bitten;
	}

	public bool isMoving() {
		return movement.isMoving ();
	}

	public bool isRunning(){

		return isMoving () && movement.isRunning ();
	}

	public bool IsSeeingAmmo(){
		return sawAmmo;
	}

	public int FoodCarried () {
		return hunger.GetFoodCarried ();
	}

	public float HungerLevel() {
		return hunger.GetHungerLevel ();
	}

    public float AmmoLevel()
    {
        return shooting.currentAmmo;
    }

    public IList<Food> FoodsCarried()
    {
        return hunger.foods;
    }

	public bool IsSeeingExitRoute(){
		return sawExitDoor;
	}

	public int HealthLevel() {
		return health.getHealthLevel ();
	}
	
	public bool DidArrivedAtTargetPosition(){
		return Vector3.Distance (transform.position, targetPosition) < 1;
	}

	public bool WasAttacked(){
		if (lastSeenHealth > health.currentHealth) {
			lastSeenHealth = health.currentHealth;
			return true;
		} else {
			return false;
		}
	}

	public bool CanShoot() {
		return shooting.CanAttack ();
	}

	public float getSpeed(){
		return movement.getSpeed ();
	}

	public float getDistanceToZombie(){
		Vector3 distanceVector = zombieSeen.transform.position - transform.position;
		return distanceVector.magnitude;
	}

	public Vector3 getZombieLocation(){
		return zombieSeen.transform.position;
	}


	public bool IsAimingToZombie() {
		// TO REIMPLEMENTED IN NEAR FUTURE
		Ray shootRay = new Ray ();
		RaycastHit shootHit;
		float range = 100f;

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;


		
		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			if (shootHit.collider.gameObject == zombieSeen) {
				EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
				
				// If the EnemyHealth component exist...
				return enemyHealth != null;
			}
		}
		return  false;
	}

    public Transform CurrentPosition()
    {
        return transform.root;
    }

    public Food FoodSeen()
    {
        if (foodSeen)
        {
            return foodSeen.GetComponent<Food>();
        }
        else
        {
            return null;
        }
    }

	public float getHumanTime(){
		return humanTimer;
	}
	
	public IList<HumanState> getFriendship()
	{
 	throw new System.NotImplementedException();
	}

}