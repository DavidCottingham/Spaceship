using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	
	//Spawning data
	private float spawnSpeed = 2.25f; //time between ship spawns
	private float enemySpeed = 7.0f;
	private float timeSinceLastSpawn;
	private float chanceOfSecond = 30;
	private Quaternion enemyRotation;
	private float enemyMaxSpeed = 14.9f;
	
	//Difficulty data
	private Vector3[] spawnPositions = new Vector3[3];
	private Queue<int> pastColumns = new Queue<int>();

	// Use this for initialization
	void Start () {
		spawnPositions[0] = new Vector3(0.0f, 32.0f, 0.0f);
		spawnPositions[1] = new Vector3(10.0f, 32.0f, 0.0f);
		spawnPositions[2] = new Vector3(-10.0f, 32.0f, 0.0f);
		
		//TODO: populate queue randomly
		//Temp way of populating queue;
		pastColumns.Enqueue(0);
		pastColumns.Enqueue(1);
		pastColumns.Enqueue(2);
		
		enemyRotation = enemy.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= spawnSpeed) {			
			//roll dice for spawning 2
			//else, do regular spawn.
			int roll = Random.Range(1,101);
			
			GameObject newEnemy; //need reference var to set speed upon instantiation
			
			//Instantiating with current enemySpeed
			if (roll <= chanceOfSecond) {
				//spawn 2
				int firstPos = choosePosition();
				newEnemy = (GameObject) Instantiate(enemy, spawnPositions[firstPos], enemyRotation);
				EnemyFlight ef = newEnemy.GetComponent<EnemyFlight>();
				ef.Speed = enemySpeed;
				
				newEnemy = (GameObject) Instantiate(enemy, spawnPositions[choosePosition(firstPos)], enemyRotation);
				ef = newEnemy.GetComponent<EnemyFlight>();
				ef.Speed = enemySpeed;
			} else {
				// one position
				newEnemy = (GameObject) Instantiate(enemy, spawnPositions[choosePosition()], enemyRotation);
				EnemyFlight ef = newEnemy.GetComponent<EnemyFlight>();
				ef.Speed = enemySpeed;
			}
			timeSinceLastSpawn = 0.0f; //reset
		}
	}
	
	int choosePosition(int exclude = -1){
		//neglect check first. In current implementation, exclude should never be neglected, so don't worry about for loop checking for it.
		for (int i = 0; i < 3; ++i) {
			if (!pastColumns.Contains(i)) {
				pastColumns.Enqueue(i);
				//counterTick(i);
				//Debug.Log("Enqueued neglected " + i + ": " + queueString());
				pastColumns.Dequeue();
				//Debug.Log("Dequeued top: " + queueString());
				return i; //exclusion takes priority, return it.
			}
		}
	
		//if no neglected columns, use the random choice
		int spawnPosChoice = 0; //never use default 0
		if (exclude != -1) {	//there is an exclusion
			//instead of randomly chooing between 3, choose between 2. which number is "mapped" to which position is chosen randomly.
			
			//if excluding pos 0, randomly choose 0 or 1 where 0=2 and 1=1
			//if 1, randomly choose 0 or 1 where 0=0 and 1=2
			//if 2, randomly choose 0 or 1 where 0=0 and 1=1 (no remapping needed because using 0 & 1)
			int remappingRand = Random.Range(0,2);
			switch (exclude) {
				case 0:
					if (remappingRand == 0) { spawnPosChoice = 2; } //0 =2
					else { spawnPosChoice = remappingRand; }
					break;
				case 1:
					if (remappingRand == 1) { spawnPosChoice = 2; } //1=2
					else { spawnPosChoice = remappingRand; }
					break;
				default:
					spawnPosChoice = remappingRand;
					break;
			}
		} else {	//no exclusions, choose random from all choices	
			spawnPosChoice = Random.Range(0,3);
		}
		
		// exlcusions or not, return random choice after queue maintainence
		pastColumns.Enqueue(spawnPosChoice);
		pastColumns.Dequeue();
		
		return spawnPosChoice; 
	}
	
	void IncreaseSpeed() {
		//spawn speed
		if (spawnSpeed > 0.76f) { //+.01 to account for floating point inaccuracies.
			spawnSpeed -= 0.05f;
		}
		
		//calc enemySpeed
		//get all enemies array w/ tag
		//iterate all enemies (coroutine?)
		//setspeed
		if (enemySpeed <= enemyMaxSpeed) {
			enemySpeed += 0.25f;
		}
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in enemies) {
			EnemyFlight ef = enemy.GetComponent<EnemyFlight>(); //getting script component
			ef.Speed = enemySpeed; //use property set call (public variable)
		}
	}
	
	//FIXME use get component here?
	void IncreaseSpawnChance() {
		//spawn second chance
		if (chanceOfSecond < 84.9f) {
			chanceOfSecond += 1.0f;
		}
	}
}

/*
//Never column more than once
int spawnPosChoice = 0;
while (spawnPosChoice == lastPosition) {
	spawnPosChoice = Random.Range(0, 3);
}
lastPosition = spawnPosChoice;
return spawnPositions[spawnPosChoice];
*/
