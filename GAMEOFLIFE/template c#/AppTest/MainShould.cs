using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;

namespace AppTest
{
    [TestFixture]
    public class MainShould
    {
        [Test]
        public void Write_Hello()
        {
            Check.That(Main.Hello()).IsEqualTo("Hello");
        }
    }
}
