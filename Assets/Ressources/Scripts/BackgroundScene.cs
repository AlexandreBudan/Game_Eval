using UnityEngine;

public class BackgroundScene : MonoBehaviour
{
    public Material automnBackground;
    public Material winterBackground;
    public Material grasslandBackground;
    public Material tropicsBackground;

    void Start()
    {
        // Cr�er un tableau des mat�riaux de skybox
        Material[] skyboxes = new Material[] { automnBackground, winterBackground, grasslandBackground, tropicsBackground };

        // S�lectionner un mat�riau de skybox au hasard
        Material randomSkybox = skyboxes[Random.Range(0, skyboxes.Length)];

        // Appliquer le mat�riau s�lectionn� comme skybox
        RenderSettings.skybox = randomSkybox;

        GameObject.Find("WindSound").GetComponent<AudioSource>().Play(0);
    }

    void Update()
    {
        // Mettez � jour la sc�ne si n�cessaire
    }
}
