using System;
using Trame;
using Trame.Implementation.Skeleton;
using TrameSkeleton.Math;
using Xunit;

namespace TrameUnitTest
{
    public class SkeletonTest
    {
            
        [Fact]
        public void TestUpdate()
        {
            var s = Creator.GetNewDefaultSkeleton<InMapSkeleton>();
            var head = new OrientedJoint {JointType = JointType.HEAD, Point = new Vector3(1, 2, 3)};
            s.UpdateSkeleton(JointType.HEAD, head);

            var head2 = s.GetJoint(JointType.HEAD);
            Assert.Equal(head.Point, head2.Point);
            Assert.Equal(head, head2);

            Assert.Equal(3, s.Root.GetChildren().Count);
        }
       
    }
}
