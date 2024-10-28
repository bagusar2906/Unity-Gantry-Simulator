using UnityEngine;

public class XAxisJointController : MonoBehaviour
{
    public float targetVelocity = 0.5f;  // Set desired sliding speed
    public float positionSpring = 100f; // Spring to keep joint in position
    public float positionDamper = 10000f;  // Damper to slow down movement

    private ConfigurableJoint configurableJoint;

    // Start is called before the first frame update
    void Start()
    {
        configurableJoint = GetComponent<ConfigurableJoint>();

        // Configure X Drive (or Y/Z Drive based on your axis)
        JointDrive drive = new JointDrive
        {
            positionSpring = positionSpring,
            positionDamper = positionDamper,
            maximumForce = Mathf.Infinity
        };

        // Apply drive to the desired axis
        configurableJoint.xDrive = drive;
    }

    // Update is called once per frame
    void Update()
    {
        // Control Target Position with Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 newTarget = configurableJoint.targetPosition;
            newTarget.x = -newTarget.x;  // Reverse direction
            configurableJoint.targetPosition = newTarget;
        }

        // Control Target Velocity with Input
        Vector3 velocity = configurableJoint.targetVelocity;
        velocity.x = targetVelocity;
        configurableJoint.targetVelocity = velocity;
    }
}