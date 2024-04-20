using UnityEngine;

public class Player2 : MonoBehaviour
{
    private ElevatorDetection elevatorDetection; 
    private ElevatorButton currentButton; 
    public float moveSpeed = 5f;
    public float rotationSpeed = 95f;

    void Start()
    {
        elevatorDetection = GetComponent<ElevatorDetection>();
    }
    public ElevatorButton GetButton()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (elevatorDetection.button != null)
            {

                elevatorDetection.button.Press();
            }
        }
        return currentButton;
    }

    void Update()
    {

      
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        //TODO: This function should be called from your player script
        //      You will need to create a reference to ElevatorDetection in your player script and assign it as a reference


        // add if (input.getkeydown code here delete public

        

        // Calculate rotation
        Vector3 rotation = new Vector3(verticalInput, horizontalInput, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

    }




}
