using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class JointPosition : MonoBehaviour 
{
    public Windows.Kinect.JointType _jointType;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
	
	void Update () 
    {
        if (_bodySourceManager == null)
        {
            return;
        }

        _bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
        if (_bodyManager == null)
        {
            return;
        }

		//get available bodies
        Body[] data = _bodyManager.GetData();
        if (data == null)
        {
            return;
        }

		//process each body
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
				//change object position
                var pos = body.Joints[_jointType].Position;
				this.gameObject.transform.position = new Vector3(pos.X*5, pos.Y*5, pos.Z*5);
                break;
            }
        }
	}
}