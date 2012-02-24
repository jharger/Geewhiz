using UnityEngine;
using System.Collections;

public class Listenable : MonoBehaviour {

    private ArrayList listeners;
    private ArrayList removers;

	protected void Awake () {
	    listeners = new ArrayList ();
        removers = new ArrayList ();
	}
	
    public void AddListener (Component c) {
        listeners.Add (c);
    }

    public void RemoveListener (Component c) {
        removers.Add (c);
    }

    protected void Shout (string message, object obj = null) {
        foreach (Component c in removers) {
            listeners.Remove (c);
        }
        removers.Clear ();

        foreach (Component c in listeners) {
            c.SendMessage (message, obj, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnDestroy () {
        Shout ("Destroyed", gameObject);
    }
}
