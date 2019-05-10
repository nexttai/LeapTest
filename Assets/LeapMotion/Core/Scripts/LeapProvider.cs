/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2018.                                 *
 * Leap Motion proprietary and confidential.                                  *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;
using System;

namespace Leap.Unity {

  using TestHandPose = TestHandFactory.TestHandPose;

  /// <summary>
  /// Provides Frame object data to the Unity application by firing events as soon
  ///   /// as Frame data is available. Frames contain all currently tracked Hands in view
  ///     /// of the Leap Motion Controller.
  ///     // �t���[���f�[�^�����p�\�ɂȂ�Ƃ����ɃC�x���g�𔭐������邱�Ƃɂ���āAUnity�A�v��
  ///     // �P�[�V�����Ƀt���[���I�u�W�F�N�g�f�[�^��񋟂��܂��B�t���[���ɂ́ALeap Motion Controlle
  ///     // r���猩�Č��ݒǐՂ���Ă��邷�ׂĂ̎肪�܂܂�Ă��܂��B
  /// </summary>
  public abstract class LeapProvider : MonoBehaviour {

    public TestHandPose editTimePose = TestHandPose.HeadMountedA;

    public event Action<Frame> OnUpdateFrame;
    public event Action<Frame> OnFixedFrame;

    /// <summary>
    /// The current frame for this update cycle, in world space. 
    ///     /// 
    ///         /// IMPORTANT!  This frame might be mutable!  If you hold onto a reference
    ///             /// to this frame, or a reference to any object that is a part of this frame,
    ///                 /// it might change unexpectedly.  If you want to save a reference, make sure
    ///                     /// to make a copy.
    ///                     // ���[���h��Ԃɂ����邱�̍X�V�T�C�N���̌��݂̃t���[���B�d�v�I���̃t���[���͕ύX��
    ///                     // �\��������܂���I���̃t���[���ւ̎Q�ƁA�܂��͂��̃t���[���̈ꕔ�ł���I�u�W�F�N
    ///                     // �g�ւ̎Q�Ƃ�ێ����Ă���ƁA�\�z�O�ɕω�����\��������܂��B�Q�Ƃ�ۑ���������
    ///                     // ���́A�K���R�s�[���쐬���Ă��������B
    /// </summary>
    public abstract Frame CurrentFrame { get; }

    /// <summary>
    /// The current frame for this fixed update cycle, in world space.
    /// 
    /// IMPORTANT!  This frame might be mutable!  If you hold onto a reference
    /// to this frame, or a reference to any object that is a part of this frame,
    /// it might change unexpectedly.  If you want to save a reference, make sure
    /// to make a copy.
    /// </summary>
    public abstract Frame CurrentFixedFrame { get; }

    protected void DispatchUpdateFrameEvent(Frame frame) {
      if (OnUpdateFrame != null) {
        OnUpdateFrame(frame);
      }
    }

    protected void DispatchFixedFrameEvent(Frame frame) {
      if (OnFixedFrame != null) {
        OnFixedFrame(frame);
      }
    }

  }

  public static class LeapProviderExtensions {

    public static Leap.Hand MakeTestHand(this LeapProvider provider, bool isLeft) {
      return TestHandFactory.MakeTestHand(isLeft, Hands.Provider.editTimePose)
                            .Transform(UnityMatrixExtension.GetLeapMatrix(Hands.Provider.transform));
    }

  }
}
