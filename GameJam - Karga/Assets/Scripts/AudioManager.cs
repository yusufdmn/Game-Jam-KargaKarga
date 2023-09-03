using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Singleton Definiton
    private static AudioManager instance;       // ******Definition of Singleton********
    public static AudioManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] AudioSource collectPiece;
    [SerializeField] AudioSource monsterDie;
    [SerializeField] AudioSource getHurt;
    [SerializeField] AudioSource attack;

    public void PlayCollectPiece(){
        collectPiece.Play();
    }
    public void PlayMonsterDie(){
        monsterDie.Play();
    }
    public void PlayGetHurt(){
        getHurt.Play();
    }
    public void PlayAttack(){
        attack.Play();
    }

}
