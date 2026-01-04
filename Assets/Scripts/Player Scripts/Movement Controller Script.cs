using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class MovementControllerScript : MonoBehaviour
{
    [SerializeField] private CharacterController _charecterController;   //First is tag Second is name
    [SerializeField] private CinemachineCamera _cinCam;  //First is tag Second is name

    public Vector2 _move;

    public float currentSpeed; // Speed of player
    public float walkSpeed;
    public float sprintSpeed;

    private void Start() // выдаём движ в первый запуск
    {
        currentSpeed = walkSpeed;

        Debug.Log("Start!");
    }

    public void OnSprint(InputValue val)
    {
        if (val.Get<float>() > 0.5f)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    } 

    public void OnMove(InputValue val)
    {
        _move = val.Get<Vector2>();
    }

    private Vector3 GetForward() //обнуляем координату Y у камеры чтоб персонаж не двигался в лишнюю сторону
    {
        Vector3 forward = _cinCam.transform.forward;
        forward.y = 0;

        return forward.normalized;
    }

    private Vector3 GetRight() //обнуляем координату Y у камеры чтоб персонаж не двигался в лишнюю сторону
    {
        Vector3 right = _cinCam.transform.right;
        right.y = 0;

        return right.normalized;

    }

    private void Update() //десь движ каждый кадр происходит
    {
        _charecterController.Move((GetForward() * _move.y + GetRight() * _move.x) * Time.deltaTime * currentSpeed);

    }



}
