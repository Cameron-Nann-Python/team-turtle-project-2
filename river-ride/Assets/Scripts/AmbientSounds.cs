using UnityEngine;
public class AmbientSounds : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name = "Birds";
        public AudioClip[] clips;                   
        public Vector2 interval = new Vector2(5f, 15f);          
        public Vector2 pitch = new Vector2(0.9f, 1.1f);
        public Vector2 distance = new Vector2(5f, 25f);           
        public Vector2 height = new Vector2(0f, 3f);
        [Range(0f, 1f)] public float volume = 1f;

        [HideInInspector] public float timer;
    }
    public Transform followTarget;
    public Sound[] sounds;
    void Start()
    {
        foreach (var s in sounds)
            s.timer = Random.Range(0f, s.interval.y);
    }

    void Update()
    {
        Vector3 center = followTarget ? followTarget.position : transform.position;

        foreach (var s in sounds)
        {
            s.timer -= Time.deltaTime;
            if (s.timer > 0f || s.clips == null || s.clips.Length == 0) continue;

            s.timer = Random.Range(s.interval.x, s.interval.y);
            Play(s, center);
        }
    }

    void Play(Sound s, Vector3 center)
    {
        AudioClip clip = s.clips[Random.Range(0, s.clips.Length)];
        if (!clip) return;

        Vector2 flat = Random.insideUnitCircle.normalized * Random.Range(s.distance.x, s.distance.y);
        Vector3 pos = center + new Vector3(flat.x, Random.Range(s.height.x, s.height.y), flat.y);

        var go = new GameObject("Ambient_" + clip.name);
        go.transform.position = pos;

        var src = go.AddComponent<AudioSource>();
        src.clip = clip;
        src.pitch = Random.Range(s.pitch.x, s.pitch.y);
        src.volume = s.volume;
        src.spatialBlend = 1f;    
        src.minDistance = s.distance.x;
        src.maxDistance = s.distance.y * 2f;
        src.Play();

        Destroy(go, clip.length / src.pitch + 0.1f);
    }
}