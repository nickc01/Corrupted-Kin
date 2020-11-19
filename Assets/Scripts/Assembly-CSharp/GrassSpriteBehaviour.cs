using UnityEngine;

public class GrassSpriteBehaviour : MonoBehaviour
{
	public bool isWindy;
	public bool noPushAnimation;
	public GameObject deathParticles;
	public GameObject deathParticlesWindy;
	public GameObject cutEffectPrefab;
	public AudioClip[] pushSounds;
	public AudioClip[] cutSounds;
	public string idleAnimation;
	public string pushAnimation;
	public string cutAnimation;
	public string idleWindyAnimation;
	public string pushWindyAnimation;
}
