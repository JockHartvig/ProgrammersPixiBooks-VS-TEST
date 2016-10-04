using System;
using ProgrammersPixiBooks_VS_UnitTest_VB;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersPixiBooks_VS_UnitTest
{
    [TestClass]
    public class MyClassVb_UnitTest
    {
        [TestMethod]
        public void TC01_MyClassVb_Call2MySubClass_DefaultConstructor_UnitTest()
        {
            string _VarStringMySubClass = "";

            MyClassVb _Target = new MyClassVb();
            _VarStringMySubClass = _Target.CallMySubClass();
            Assert.AreEqual("From MySubClassVb", _VarStringMySubClass, "_VarStringMySubClass=" + _VarStringMySubClass);
        }

        [TestMethod]
        public void TC02_MyClassVb_Call2MySubClass_ConstructorDependencyInjection_UnitTest()
        {
            string _VarStringMySubClass = "";

            MyClassVb _Target = new MyClassVb(new MySubClassVb());
            _VarStringMySubClass = _Target.CallMySubClass();
            Assert.AreEqual("From MySubClassVb", _VarStringMySubClass, "_VarStringMySubClass=" + _VarStringMySubClass);
        }

        [TestMethod]
        public void TC03_MyClassVb_Call2MySubClass_SetterDependencyInjection_UnitTest()
        {
            string _VarStringMySubClass = "";

            MyClassVb _Target = new MyClassVb(new StubMySubClassVb()); // First set constructor DI to the stub
            _Target.SetIMyClassSub(new MySubClassVb()); // Then overide the constructor DI with the setter DI
            _VarStringMySubClass = _Target.CallMySubClass();
            Assert.AreEqual("From MySubClassVb", _VarStringMySubClass, "_VarStringMySubClass=" + _VarStringMySubClass);
        }


        [TestMethod]
        public void TC04_MyClassVb_Call2StubMySubClass_ConstructorDependencyInjection_UnitTest()
        {
            string _VarStringMySubClass = "";

            MyClassVb _Target = new MyClassVb(new StubMySubClassVb());
            _VarStringMySubClass = _Target.CallMySubClass();
            Assert.AreEqual("From StubMySubClassVb", _VarStringMySubClass, "_VarStringMySubClass=" + _VarStringMySubClass);
        }

        [TestMethod]
        public void TC05_MyClassVb_Call2StubMySubClass_SetterDependencyInjection_UnitTest()
        {
            string _VarStringMySubClass = "";

            MyClassVb _Target = new MyClassVb(new MySubClassVb()); // First set constructor DI to the MySubClass
            _VarStringMySubClass = _Target.CallMySubClass();
            Assert.AreEqual("From MySubClassVb", _VarStringMySubClass, "_VarStringMySubClass=" + _VarStringMySubClass);

            _Target.SetIMyClassSub(new StubMySubClassVb()); // Then overide the constructor DI with the setter DI to stub
            _VarStringMySubClass = _Target.CallMySubClass();
            Assert.AreEqual("From StubMySubClassVb", _VarStringMySubClass, "_VarStringMySubClass=" + _VarStringMySubClass);
        }

        public class StubMySubClassVb : IMySubClassVb
        {
            public string VarStringMySubClass { get; set; }

            public StubMySubClassVb()
            {
                VarStringMySubClass = "From StubMySubClassVb";
            }
        }
    }
}
