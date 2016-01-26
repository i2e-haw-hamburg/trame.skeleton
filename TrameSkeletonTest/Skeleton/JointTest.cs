using Trame;
using Trame.Implementation.Skeleton;
using NUnit.Framework;

namespace TrameUnitTest
{
    [TestFixture]
    public class JointTest
    {
        private IJoint root;
        
        [SetUp]
        public void SetUp()
        {
            root = Creator.GetNewDefaultSkeleton().Root;
        }

        [Test]
        public void TestFindChild()
        {
            var neck = root.FindChild(JointType.NECK);

            Assert.AreEqual(JointType.NECK, neck.JointType);
            // with simple find, only the first generation will be searched - result should be an unspecified element
            var head = root.FindChild(JointType.HEAD);
            Assert.AreEqual(JointType.UNSPECIFIED, head.JointType);
            Assert.AreEqual(false, head.Valid);
            // search over more then one step with find
            head = neck.FindChild(JointType.HEAD);
            Assert.AreEqual(JointType.HEAD, head.JointType);
            Assert.AreEqual(true, head.Valid);
        }

        [Test]
        public void TestDeepFind()
        {
            var neck = root.DeepFind(JointType.NECK);
            Assert.AreEqual(JointType.NECK, neck.JointType);

            var head = root.DeepFind(JointType.HEAD);
            Assert.AreEqual(JointType.HEAD, head.JointType);
            Assert.AreEqual(true, head.Valid);

            var kneeLeft = neck.DeepFind(JointType.KNEE_LEFT);
            Assert.AreEqual(JointType.UNSPECIFIED, kneeLeft.JointType);
            Assert.AreEqual(false, kneeLeft.Valid);
        }
        
        [TearDown]
        public void TearDown()
        {
            root = null;
        }
    }
}
