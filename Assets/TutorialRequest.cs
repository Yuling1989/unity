using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TutorialRequest : MonoBehaviour
{
    #region GET
    public InputField inputField;
    public Text resultLabel;
    #endregion


    public InputField lhsField, rhsField;
    public Dropdown operatorSelector;
    public Text calcResultLabel;


  
    public void OnCalcClick()
    {
        StartCoroutine(SendCalcHandler());

    }
    IEnumerator SendCalcHandler()
    {
        string uri = "http://wixart.ddns.net/tutorial/arithmetic.php";
        WWWForm form = new WWWForm();
        form.AddField("lhs", lhsField.text);
        form.AddField("rhs", rhsField.text);
        //form.AddField("operator", operatorSelector.captionText.text);
        string[] arr = new string[] { "+", "-", "*", "/" };
        form.AddField("operator", arr[operatorSelector.value]);

        UnityWebRequest request = UnityWebRequest.Post(uri, form);
        yield return request.SendWebRequest();

        calcResultLabel.text = "=" + request.downloadHandler.text;


    }
    /* public void OnSendClick() {
       StartCoroutine(SendStringHandler());

   }*/



    /* IEnumerator SendStringHandler() {
         string uri = "http://wixart.ddns.net/tutorial/upper.php";
         //uri += $"?str={inputField.text}"; //2018版本
         uri += "?str=" + inputField.text;   //2017版本

        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

         string result = request.downloadHandler.text;
         resultLabel.text = result;
     }*/



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
