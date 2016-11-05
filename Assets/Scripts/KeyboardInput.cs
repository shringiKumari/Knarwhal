using UnityEngine;

class KeyboardInput {
  KeyCode[] rotateLeft = { KeyCode.A, KeyCode.J };
  KeyCode[] rotateRight = { KeyCode.D, KeyCode.L };
  KeyCode[] move = { KeyCode.W, KeyCode.I };
  KeyCode[] dash = { KeyCode.Q, KeyCode.U };
  KeyCode[] spout = { KeyCode.E, KeyCode.O };

  public float Rotate(int id) {
    var left = Input.GetKey(rotateLeft[id]) ? 1 : 0;
    var right = Input.GetKey(rotateRight[id]) ? -1 : 0;
    return left + right;
  }

  public bool Move(int id) {
    return Input.GetKey(move[id]);
  }

  public bool Dash(int id) {
    return Input.GetKey(dash[id]);
  }

  public bool Spout(int id) {
    return Input.GetKey(spout[id]);
  }
}
