using System;
using System.Collections.Generic;
using Trame;
using Trame.Implementation.Skeleton;
using Xunit;

namespace TrameUnitTest
{
    public class JointTest : IDisposable
    {
        private IJoint root;
        
        public JointTest()
        {
            root = Creator.GetNewDefaultSkeleton().Root;
        }

        [Fact]
        public void TestFindChild()
        {
            var neck = root.FindChild(JointType.NECK);

            Assert.Equal(JointType.NECK, neck.JointType);
            // with simple find, only the first generation will be searched - result should be an unspecified element
            var head = root.FindChild(JointType.HEAD);
            Assert.Equal(JointType.UNSPECIFIED, head.JointType);
            Assert.Equal(false, head.Valid);
            // search over more then one step with find
            head = neck.FindChild(JointType.HEAD);
            Assert.Equal(JointType.HEAD, head.JointType);
            Assert.Equal(true, head.Valid);
        }

        [Fact]
        public void TestDeepFind()
        {
            var neck = root.DeepFind(JointType.NECK);
            Assert.Equal(JointType.NECK, neck.JointType);

            var head = root.DeepFind(JointType.HEAD);
            Assert.Equal(JointType.HEAD, head.JointType);
            Assert.Equal(true, head.Valid);

            var kneeLeft = neck.DeepFind(JointType.KNEE_LEFT);
            Assert.Equal(JointType.UNSPECIFIED, kneeLeft.JointType);
            Assert.Equal(false, kneeLeft.Valid);
        }
        

        public void Dispose()
        {
            root = null;
        }
    }
}
