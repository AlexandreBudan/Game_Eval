using UnityEngine;

public class BackgroundScene : MonoBehaviour
{
    public Material automnBackground;
    public Material winterBackground;
    public Material grasslandBackground;
    public Material tropicsBackground;

    void Start()
    {
        // Créer un tableau des matériaux de skybox
        Material[] skyboxes = new Material[] { automnBackground, winterBackground, grasslandBackground, tropicsBackground };

        // Sélectionner un matériau de skybox au hasard
        Material randomSkybox = skyboxes[Random.Range(0, skyboxes.Length)];

        // Appliquer le matériau sélectionné comme skybox
        RenderSettings.skybox = randomSkybox;

        GameObject.Find("WindSound").GetComponent<AudioSource>().Play(0);
    }

    void Update()
    {
        // Mettez à jour la scène si nécessaire
    }
}
