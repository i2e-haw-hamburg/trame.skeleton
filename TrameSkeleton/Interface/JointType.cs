using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trame
{
    /// <summary>
    /// Joint type.
    /// </summary>
    public enum JointType
    {
        /// <summary>
        /// The UNSPECIFIED
        /// </summary>
        UNSPECIFIED = 0,
        /// <summary>
        /// main body parts
        /// </summary>
        HEAD = 21200,
        NECK = 20100,
        CENTER = 10000,
        SHOULDER_LEFT = 22200,
        SHOULDER_RIGHT = 20200,
        HIP_LEFT = 1100,
        HIP_RIGHT = 100,
        KNEE_LEFT = 1200,
        KNEE_RIGHT = 200,
        ANKLE_LEFT = 1300,
        ANKLE_RIGHT = 300,
        FOOT_LEFT = 1400,
        FOOT_RIGHT = 400,
        ELBOW_LEFT = 22300,
        ELBOW_RIGHT = 20300,
        WRIST_LEFT = 22400,
        WRIST_RIGHT = 20400,
        HAND_LEFT = 22500,
        HAND_RIGHT = 20500,
        // additional body parts like fingers
        THUMB_LEFT = 22610,
        THUMB_LEFT_METACARPAL = 22611,
        THUMB_LEFT_PRIXIMAL = 22612,
        THUMB_LEFT_DISTAL = 22614,
        INDEX_FINGER_LEFT = 22620,
        INDEX_FINGER_LEFT_METACARPAL = 22621,
        INDEX_FINGER_LEFT_PROXIMAL = 22622,
        INDEX_FINGER_LEFT_INTERMEDIATE = 22623,
        INDEX_FINGER_LEFT_DISTAL = 22624,
        MIDDLE_FINGER_LEFT = 22630,
        MIDDLE_FINGER_LEFT_METACARPAL = 22631,
        MIDDLE_FINGER_LEFT_PROXIMAL = 22632,
        MIDDLE_FINGER_LEFT_INTERMEDIATE = 22633,
        MIDDLE_FINGER_LEFT_DISTAL = 22634,
        RING_FINGER_LEFT = 22640,
        RING_FINGER_LEFT_METACARPAL = 22641,
        RING_FINGER_LEFT_PROXIMAL = 22642,
        RING_FINGER_LEFT_INTERMEDIATE = 22643,
        RING_FINGER_LEFT_DISTAL = 22644,
        LITTLE_FINGER_LEFT = 22650,
        LITTLE_FINGER_LEFT_METACARPAL = 22651,
        LITTLE_FINGER_LEFT_PROXIMAL = 22652,
        LITTLE_FINGER_LEFT_INTERMEDIATE = 22653,
        LITTLE_FINGER_LEFT_DISTAL = 22654,
        THUMB_RIGHT = 20601,
        THUMB_RIGHT_METACARPAL = 20611,
        THUMB_RIGHT_PRIXIMAL = 20612,
        THUMB_RIGHT_DISTAL = 20614,
        INDEX_FINGER_RIGHT = 20620,
        INDEX_FINGER_RIGHT_METACARPAL = 20621,
        INDEX_FINGER_RIGHT_PROXIMAL = 20622,
        INDEX_FINGER_RIGHT_INTERMEDIATE = 20623,
        INDEX_FINGER_RIGHT_DISTAL = 20624,
        MIDDLE_FINGER_RIGHT = 20630,
        MIDDLE_FINGER_RIGHT_METACARPAL = 20631,
        MIDDLE_FINGER_RIGHT_PROXIMAL = 20632,
        MIDDLE_FINGER_RIGHT_INTERMEDIATE = 20633,
        MIDDLE_FINGER_RIGHT_DISTAL = 20634,
        RING_FINGER_RIGHT = 20640,
        RING_FINGER_RIGHT_METACARPAL = 20641,
        RING_FINGER_RIGHT_PROXIMAL = 20642,
        RING_FINGER_RIGHT_INTERMEDIATE = 20643,
        RING_FINGER_RIGHT_DISTAL = 20644,
        LITTLE_FINGER_RIGHT = 20650,
        LITTLE_FINGER_RIGHT_METACARPAL = 20651,
        LITTLE_FINGER_RIGHT_PROXIMAL = 20652,
        LITTLE_FINGER_RIGHT_INTERMEDIATE = 20653,
        LITTLE_FINGER_RIGHT_DISTAL = 20654
    }
    
    public static class Extension
    {
        /// <summary>
        /// To the int.
        /// </summary>
        /// <returns>The int.</returns>
        /// <param name="jt">Jt.</param>
        public static int ToInt(this JointType jt)
        {
            return (int) Convert.ChangeType(jt, TypeCode.Int32);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jt"></param>
        /// <returns>The parent joint type of a joint type</returns>
        public static JointType Parent(this JointType jt)
        {
            var map = new Dictionary<JointType, JointType>
            {
                {JointType.ELBOW_LEFT, JointType.SHOULDER_LEFT},
                {JointType.ELBOW_RIGHT, JointType.SHOULDER_RIGHT},
                {JointType.WRIST_LEFT, JointType.ELBOW_LEFT},
                {JointType.WRIST_RIGHT, JointType.ELBOW_RIGHT},
                {JointType.HAND_LEFT, JointType.WRIST_LEFT},
                {JointType.HAND_RIGHT, JointType.WRIST_RIGHT},
            };
            return map[jt];
        }
    }
}
