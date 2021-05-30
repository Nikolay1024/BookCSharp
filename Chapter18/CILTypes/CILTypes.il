.assembly extern mscorlib
{	
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89)
	.ver 4:0:0:0
}

// Наша сборка.
.assembly CILTypes
{
	.ver 1:0:0:0
}
// Модуль нашей однофайловой сборки.
.module CILTypes.dll

// Наша сборка имеет единственное пространство имен.
.namespace MyNamespace
{
	// Предполагается базовый класс System.Object.
	.class public MyBaseClass
	{
		// Опредление полей.
		.field private string stringField = "hello!"
		.field private int32 intField = int32(42)
		
		// Определение конструктора экземпляра.
		.method public hidebysig specialname rtspecialname
			instance void .ctor() cil managed
		{
			// Добавить код реализации. . .
		}
		
		// Определение свойства.
		.method public hidebysig specialname
			instance string get_TheString() cil managed
		{
			// Добавить код реализации. . .
		}
		.method public hidebysig specialname
			instance void set_TheString(string ’value') cil managed
		{
			// Добавить код реализации. . .
		}
		.property instance string TheString()
		{
			.get instance string
				MyNamespace.MyBaseClass::get_TheString()
			.set instance void
				MyNamespace.MyBaseClass::set_TheString(string)
		}
	}
	
	// Определение интерфейса.
	.class public interface IMyInterface {}

	// MyDenvedClass расширяет MyBaseClass
	// и реализует IMyInterface.
	.class public MyDerivedClass
		extends MyNamespace.MyBaseClass
		implements MyNamespace.IMyInterface
	{}
		
	// Определение структуры всегда является запечатанным.
	.class public sealed value MyStruct {}
	
	// Определение перечисления.
	.class public sealed enum MyEnum
	{
		.field public static literal valuetype
		MyNamespace.MyEnum A = int32(0)
		.field public static literal valuetype
		MyNamespace.MyEnum B = int32(l)
		.field public static literal valuetype
		MyNamespace.MyEnum C = int32(2)
	}
}