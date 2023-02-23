using Moq;
using SVM.SimpleMachineLanguage;
using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVMTest
{

    [TestClass]
    public class DecrTest
    {
        [TestMethod]
        public void IsDecreasing()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());
            Decr decr = new Decr();

            decr.VirtualMachine = virtualMachine.Object;
            decr.VirtualMachine.Stack.Push(5);
            decr.Run();
            Assert.AreEqual(4, decr.VirtualMachine.Stack.Peek());
        }

        [TestMethod]
        public void IsInteger()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());
            Decr decr = new Decr();

            decr.VirtualMachine = virtualMachine.Object;
            decr.VirtualMachine.Stack.Push(5);
            Assert.AreEqual("Int32", decr.VirtualMachine.Stack.Peek().GetType().Name);
        }

    }
}
