using SVM.SimpleMachineLanguage;
using SVM.VirtualMachine;
using Moq;

namespace SVMTest
{
    [TestClass]
    public class IncrTest
    {
        [TestMethod]
        public void IsIncreasing()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());
            Incr incr = new Incr();

            incr.VirtualMachine = virtualMachine.Object;
            incr.VirtualMachine.Stack.Push(5);
            incr.Run();
            Assert.AreEqual(6, incr.VirtualMachine.Stack.Peek());
        }

        [TestMethod]
        public void IsInteger()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());
            Incr incr = new Incr();

            incr.VirtualMachine = virtualMachine.Object;
            incr.VirtualMachine.Stack.Push(5);
            Assert.AreEqual("Int32", incr.VirtualMachine.Stack.Peek().GetType().Name);
        }
    }
}


