using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SelectAllStudentsController : MonoBehaviour
{
    private const string url = "http://localhost/prograch262/library/select_all_students.php";
    [SerializeField] private StudentArrayModel studentArrayModel; 
    void Start()
    {
        StartCoroutine(SendRequest());
    }

    IEnumerator SendRequest()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                studentArrayModel = JsonUtility.FromJson<StudentArrayModel>(www.downloadHandler.text);                
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}
