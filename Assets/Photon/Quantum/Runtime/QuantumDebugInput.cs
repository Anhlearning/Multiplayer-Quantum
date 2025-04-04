namespace Quantum {
  using Photon.Deterministic;
  using UnityEngine;

  /// <summary>
  /// A Unity script that creates empty input for any Quantum game.
  /// </summary>
  public class QuantumDebugInput : MonoBehaviour {

    private void OnEnable() {
      QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
    }
    public void PollInput(CallbackPollInput callback) {
      Quantum.Input i = new Quantum.Input();
      FP  x= 0;
      FP  y= 0;
      
      callback.SetInput(i, DeterministicInputFlags.Repeatable);
    }
  }
}
