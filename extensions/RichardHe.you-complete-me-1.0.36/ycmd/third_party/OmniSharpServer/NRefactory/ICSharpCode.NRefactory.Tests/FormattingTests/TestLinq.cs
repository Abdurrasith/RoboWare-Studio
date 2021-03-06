// TestLinq.cs
//  
// Author:
//       Luís Reis <luiscubal@gmail.com>
// 
// Copyright (c) 2013 Luís Reis
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.IO;
using NUnit.Framework;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.NRefactory.CSharp.FormattingTests
{
	[TestFixture]
	public class TestLinq : TestBase
	{
		[Test]
		public void TestBasicQuery ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var ax = from y in z
select y;
	}
}", @"
class Test
{
	public void Foo ()
	{
		var ax = from y in z
		         select y;
	}
}");
		}

		[Ignore]
		[Test]
		public void TestFormatWhole ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var x =from y in z
select y;
	}
}", @"
class Test
{
	public void Foo ()
	{
		var x = from y in z
		        select y;
	}
}");
		}

		[Test]
		public void TestFormatParenthesized ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var x = (from y in z
select y);
	}
}", @"
class Test
{
	public void Foo ()
	{
		var x = (from y in z
		         select y);
	}
}");
		}

		[Test]
		public void TestFormatInExpression ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var x = 1 + (from y in new int[1]
select y).First();
	}
}", @"
class Test
{
	public void Foo ()
	{
		var x = 1 + (from y in new int[1]
		             select y).First ();
	}
}");
		}

		[Ignore]
		[Test]
		public void TestFormatMultiple ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var x = from y in
from w in k
select w
select y;
	}
}", @"
class Test
{
	public void Foo ()
	{
		var x = from y in
		            from w in k
		            select w
		        select y;
	}
}");
		}

		[Test]
		public void TestExpression ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var x = from y in z
select
3;
	}
}", @"
class Test
{
	public void Foo ()
	{
		var x = from y in z
		        select
		            3;
	}
}");
		}

		[Test]
		public void TestBasicQueryNoLines ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			policy.NewLineBeforeNewQueryClause = NewLinePlacement.SameLine;
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var x = from y in z
select y;
	}
}", @"
class Test
{
	public void Foo ()
	{
		var x = from y in z select y;
	}
}");
		}

		[Test]
		public void TestBasicQueryAlwaysChangeLines ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			policy.NewLineBeforeNewQueryClause = NewLinePlacement.NewLine;
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var x = from y in z
select y;
	}
}", @"
class Test
{
	public void Foo ()
	{
		var x = from y in z
		        select y;
	}
}");
		}

		[Test]
		public void TestBasicQueryAddLine ()
		{
			CSharpFormattingOptions policy = FormattingOptionsFactory.CreateMono ();
			policy.NewLineBeforeNewQueryClause = NewLinePlacement.NewLine;
			Test (policy, @"
class Test
{
	public void Foo ()
	{
		var x = from y in z select y;
	}
}", @"
class Test
{
	public void Foo ()
	{
		var x = from y in z
		        select y;
	}
}");
		}
	}
}

