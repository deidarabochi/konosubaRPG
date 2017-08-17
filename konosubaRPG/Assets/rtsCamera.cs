using UnityEngine;

public class rtsCamera : MonoBehaviour
{
	private const int LevelArea = 100;

	private const int ScrollArea = 25;
	private const int ScrollSpeed = 15;

	public Camera camera;

	void Start()
	{
		camera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
		// Init camera translation for this frame.
		var translation = Vector3.zero;

		// Move camera with arrow keys
		//translation += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		// Move camera with mouse
		if (Input.mousePosition.x < ScrollArea)
		{
			translation += Vector3.right * -ScrollSpeed * Time.deltaTime;
		}
		if (Input.mousePosition.x >= Screen.width - ScrollArea)
		{
			translation += Vector3.right * ScrollSpeed * Time.deltaTime;
		}
		if (Input.mousePosition.y < ScrollArea)
		{
			translation += Vector3.up * -ScrollSpeed * Time.deltaTime;
		}
		if (Input.mousePosition.y > Screen.height - ScrollArea)
		{
			translation += Vector3.up * ScrollSpeed * Time.deltaTime;
		}

		// Keep camera within level
		var desiredPosition = camera.transform.position + translation;
		if (desiredPosition.x < -LevelArea || LevelArea < desiredPosition.x)
		{
			translation.x = 0;
		}
		if (desiredPosition.y < -LevelArea || LevelArea < desiredPosition.y)
		{
			translation.y = 0;
		}

		// Finally move camera parallel to world axis
		camera.transform.position += translation;
	}
}
