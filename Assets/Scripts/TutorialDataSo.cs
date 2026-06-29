using UnityEngine;

[CreateAssetMenu(fileName = "NewTutorialData", menuName = "Settings/Tutorial Data")]
public class TutorialDataSo : ScriptableObject
{
    public string Title;
    [TextArea(3, 5)] public string Description;

    [Tooltip("Si ponés más de uno, la UI los reproducirá en bucle como un GIF.")]
    public Sprite[] AnimationFrames;
    public float FrameRate = 0.1f; // Velocidad de la animación
}