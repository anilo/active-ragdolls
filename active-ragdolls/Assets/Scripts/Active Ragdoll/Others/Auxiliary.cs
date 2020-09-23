﻿#pragma warning disable 649

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActiveRagdoll {
    // Author: Sergio Abreu García | https://sergioabreu.me

    [Serializable] public struct JointDriveConfig {
        // Variables are exposed in the editor, but are kept readonly from code since
        // changing them would have no effect until assigned to a JointDrive.
        [SerializeField] private float _positionSpring, _positionDamper, _maximumForce;
        public float PositionSpring { get { return _positionSpring; } }
        public float PositionDamper { get { return _positionDamper; } }
        public float MaximumForce { get { return _maximumForce; } }


        public static implicit operator JointDrive(JointDriveConfig config) {
            JointDrive jointDrive = new JointDrive {
                positionSpring = config._positionSpring,
                positionDamper = config._positionDamper,
                maximumForce = config._maximumForce
            };

            return jointDrive;
        }

        public readonly static JointDriveConfig ZERO = new JointDriveConfig
                               { _positionSpring = 0, _positionDamper = 0, _maximumForce = 0};
    }

    public static class Auxiliary {
        /// <summary>
        /// Calculates the normalized projection of the Vector3 'vec'
        /// onto the horizontal plane defined by the orthogonal vector (0, 1, 0)
        /// </summary>
        /// <param name="vec">The vector to project</param>
        /// <returns>The normalized projection of 'vec' onto the horizontal plane</returns>
        public static Vector3 GetFloorProjection(in Vector3 vec) {
            return Vector3.ProjectOnPlane(vec, Vector3.up).normalized;
        }
    }

}
