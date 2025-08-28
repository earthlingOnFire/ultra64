using UnityEngine;

namespace LibSM64 {
  public class MarioCameraController : MonoBehaviour {
    Transform camera;
    float rotationX;
    float rotationY;
    Vector3 defaultCameraTarget = new Vector3(0f, 7f, -5.5f);
    Vector3 defaultCameraRotation = new Vector3(20f, 0f, 0f);

    public void Start() {
      rotationX = 0;
      rotationY = 0;
      camera = Camera.main.transform;
    }

    public void Update() {
      if (OptionsManager.Instance.paused) return;


      camera.SetPositionAndRotation(
          base.transform.position + defaultCameraTarget, Quaternion.Euler(defaultCameraRotation)
      );

      Vector2 vector2 = InputManager.Instance.InputSource.Look.ReadValue<Vector2>();
      if (!CameraController.Instance.reverseY) {
        rotationX += vector2.y * (OptionsManager.Instance.mouseSensitivity / 10f);
      }
      else {
        rotationX -= vector2.y * (OptionsManager.Instance.mouseSensitivity / 10f);
      }
      if (!CameraController.Instance.reverseX) {
        rotationY += vector2.x * (OptionsManager.Instance.mouseSensitivity / 10f);
      }
      else {
        rotationY -= vector2.x * (OptionsManager.Instance.mouseSensitivity / 10f);
      }
      if (rotationY > 180f) {
        rotationY -= 360f;
      }
      else if (rotationY < -180f) {
        rotationY += 360f;
      }
      rotationX = Mathf.Clamp(rotationX, -69f, 109f);

      float num3 = 2.5f;
      if (Physics.Raycast(base.transform.position + Vector3.up * 0.625f, Vector3.up, 2.5f, LayerMaskDefaults.Get(LMD.Environment))) {
        num3 = 0.625f;
      }

      Vector3 vector3 = base.transform.position + Vector3.up * num3;
      camera.RotateAround(vector3, Vector3.left, rotationX);
      camera.RotateAround(vector3, Vector3.up, rotationY);

      if (Physics.SphereCast(vector3, 0.25f, camera.position - vector3, out var hitInfo5, Vector3.Distance(vector3, camera.position), LayerMaskDefaults.Get(LMD.Environment))) {
        camera.position = hitInfo5.point + 0.5f * hitInfo5.normal;
      }
    }
  }
}
