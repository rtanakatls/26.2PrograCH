using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class InsertStudentController : MonoBehaviour
{
    private const string url = "http://localhost/prograch262/library/insert_student.php";

    void Start()
    {
        StartCoroutine(SendRequest("Leonardo", "Guillen"));
    }

    IEnumerator SendRequest(string name, string lastname)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("lastname", lastname);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Se insertó con éxito");
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }



}
