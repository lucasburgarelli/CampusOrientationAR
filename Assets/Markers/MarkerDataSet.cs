using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarkerDataSet : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro txtClassroom, txtDatetimestart, txtDatetimeend, txtCoursename, txtDescription, txtNameteacher;
    private void Start()
    {
        var dataGetter = new DataGetter();
        CompleteClass completeClass = dataGetter.GetCompleteByClassroom(gameObject.name);

        txtClassroom.text = completeClass.Classroom;
        txtCoursename.text = completeClass.Coursename;
        txtNameteacher.text = completeClass.Nameteacher;
        txtDescription.text = completeClass.Description;
        txtDatetimestart.text = completeClass.Datetimestart.ToLongTimeString();
        txtDatetimeend.text = completeClass.Datetimeend.ToLongTimeString();

    }
}
